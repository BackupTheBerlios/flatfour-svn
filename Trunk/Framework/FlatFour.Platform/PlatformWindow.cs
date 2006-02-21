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
using System.Drawing;
using GameGuts;

namespace FlatFour.Platform
{
	public class PlatformWindow : IDisposable
	{
		private IntPtr _window;
		private Size _size;
		private EventHandler _resize;

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
			_size = new Size();
			_size.Width  = Toolkit.utGetWindowWidth(_window);
			_size.Height = Toolkit.utGetWindowHeight(_window);

			/* Add myself to the master list of windows */
			_windows[_window] = this;
		}

		public virtual void Dispose()
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

		public IntPtr Handle
		{
			get 
			{
				IntPtr handle = Toolkit.utGetWindowHandle(_window);
				return handle;
			}
		}

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
				if (!Toolkit.utResizeWindow(_window, value.Width, value.Height))
					throw new FrameworkException();
				_size.Width = Toolkit.utGetWindowWidth(_window);
				_size.Height = Toolkit.utGetWindowHeight(_window);
				if (_resize != null)
					_resize(this, EventArgs.Empty);
			}
		}

		public int Width
		{
			get 
			{ 
				return _size.Width; 
			}
		}


		public event EventHandler Resize
		{
			add
			{
				_resize += value;
			}
			remove
			{
				_resize -= value;
			}
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
				wnd.Size = new Size(e.arg0, e.arg1);
				break;
			}
		}
		
		#endregion
	}
}
