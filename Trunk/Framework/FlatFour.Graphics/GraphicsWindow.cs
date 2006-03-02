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
	public class GraphicsWindow : RenderTarget
	{
		private PlatformWindow _window;
		private Size _size;

		#region Setup and Teardown

		static GraphicsWindow()
		{
			GraphicsSystem.EnsureReady();
		}

		/* Create a new graphics-ready top-level window */
		public GraphicsWindow(string title, int width, int height)
		{
			_window = new PlatformWindow(title, width, height);
			CreateFromWindowHandle(IntPtr.Zero, _window.Handle);
			_window.Resize += new EventHandler(OnResize);
		}

		/* Attach graphics to an existing window */
		public GraphicsWindow(IntPtr windowHandle)
		{
			CreateFromWindowHandle(IntPtr.Zero, windowHandle);
		}
		
		public GraphicsWindow(IntPtr display, IntPtr windowHandle)
		{
			CreateFromWindowHandle(display, windowHandle);
		}

		private void CreateFromWindowHandle(IntPtr display, IntPtr windowHandle)
		{
			base.Handle = Toolkit.utCreateWindowTarget(display, windowHandle);

			_size = new Size();
			_size.Width  = Toolkit.utGetTargetWidth(Handle);
			_size.Height = Toolkit.utGetTargetHeight(Handle);
		}

		public override void Dispose()
		{
			base.Dispose();
			if (_window != null)
			{
				_window.Dispose();
				_window = null;
			}
		}

		#endregion

		#region Size Properties and Handling

		public int Height
		{
			get 
			{
				return _size.Height;
			}
		}

		public Size Size
		{
			get
			{
				return _size;
			}
			set
			{
				if (_window != null)
				{
					_window.Size = value;
				}
				else
				{
					_size = value;
					OnResize(this, EventArgs.Empty);
				}
			}
		}

		public int Width
		{
			get 
			{
				return _size.Width;
			}
		}

		/* Handle a resize of the containing window, whether it is an 
		 * external window or my own internal PlatformWindow */
		private void OnResize(object sender, EventArgs e)
		{
			if (sender == _window)
				_size = _window.Size;

			if (!Toolkit.utResizeRenderTarget(Handle, _size.Width, _size.Height))
				throw new FrameworkException();

			_size.Width = Toolkit.utGetTargetWidth(Handle);
			_size.Height = Toolkit.utGetTargetHeight(Handle);
		}

		#endregion

		public Bitmap GrabScreen()
		{
			Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			BitmapData data = bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

			if (!Toolkit.utGrabScreen(Handle, data.Scan0))
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
