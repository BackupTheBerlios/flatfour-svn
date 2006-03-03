#region BSD License
/* FlatFour - Position.cs
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
using System.Runtime.InteropServices;

namespace FlatFour
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Position
	{
		public double X, Y, Z;

		public static readonly Position Zero = new Position(0.0, 0.0, 0.0);

		public static Position Create(double x, double y, double z)
		{
			Position p;
			p.X = x;
			p.Y = y;
			p.Z = z;
			return p;
		}

		public Position(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}


		public static Position operator +(Vector3 v, Position p)
		{
			Position r;
			r.X = p.X + v.X;
			r.Y = p.Y + v.Y;
			r.Z = p.Z + v.Z;
			return r;
		}


		public Vector3 Diff(Position p)
		{
			Vector3 v;
			v.X = (float)(X - p.X);
			v.Y = (float)(Y - p.Y);
			v.Z = (float)(Z - p.Z);
			return v;
		}
	}
}
