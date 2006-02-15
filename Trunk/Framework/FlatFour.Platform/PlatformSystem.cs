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
using System.Diagnostics;
using GameGuts;

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
			Trace.WriteLine("Starting platform abstraction subsystem");
			if (!Toolkit.utInitialize())
				throw new FrameworkException();
			Trace.WriteLine("Platform subsystem started");
		}


		private static void OnShutdown(object sender, EventArgs e)
		{
			Trace.WriteLine("Stopping platform abstraction subsystem");
			if (!Toolkit.utShutdown())
				throw new FrameworkException();
			Trace.WriteLine("Platform subsystem stopped");
		}

		#endregion

		#region Event Loop

		public static event InputHandler Input;
		public static event TickHandler Tick;
		
		public static void EventLoop()
		{
			Toolkit.utEventHandler callback = new Toolkit.utEventHandler(OnEvent);
			Toolkit.utSetEventHandler(callback);

			while (Toolkit.utPollEvents(false))
			{
				if (Tick != null)
					Tick();
			}
		}

		private static void OnEvent(ref Toolkit.utEvent e)
		{
			switch (e.what)
			{
			case Toolkit.utEventKind.UT_EVENT_WINDOW_CLOSE:
			case Toolkit.utEventKind.UT_EVENT_WINDOW_REDRAW:
			case Toolkit.utEventKind.UT_EVENT_WINDOW_RESIZE:
				PlatformWindow.HandleEvent(ref e);
				break;

			default:
				if (Input != null)
				{
					InputEventArgs args = InputEventArgs.FromEvent(e);
					Input(args);
				}
				break;
			}
		}

		#endregion
	}
}
