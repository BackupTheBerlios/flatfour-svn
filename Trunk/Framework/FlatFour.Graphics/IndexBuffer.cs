#region BSD License
/* FlatFour.Graphics - IndexBuffer.cs
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
	public class IndexBuffer : IDisposable
	{
		private IntPtr _handle;
		private int _length;

		#region Setup and Teardown

		public IndexBuffer(int length)
		{
			_handle = Toolkit.utCreateIndexBuffer(length, Toolkit.utBufferFlags.UT_BUFFER_NONE);
			if (_handle == IntPtr.Zero)
				throw new FrameworkException();
			_length = length;
		}

		public void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				Toolkit.utReleaseIndexBuffer(_handle);
				_handle = IntPtr.Zero;
			}
		}

		#endregion

		public void CopyData(int[] data)
		{
			if (!Toolkit.utCopyIndexData(_handle, data, data.Length))
				throw new FrameworkException();
		}

		public IntPtr Handle
		{
			get { return _handle; }
		}

		public int Length
		{
			get { return _length; }
		}
	}
}
