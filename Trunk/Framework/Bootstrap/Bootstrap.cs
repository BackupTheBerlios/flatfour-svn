#region BSD License
/* Flat Four Bootstrapper - Bootstrap.cs
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
using FlatFour.Platform;
using FlatFour.Graphics;

namespace FlatFour.Bootstrapper
{
	public class Bootstrap
	{
		class MyBehavior : Behavior
		{
		}

		class MyHandler1
		{
			public void Handle(MyBehavior b)
			{
				Trace.WriteLine("MyHandler1");
			}
		}

		class MyHandler2
		{
			public void Handle(MyBehavior b)
			{
				Trace.WriteLine("MyHandler2");
			}
		}

		static int Main(string[] args)
		{
			GraphicsWindow wnd = new GraphicsWindow("Test Window", 640, 480);
			wnd.Camera.BackgroundColor = System.Drawing.Color.SkyBlue;

			Visualization.Add("FlatFour.Collision.BoxVisualizer");

			PlatformSystem.Tick += new TickHandler(OnTick);
			PlatformSystem.EventLoop();

			Framework.Disconnect();
			return 0;
		}

		static void OnTick()
		{
			Framework.Tick();
		}
	}
}
