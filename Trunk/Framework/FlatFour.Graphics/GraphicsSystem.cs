#region BSD License
/* FlatFour.Graphics - GraphicsSystem.cs
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
using GameGuts;

namespace FlatFour.Graphics
{
	public static class GraphicsSystem
	{
		#region Setup and Shutdown

		static GraphicsSystem()
		{
			PlatformSystem.EnsureReady();
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
			Trace.WriteLine("Starting graphics subsystem");
			if (!Toolkit.utInitialize())
				throw new FrameworkException();
			Trace.WriteLine("Graphics subsystem started");
		}


		private static void OnShutdown(object sender, EventArgs e)
		{
			Trace.WriteLine("Stopping graphics subsystem");
			if (!Toolkit.utShutdown())
				throw new FrameworkException();
			Trace.WriteLine("Graphics subsystem stopped");
		}

		#endregion

		/* Render a complete frame of the provided frame, using the viewpoint
		 * and render target provided by the provided camera. */
		public static void DrawFrame()
		{
			throw new NotImplementedException("GraphicsSystem.DrawFrame");
		}


		public static void BeginFrame()
		{
			if (!Toolkit.utBeginFrame())
				throw new FrameworkException();
		}

		public static void Clear(float red, float green, float blue, float alpha)
		{
			if (!Toolkit.utClear(red, green, blue, alpha))
				throw new FrameworkException();
		}

		public static void Draw(VertexBuffer vertices, VertexFormat format, IndexBuffer indices)
		{
			if (!Toolkit.utDraw(vertices.Handle, format.Handle, indices.Handle, 0, indices.Length))
				throw new FrameworkException();
		}

		public static void EndFrame()
		{
			if (!Toolkit.utEndFrame())
				throw new FrameworkException();
		}

		public static void Swap()
		{
			if (!Toolkit.utSwapAllRenderTargets())
				throw new FrameworkException();
		}

	}
}
