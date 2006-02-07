#region BSD License
/* FlatFour.Platform - PlatformWindow.cs
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
using System.Collections;
using Sim8.GameGuts;

namespace FlatFour.Platform
{
	public class PlatformWindow : IDisposable
	{
		private IntPtr _window;
		private int _width;
		private int _height;

		#region Setup and Teardown

		static PlatformWindow()
		{
			PlatformSystem.EnsureReady();
		}

		public PlatformWindow(string title, int width, int height)
		{
			_window = Toolkit.utCreateWindow(title, width, height);
			if (_window == IntPtr.Zero)
				throw new FrameworkException();

			/* Grab the sizes from the OS, in case my requested size wasn't possible */
			_width = Toolkit.utGetWindowWidth(_window);
			_height = Toolkit.utGetWindowHeight(_window);

			/* Add myself to the master list of windows */
			_windows[_window] = this;
		}

		public void Dispose()
		{
			if (_window != IntPtr.Zero)
			{
				_windows.Remove(_window);
				if (!Toolkit.utDestroyWindow(_window))
					throw new FrameworkException();
				_window = IntPtr.Zero;
			}
		}

		#endregion

		public void ResizeTo(int width, int height)
		{
			if (!Toolkit.utResizeWindow(_window, width, height))
				throw new FrameworkException();
			_width = Toolkit.utGetWindowWidth(_window);
			_height = Toolkit.utGetWindowHeight(_window);
		}

		public int Width
		{
			get { return _width; }
		}

		public int Height
		{
			get { return _height; }
		}

		#region Event Handling

		/* This associates the Toolkit window handle with its corresponding
		 * PlatformWindow object. I use it to route messages from the
		 * event loop to the correct event handlers. */
		private static Hashtable _windows = new Hashtable();

		internal static void HandleEvent(ref Toolkit.utEvent e)
		{
			PlatformWindow wnd = (PlatformWindow)_windows[e.window];
			switch (e.what)
			{
			case Toolkit.utEventKind.UT_EVENT_WINDOW_CLOSE:
				wnd.Dispose();
				break;

			case Toolkit.utEventKind.UT_EVENT_WINDOW_RESIZE:
				wnd.OnResize(e.arg0, e.arg1);
				break;
			}
		}
		
		private void OnResize(int width, int height)
		{
			_width = width;
			_height = height;
		}

		#endregion
	}
}
