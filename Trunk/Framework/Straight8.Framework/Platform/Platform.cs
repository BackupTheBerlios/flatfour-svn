#region BSD License
/* Straight8.Framework - Platform.cs
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
using System.Reflection;
using Sim8.GameGuts;

namespace Straight8.Framework
{
	public class Platform
	{
		#region Setup and Teardown

		static Platform()
		{
			/* Write the framework version to the trace log */
			Assembly assembly = Assembly.GetExecutingAssembly();
			AssemblyName name = assembly.GetName();
			string version = name.Version.ToString();
			Platform.Trace("Straight8 Framework version " + version);
		}


		public static void Connect()
		{
			Platform.Trace("Connecting to Platform");

			/* Initialize the platform abstraction toolkit */
			if (!Toolkit.utInitialize())
				throw new FrameworkException();

			Platform.Trace("Platform connected");
		}


		public static void Disconnect()
		{
			Platform.Trace("Disconnecting from Platform");

			/* Shut down the platform abstraction toolkit */
			if (!Toolkit.utShutdown())
				throw new FrameworkException("Errors detected during disconnect from Toolkit");

			Platform.Trace("Platform disconnected");
		}

		#endregion

		#region Event Loop and Delegates

		public delegate void InputHandler(InputEventArgs args);
		public static event InputHandler Input;

		public delegate void TickHandler();
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
				GraphicsWindow.HandleEvent(ref e);
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

		#region Trace and Diagnostics 

		public static void Trace(string message, params object[] args)
		{
			message = String.Format(message, args);
			System.Diagnostics.Trace.WriteLine(message, "Framework");
		}
		
		#endregion

		#region Timer

		public static int TickCount
		{
			get
			{
				return Toolkit.utGetTimer();
			}
		}

		#endregion
	}
}
