#region BSD License
/* FlatFour.Graphics - Texture.cs
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
	public class Texture : IDisposable
	{
		private IntPtr _handle;

		#region Setup and Teardown

		public Texture(int width, int height, TextureFormat format)
		{
			_handle = Toolkit.utCreateTexture(width, height, (Toolkit.utTextureFormat)format);
			if (_handle == IntPtr.Zero)
				throw new FrameworkException();
		}

		public void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				Toolkit.utReleaseTexture(_handle);
				_handle = IntPtr.Zero;
			}
		}

		#endregion

		public void CopyData(byte[] data)
		{
			if (!Toolkit.utCopyTextureData(_handle, data))
				throw new FrameworkException();
		}

		[CLSCompliant(false)]
		public void CopyData(uint[] data)
		{
			if (!Toolkit.utCopyTextureData(_handle, data))
				throw new FrameworkException();
		}

		public IntPtr Handle
		{
			get { return _handle; }
		}
	}
}
