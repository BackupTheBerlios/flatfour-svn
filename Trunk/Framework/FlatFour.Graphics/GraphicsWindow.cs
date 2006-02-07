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
	public class GraphicsWindow : PlatformWindow
	{
		private IntPtr _handle;

		#region Setup and Teardown

		static GraphicsWindow()
		{
			GraphicsSystem.EnsureReady();
		}

		public GraphicsWindow(string title, int width, int height)
			: base(title, width, height)
		{
			_handle = Toolkit.utCreateWindowTarget(this.Handle);
			if (_handle == IntPtr.Zero)
				throw new FrameworkException();
		}

		public override void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				if (!Toolkit.utReleaseRenderTarget(_handle))
					throw new FrameworkException();
				_handle = IntPtr.Zero;
			}

			base.Dispose ();
		}

		#endregion

	
		public Bitmap GrabScreen()
		{
			Bitmap bmp = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
			Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
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
