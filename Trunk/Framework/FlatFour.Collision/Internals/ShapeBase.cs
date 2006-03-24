#region BSD License
/* FlatFour.Collision - ShapeBase.cs
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
using OpenDE;

namespace FlatFour.Collision.Internals
{
	public abstract class ShapeBase : Behavior, IDisposable
	{
		private IntPtr _handle;

		public virtual void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				d.GeomDestroy(_handle);
				_handle = IntPtr.Zero;
				GC.SuppressFinalize(this);
			}
		}

		protected IntPtr Handle
		{
			get { return _handle; }
			set { _handle = value; }
		}
	}
}
