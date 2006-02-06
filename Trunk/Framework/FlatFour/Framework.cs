#region BSD License
/* FlatFour - Framework.cs
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

namespace FlatFour
{
	public class Framework
	{
		private static bool _connected;
		private static EventHandler _startup;
		private static EventHandler _shutdown;

		
		static Framework()
		{
			_connected = true;

			/* Ensure that Disconnect() is always called before app exit */
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
		}

		
		public static void Connect()
		{
			if (!_connected)
			{
				_connected = true;
				Trace.WriteLine("Connecting Framework");
				Startup(null, EventArgs.Empty);
			}
		}


		public static void Disconnect()
		{
			if (_connected)
			{
				_connected = false;
				Trace.WriteLine("Disconnecting Framework");

				/* Call subsystems in reverse order. If B depends on A, A will 
				 * still be connected when B is shutdown */
				if (_shutdown != null)
				{
					object[] args = new object[] { null, EventArgs.Empty };
					Delegate[] delegates = _shutdown.GetInvocationList();
					for (int i = delegates.Length - 1; i >= 0; --i)
						delegates[i].DynamicInvoke(args);
				}
			}
		}

	
		public static void ResetSubsystems()
		{
			_startup = null;
			_shutdown = null;
			_connected = true;
		}


		public static EventHandler Startup
		{
			get 
			{ 
				return _startup; 
			}
			set
			{
				_startup = value;

				/* Call the delegate that was just added to the end of the list */
				if (_connected)
				{
					object[] args = new object[] { null, EventArgs.Empty };
					Delegate[] delegates = _startup.GetInvocationList();
					delegates[delegates.Length - 1].DynamicInvoke(args);
				}
			}
		}

		public static EventHandler Shutdown
		{
			get { return _shutdown; }
			set { _shutdown = value; }
		}


		private static void OnProcessExit(object sender, EventArgs e)
		{
			Disconnect();
		}
	}
}
