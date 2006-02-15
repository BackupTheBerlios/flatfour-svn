#region BSD License
/* FlatFour.Graphics - VertexBuffer.cs
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
using GameGuts;

namespace FlatFour.Graphics
{
	public class VertexBuffer : IDisposable
	{
		private IntPtr _handle;

		#region Setup and Teardown

		public VertexBuffer(int length)
		{
			_handle = Toolkit.utCreateVertexBuffer(length, Toolkit.utBufferFlags.UT_BUFFER_NONE);
			if (_handle == IntPtr.Zero)
				throw new FrameworkException();
		}

		public void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				Toolkit.utReleaseVertexBuffer(_handle);
				_handle = IntPtr.Zero;
			}
		}

		#endregion

		public void CopyData(float[] data)
		{
			if (!Toolkit.utCopyVertexData(_handle, data, data.Length))
				throw new FrameworkException();
		}

		public IntPtr Handle
		{
			get { return _handle; }
		}
	}
}
