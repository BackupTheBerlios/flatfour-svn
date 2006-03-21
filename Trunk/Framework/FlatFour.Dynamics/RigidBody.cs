#region BSD License
/* FlatFour.Dynamics - RigidBody.cs
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
using OpenDE;

namespace FlatFour.Dynamics
{
	public class RigidBody : Pose, IDisposable
	{
		private IntPtr _handle;

		public RigidBody()
		{
			_handle = d.BodyCreate(DynamicsSystem.Handle);
			DynamicsSystem.Objects.Add(this);
		}

		public void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				d.BodyDestroy(_handle);
				_handle = IntPtr.Zero;
				GC.SuppressFinalize(this);
				DynamicsSystem.Objects.Remove(this);
			}
		}


		internal IntPtr Handle
		{
			get { return _handle; }
		}

		internal void Reload()
		{
			d.BodyCopyPosition(_handle, out Position.X);
		}
	}
}
