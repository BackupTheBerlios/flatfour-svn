#region BSD License
/* Straight8.Framework - T.cs
 * Copyright (c) 2001-2005 Jason Perkins.
 * All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the BSD-style license that is 
 * included with this library in the file LICENSE.txt.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
 * files LICENSE.txt for more details. */
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

namespace Straight8.Framework
{
	/* Not sure what I think of this, but here's a utility class to pull
	 * strings from an external resource table, allowing for some I18N */
	public class T
	{
		private static Hashtable _tables;

		#region Proxy Resource Manager
		/* A wrapper for the default manager. If an assembly doesn't have a
		 * string table, I can set DoesExist to fals and save some cycles */
		private class ProxyResourceManager : ResourceManager
		{
			public bool DoesExist;

			public ProxyResourceManager(string name, Assembly assembly)
				: base(name, assembly)
			{
				DoesExist = true;
			}
		}
		#endregion

		static T()
		{
			_tables = new Hashtable();
		}

		public static string Get(string key)
		{
			/* Figure out who is calling me and retrieve their string table */
			Assembly caller = Assembly.GetCallingAssembly();
			ProxyResourceManager mgr = (ProxyResourceManager)_tables[caller];
			if (mgr == null)
			{
				/* First hit on this assembly, load and cache string table */
				AssemblyName an = caller.GetName();
				mgr = new ProxyResourceManager(an.Name + ".StringTable", caller);

				/* Make sure it really exists */
				try
				{
					mgr.GetString("NoSuchString");
				}
				catch (MissingManifestResourceException)
				{
					mgr.DoesExist = false;
				}

				_tables[caller] = mgr;
			}

			/* Look up the requested string */
			string value = (mgr.DoesExist) ? mgr.GetString(key) : null;
			if (value == null)
				value = key;

			return value;
		}
	}
}
