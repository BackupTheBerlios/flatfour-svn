#region BSD License
/* FlatFour - Vector3.cs
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
	public struct Vector3
	{
		public float X, Y, Z;

		private static readonly Vector3 Zero = new Vector3(0.0f, 0.0f, 0.0f);


		public Vector3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}


		public Vector3 Cross(Vector3 v)
		{
			Vector3 r;
			r.X = Y * v.Z - Z * v.Y;
			r.Y = Z * v.X - X * v.Z;
			r.Z = X * v.Y - Y * v.X;
			return r;
		}


		public float Dot(Vector3 v)
		{
			return (X * v.X + Y * v.Y + Z * v.Z);
		}


		public float Length
		{
			get { return (float)Math.Sqrt(X*X + Y*Y + Z*Z); }
		}


		public float LengthSquared
		{
			get { return (X*X + Y*Y + Z*Z); }
		}


		public void Normalize()
		{
			float length = Length;
			if (length < 0.00001)
			{
				X = 1.0f;
				Y = 0.0f;
				Z = 0.0f;
			}
			else
			{
				X /= length;
				Y /= length;
				Z /= length;
			}
		}


		public Vector3 Normalized()
		{
			Vector3 result = this;
			result.Normalize();
			return result;
		}

		public static Vector3 operator + (Vector3 a, Vector3 b)
		{
			return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}


		public static Vector3 operator - (Vector3 a)
		{
			Vector3 result;
			result.X = -a.X;
			result.Y = -a.Y;
			result.Z = -a.Z;
			return result;
		}

		public static Vector3 operator - (Vector3 a, Vector3 b)
		{
			return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}


		public static Vector3 operator * (Vector3 a, float scale)
		{
			return new Vector3(a.X * scale, a.Y * scale, a.Z * scale);
		}


		public static Vector3 operator * (float scale, Vector3 a)
		{
			return new Vector3(a.X * scale, a.Y * scale, a.Z * scale);
		}


		public static Vector3 operator / (Vector3 a, float scale)
		{
			return new Vector3(a.X / scale, a.Y / scale, a.Z / scale);
		}


		public static Vector3 Set(float x, float y, float z)
		{
			Vector3 result;
			result.X = x;
			result.Y = y;
			result.Z = z;
			return result;
		}


		public Vector3 ProjectToPlane(Vector3 normal)
		{
			Vector3 result = this - (normal * this.Dot(normal));
			return result;
		}


		public override string ToString()
		{
			string result = "{" + X + ", " + Y + ", " + Z + "}";
			return result;
		}
	}
}
