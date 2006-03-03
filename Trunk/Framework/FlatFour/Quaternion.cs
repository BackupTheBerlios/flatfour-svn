#region BSD License
/* FlatFour - Quaternion.cs
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
using System.Runtime.InteropServices;

namespace FlatFour
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Quaternion
	{
		public float W, X, Y, Z;

		public static readonly Quaternion Identity = new Quaternion(1,0,0,0);


		public Quaternion(float w, float x, float y, float z)
		{
			W = w;
			X = x;
			Y = y;
			Z = z;
		}


		public static Quaternion operator *(Quaternion a, Quaternion b)
		{
			Quaternion result;
			result.W = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
			result.X = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
			result.Y = a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z;
			result.Z = a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X;
			return result;
		}


		public static Vector3 operator *(Quaternion xform, Vector3 vec)
		{
			/* From nVidia SDK */
			Vector3 uv, uuv;
			Vector3 qvec = new Vector3(xform.X, xform.Y, xform.Z);

			uv = qvec.Cross(vec); 
			uuv = qvec.Cross(uv); 
			uv *= (2.0f * xform.W); 
			uuv *= 2.0f; 
		
			return vec + uv + uuv;
		}


		public Quaternion Inverse()
		{
			Quaternion result;
			result.W = -W;
			result.X = X;
			result.Y = Y;
			result.Z = Z;
			return result;
		}


		public static Quaternion FromAngleAxis(float angle, float axisX, float axisY, float axisZ)
		{
			float sin = (float)Math.Sin(angle * 0.5f);
			float cos = (float)Math.Cos(angle * 0.5f);
			Quaternion result;
			result.W = cos;
			result.X = axisX * sin;
			result.Y = axisY * sin;
			result.Z = axisZ * sin;
			return result;
		}

		public static Quaternion FromAngleAxis(float angle, Vector3 axis)
		{
			return Quaternion.FromAngleAxis(angle, axis.X, axis.Y, axis.Z);
		}


		public static Quaternion FromEuler(float x, float y, float z)
		{
			/* From http://www.euclideanspace.com/ */

			double c1 = Math.Cos(z / 2.0);
			double s1 = Math.Sin(z / 2.0);
			double c2 = Math.Cos(y / 2.0);
			double s2 = Math.Sin(y / 2.0);
			double c3 = Math.Cos(x / 2.0);
			double s3 = Math.Sin(x / 2.0);

			double c1c2 = c1 * c2;
			double s1s2 = s1 * s2;

			Quaternion result;
			result.W = (float)(c1c2*c3 + s1s2*s3);
			result.X = (float)(c1c2*s3 - s1s2*c3);
			result.Y = (float)(c1*s2*c3 + s1*c2*s3);
			result.Z = (float)(s1*c2*c3 - c1*s2*s3);
			return result;
		}

		public static Quaternion FromMatrix(Matrix4 m)
		{
			Quaternion result;

			/* From http://www.euclideanspace.com/ */
			float trace = m.M00 + m.M11 + m.M22 + 1.0f;
			if (trace > 0.00001f)
			{
				float s = 0.5f / (float)Math.Sqrt(trace);
				result.W = 0.25f / s;
				result.X = (m.M21 - m.M12) * s;
				result.Y = (m.M02 - m.M20) * s;
				result.Z = (m.M10 - m.M01) * s;
			}
			else
			{
				if (m.M00 > m.M11 && m.M00 > m.M22)
				{
					float s = 2.0f * (float)Math.Sqrt(1.0f + m.M00 - m.M11 - m.M22);
					result.X = 0.25f * s;
					result.Y = (m.M01 + m.M10) / s;
					result.Z = (m.M02 + m.M20) / s;
					result.W = (m.M12 - m.M21) / s;
				}
				else if (m.M11 > m.M22)
				{
					float s = 2.0f * (float)Math.Sqrt(1.0f + m.M11 - m.M00 - m.M22);
					result.X = (m.M01 + m.M10) / s;
					result.Y = 0.25f * s;
					result.Z = (m.M12 + m.M21) / s;
					result.W = (m.M02 - m.M20) / s;
				}
				else
				{
					float s = 2.0f * (float)Math.Sqrt(1.0f + m.M22 - m.M00 - m.M11);
					result.X = (m.M02 + m.M20) / s;
					result.Y = (m.M12 + m.M21) / s;
					result.Z = 0.25f * s;
					result.W = (m.M01 - m.M10) / s;
				}
			}
			return result;
		}


		public Quaternion Normalized()
		{
			Quaternion result;
			float len = (float)Math.Sqrt(W*W + X*X + Y*Y + Z*Z);
			if (len > 0.00001f)
			{
				result.W = W / len;
				result.X = X / len;
				result.Y = Y / len;
				result.Z = Z / len;
			}
			else
			{
				result.W = 1.0f;
				result.X = 0.0f;
				result.Y = 0.0f;
				result.Z = 0.0f;
			}
			return result;
		}

		
		public Vector3 ToEuler()
		{
			/* From http://www.euclideanspace.com/ */

			double sqw = W * W;
			double sqx = X * X;
			double sqy = Y * Y;
			double sqz = Z * Z;

			Vector3 result;
			result.X = (float)Math.Atan2(2.0 * (Y*Z + X*W), (-sqx - sqy + sqz + sqw));
			result.Y = (float)Math.Asin(-2.0 * (X*Z - Y*W) / (sqx + sqy + sqz + sqw));
			result.Z = (float)Math.Atan2(2.0 * (X*Y + Z*W), ( sqx - sqy - sqz + sqw));
			return result;
		}


		public override string ToString()
		{
			return this.ToEuler().ToString();
		}

	}
}
