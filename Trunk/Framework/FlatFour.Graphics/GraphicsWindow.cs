#region BSD License
/* FlatFour.Graphics - GraphicsWindow.cs
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
using System.Drawing;
using System.Drawing.Imaging;
using FlatFour.Platform;
using GameGuts;

namespace FlatFour.Graphics
{
	public class GraphicsWindow : IRenderTarget
	{
		private PlatformWindow _window;
		private IntPtr _handle;
		private Camera _camera;

		#region Setup and Teardown

		static GraphicsWindow()
		{
			GraphicsSystem.EnsureReady();
		}

		public GraphicsWindow(string title, int width, int height)
		{
			_window = new PlatformWindow(title, width, height);
			_handle = Toolkit.utCreateWindowTarget(_window.Handle);
			if (_handle == IntPtr.Zero)
				throw new FrameworkException();
			GraphicsSystem.RenderTarget.Add(this);

			_camera = new Camera();
		}

		public void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				if (!Toolkit.utReleaseRenderTarget(_handle))
					throw new FrameworkException();
				_handle = IntPtr.Zero;
				GraphicsSystem.RenderTarget.Remove(this);
			}

			_window.Dispose ();
			_window = null;
		}

		#endregion


		public Camera Camera
		{
			get { return _camera; }
			set { _camera = value; }
		}

		public int Height
		{
			get { return _window.Height; }
		}

		public int Width
		{
			get { return _window.Width; }
		}


		public Bitmap GrabScreen()
		{
			Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			BitmapData data = bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

			if (!Toolkit.utGrabScreen(_handle, data.Scan0))
			{
				bmp.Dispose();
				throw new FrameworkException();
			}

			bmp.UnlockBits(data);
			bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
			return bmp;
		}

	}
}
