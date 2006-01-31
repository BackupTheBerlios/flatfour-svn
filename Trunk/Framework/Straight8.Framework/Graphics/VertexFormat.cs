#region BSD License
/* Straight8.Framework - VertexFormat.cs
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
using Sim8.GameGuts;

namespace Straight8.Framework
{
	public class VertexFormat : IDisposable
	{
		private IntPtr _handle;

		#region Setup and Teardown

		public VertexFormat(VertexAttribute[] attributes)
		{
			/* Convert the enum type */
			Toolkit.utVertexAttribute[] uta = new Toolkit.utVertexAttribute[attributes.Length];
			for (int i = 0; i < attributes.Length; ++i)
				uta[i] = (Toolkit.utVertexAttribute)attributes[i];

			_handle = Toolkit.utCreateVertexFormat(uta, uta.Length);
			if (_handle == IntPtr.Zero)
				throw new FrameworkException();
		}

		public void Dispose()
		{
			if (_handle != IntPtr.Zero)
			{
				Toolkit.utReleaseVertexFormat(_handle);
				_handle = IntPtr.Zero;
			}
		}

		#endregion

		public IntPtr Handle
		{
			get { return _handle; }
		}
	}
}
