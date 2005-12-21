#region BSD License
/* Straight8.Framework - GraphicsWindow.cs
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
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using Sim8.GameGuts;

namespace Straight8.Framework
{
	public class GraphicsWindow : IDisposable
	{
		private IntPtr _window;
		private IntPtr _graphics;
		private int    _width, _height;

		#region Setup and Teardown

		/* Creates a new window attaches a rendering context */
		public GraphicsWindow(string title, int width, int height)
		{
			Platform.Trace("Creating graphics window '{0}' ({1}x{2})", title, width, height);

			_window = Toolkit.utCreateWindow(title, width, height);
			if (_window == IntPtr.Zero)
				throw new FrameworkException();

			IntPtr hWnd = Toolkit.utGetWindowHandle(_window);
			_graphics = Toolkit.utCreateWindowTarget(hWnd);
			if (_graphics == IntPtr.Zero)
				throw new FrameworkException();

			/* Grab the sizes from the OS, in case my requested size wasn't possible */
			_width = Toolkit.utGetWindowWidth(_window);
			_height = Toolkit.utGetWindowHeight(_window);

			_masterWindowList[_window] = this;
		}

		/* Attaches a rendering context to an existing window */
		public GraphicsWindow(IntPtr parentWindow)
		{
			Platform.Trace("Creating child graphics window");
			
			_window = IntPtr.Zero;
			_graphics = Toolkit.utCreateWindowTarget(parentWindow);
			if (_graphics == IntPtr.Zero)
				throw new FrameworkException();
		}

		public void Dispose()
		{
			if (_graphics != IntPtr.Zero)
			{
				if (!Toolkit.utReleaseRenderTarget(_graphics))
					throw new FrameworkException();
				_graphics = IntPtr.Zero;
			}

			if (_window != IntPtr.Zero)
			{
				_masterWindowList.Remove(_window);
				if (!Toolkit.utDestroyWindow(_window))
					throw new FrameworkException();
				_window = IntPtr.Zero;
			}
		}

		#endregion

		public Bitmap GrabScreen()
		{
			Bitmap bmp = new Bitmap(_width, _height, PixelFormat.Format24bppRgb);
			Rectangle rect = new Rectangle(0, 0, _width, _height);
			BitmapData data = bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

			if (!Toolkit.utGrabScreen(_graphics, data.Scan0))
			{
				bmp.Dispose();
				throw new FrameworkException();
			}

			bmp.UnlockBits(data);
			bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
			return bmp;
		}

	
		public void ResizeTo(int width, int height)
		{
			if (!Toolkit.utResizeWindow(_window, width, height))
				throw new FrameworkException();
			_width = Toolkit.utGetWindowWidth(_window);
			_height = Toolkit.utGetWindowHeight(_window);
			OnResize(_width, _height);
		}


		public int Width
		{
			get { return _width; }
		}

		public int Height
		{
			get { return _height; }
		}


		#region Event Handlers

		private void OnResize(int width, int height)
		{
			_width = width;
			_height = height;
			if (_graphics != IntPtr.Zero)
			{
				if (!Toolkit.utResizeRenderTarget(_graphics, width, height))
					throw new FrameworkException();
			}
		}

		#endregion

		#region Master Window List
		
		/* This associates the Toolkit window handle with the .NET 
		 * GraphicsWindow object. I use it to route messages from
		 * the event loop to the appropriate window object */
		private static Hashtable _masterWindowList = new Hashtable();

		internal static void HandleEvent(ref Toolkit.utEvent e)
		{
			GraphicsWindow window = (GraphicsWindow)_masterWindowList[e.window];
			switch (e.what)
			{
			case Toolkit.utEventKind.UT_EVENT_WINDOW_CLOSE:
				window.Dispose();
				break;

			case Toolkit.utEventKind.UT_EVENT_WINDOW_RESIZE:
				window.OnResize(e.arg0, e.arg1);
				break;
			}
		}
		
		#endregion
	}
}
