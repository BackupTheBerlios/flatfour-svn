#region BSD License
/* FlatFour.Platform - PlatformSystem.cs
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

namespace FlatFour.Platform
{
	public class PlatformSystem
	{
		#region Setup and Shutdown

		static PlatformSystem()
		{
			Framework.Startup += new EventHandler(OnStartup);
			Framework.Shutdown += new EventHandler(OnShutdown);
		}

		/* Stub used by other subsystems that depend on this one to force it 
		 * to call its static constructor and initialize */
		public static void EnsureReady()
		{
		}


		private static void OnStartup(object sender, EventArgs e)
		{
		}


		private static void OnShutdown(object sender, EventArgs e)
		{
		}

		#endregion
	}
}
