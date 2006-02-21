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
using System.Drawing;
using System.Collections.Generic;
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
			Framework.FrameUpdate += new EventHandler(OnTick);

			CreateRenderTargetList();
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

			DisposeRenderTargetList();

			if (!Toolkit.utShutdown())
				throw new FrameworkException();
			Trace.WriteLine("Graphics subsystem stopped");
		}

		#endregion

		#region Render Target Management

		/* To enable transparent multithreading, the graphics system must know
		 * about all active render targets, so it knows what work needs to be
		 * done each frame */
		private static List<RenderTarget> _targets;

		private static void CreateRenderTargetList()
		{
			_targets = new List<RenderTarget>();
		}

		private static void DisposeRenderTargetList()
		{
			while (_targets.Count > 0)
				_targets[0].Dispose();
			_targets.Clear();
		}

		/* Used by GraphicsWindow to add/remove targets */
		internal static List<RenderTarget> RenderTarget
		{
			get { return _targets; }
		}

		#endregion


		private static void OnTick(object sender, EventArgs e)
		{
			DrawFrame();
		}

		public static void DrawFrame()
		{
			if (_targets.Count > 1)
				throw new NotImplementedException("Multiple render targets are not supported yet");

			BeginFrame();
			foreach (RenderTarget rt in _targets)
			{
				DrawSingleTarget(rt);
			}
			EndFrame();
			Swap();
		}

		public static void DrawFrame(RenderTarget rt)
		{
			BeginFrame();
			DrawSingleTarget(rt);
			EndFrame();
			rt.Swap();
		}

		private static void DrawSingleTarget(RenderTarget rt)
		{
			Color color = rt.Camera.BackgroundColor;
			Clear(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);
		}


		#region Immediate Rendering Routines

		/* These routines are used by DrawFrame() internally, and are exposed
		 * internally for the unit tests */

		internal static void BeginFrame()
		{
			if (!Toolkit.utBeginFrame())
				throw new FrameworkException();
		}

		internal static void Clear(float red, float green, float blue, float alpha)
		{
			if (!Toolkit.utClear(red, green, blue, alpha))
				throw new FrameworkException();
		}

		internal static void Draw(VertexBuffer vertices, VertexFormat format, IndexBuffer indices)
		{
			if (!Toolkit.utDraw(vertices.Handle, format.Handle, indices.Handle, 0, indices.Length))
				throw new FrameworkException();
		}

		internal static void EndFrame()
		{
			if (!Toolkit.utEndFrame())
				throw new FrameworkException();
		}

		internal static void Swap()
		{
			if (!Toolkit.utSwapAllRenderTargets())
				throw new FrameworkException();
		}

		#endregion
	}
}
