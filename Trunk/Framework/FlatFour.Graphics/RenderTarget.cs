#region BSD License
/* FlatFour.Graphics - RenderTarget.cs
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
using GameGuts;

namespace FlatFour.Graphics
{
	/* Base class for rendering targets; manages the internal graphics
	 * object handle and the attached camera */
	public abstract class RenderTarget : IDisposable
	{
		private IntPtr _handle;
		private Camera _camera;

		public RenderTarget()
		{
			_camera = new Camera();
		}

		/* Get/set the internal object handle. Automatically registers
		 * this target with the graphics system so it can automatically
		 * update it on calls to DrawFrame() */
		protected IntPtr Handle
		{
			get
			{
				return _handle;
			}
			set
			{
				_handle = value;
				if (_handle == IntPtr.Zero)
					throw new FrameworkException();
				GraphicsSystem.RenderTarget.Add(this);
			}
		}

		/* Release the internal implementation object and deregister
		 * the render target from the graphics system */
		public virtual void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				if (!Toolkit.utReleaseRenderTarget(_handle))
					throw new FrameworkException();
				_handle = IntPtr.Zero;
				GraphicsSystem.RenderTarget.Remove(this);
			}
		}

		public Camera Camera
		{
			get { return _camera; }
			set { _camera = value; }
		}

		public void Swap()
		{
			if (!Toolkit.utSwapRenderTarget(_handle))
				throw new FrameworkException();
		}
	}
}
