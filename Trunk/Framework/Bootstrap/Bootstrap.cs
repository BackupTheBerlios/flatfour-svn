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

/* This stuff is only for testing (remove assembly too!) */
using FlatFour.Collision;

namespace FlatFour.Bootstrapper
{
	public class Bootstrap
	{
		static Scene _scene = new Scene();
		static RenderMessage _rm = new RenderMessage();

		static int Main(string[] args)
		{
			GraphicsWindow wnd = new GraphicsWindow("Test Window", 640, 480);

			/* Create an actor at the origin to contain the camera */
			Actor camera = new Actor();
			camera.Add(wnd.Camera);
			wnd.Camera.BackgroundColor = System.Drawing.Color.SkyBlue;
			wnd.Camera.Position.Z = 3.0;

			/* Create an actor to hold a box */
			Actor box = new Actor();
			box.Add(new BoxShape(1.0f, 1.0f, 1.0f));

			_scene.Add(camera);
			_scene.Add(box);

			/* Enable visualization of collision shapes */
			Visualization.Add("FlatFour.Collision.BoxVisualizer");

			/* Run the event loop */
			PlatformSystem.Tick += new TickHandler(OnTick);
			PlatformSystem.EventLoop();

			Framework.Disconnect();
			return 0;
		}

		static void OnTick()
		{
			_scene.Dispatch(_rm);
			Framework.Tick();
		}
	}
}
