#region BSD License
/* FlatFour.Collision - BoxShape.cs
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

namespace FlatFour.Collision
{
	public class BoxShape : Internals.ShapeBase
	{
		private Vector3 _lengths;

		public BoxShape(float lx, float ly, float lz)
		{
			_lengths = Vector3.Create(lx, ly, lz);
			base.Handle = d.CreateBox(IntPtr.Zero, lx, ly, lz);
		}

		public Vector3 Lengths
		{
			get
			{
				return _lengths;
			}
			set
			{
				_lengths = value;
				d.GeomBoxSetLengths(base.Handle, value.X, value.Y, value.Z);
			}
		}
	}
}
