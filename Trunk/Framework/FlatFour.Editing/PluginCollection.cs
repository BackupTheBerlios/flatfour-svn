#region BSD License
/* FlatFour.Editing - PluginManager.cs
 * Copyright (c) 2001-2006 Jason Perkins.
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
using System.Collections.Specialized;
using System.Configuration;

namespace FlatFour.Editing
{
	/// <summary>
	///  The editor plugin collection.
	/// </summary>
	public class PluginCollection : IPluginCollection
	{
		private Hashtable _plugins;
		private Dispatcher<Message> _dispatcher;

		public PluginCollection()
		{
			_plugins = new Hashtable();
			_dispatcher = new Dispatcher<Message>();
		}

		public void Dispose()
		{
			UnloadAll();
			GC.SuppressFinalize(this);
		}


		/// <summary>
		///  Returns the number of enabled plugins.
		/// </summary>
		public int Count
		{
			get { return _plugins.Values.Count; }
		}


		/// <summary>
		///  Loads a specific plugin.
		/// </summary>
		/// <param name="name">type plugin type name</param>
		public void Load(string name)
		{
			/* Check to see if it is already loaded */
			if (_plugins[name] != null)
				return;

			/* Load it */
			object plugin = Framework.CreateInstance(name);
			if (plugin == null)
				throw new TypeLoadException("Unable to find type '" + name + "'");

			/* Wire it up */
			_dispatcher.Add(plugin);
			_plugins.Add(name, plugin);
		}


		/// <summary>
		///  Load the set of enabled plugins.
		/// </summary>
		public void LoadEnabledPlugins()
		{
			/* Read the list of system plugins */
			NameValueCollection system = (NameValueCollection)ConfigurationManager.GetSection("plugins");
			foreach (string key in system.Keys)
			{
				bool enabled = bool.Parse(system[key]);
				if (enabled)
					Load(key);
			}
		}


		/// <summary>
		///  Unload all plugins.
		/// </summary>
		public void UnloadAll()
		{
		}


		/// <summary>
		///  Returns true if the specified plugin is loaded.
		/// </summary>
		/// <param name="name">plugin type name</param>
		/// <returns>True if the plugin is enabled</returns>
		public bool IsLoaded(string name)
		{
			return (_plugins[name] != null);
		}
	}
}
