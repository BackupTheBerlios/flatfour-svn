#region BSD License
/* Straight8.Framework - Matrix4.cs
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
using Sim8.GameGuts;

namespace Straight8.Framework
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Matrix4
	{
		public float M00, M10, M20, M30;
		public float M01, M11, M21, M31;
		public float M02, M12, M22, M32;
		public float M03, M13, M23, M33;

		private static readonly Matrix4 identity = new Matrix4(1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1);
		private static readonly Matrix4 zero = new Matrix4(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);


		public Matrix4(float _00, float _01, float _02, float _03,
		               float _10, float _11, float _12, float _13,
		               float _20, float _21, float _22, float _23,
		               float _30, float _31, float _32, float _33)
		{
			M00 = _00;   M01 = _01;   M02 = _02;   M03 = _03;
			M10 = _10;   M11 = _11;   M12 = _12;   M13 = _13;
			M20 = _20;   M21 = _21;   M22 = _22;   M23 = _23;
			M30 = _30;   M31 = _31;   M32 = _32;   M33 = _33;
		}


		public static Matrix4 operator *(Matrix4 a, Matrix4 b)
		{
			Matrix4 result;

			result.M00 = a.M00 * b.M00 + a.M01 * b.M10 + a.M02 * b.M20 + a.M03 * b.M30;
			result.M01 = a.M00 * b.M01 + a.M01 * b.M11 + a.M02 * b.M21 + a.M03 * b.M31;
			result.M02 = a.M00 * b.M02 + a.M01 * b.M12 + a.M02 * b.M22 + a.M03 * b.M32;
			result.M03 = a.M00 * b.M03 + a.M01 * b.M13 + a.M02 * b.M23 + a.M03 * b.M33;

			result.M10 = a.M10 * b.M00 + a.M11 * b.M10 + a.M12 * b.M20 + a.M13 * b.M30;
			result.M11 = a.M10 * b.M01 + a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31;
			result.M12 = a.M10 * b.M02 + a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32;
			result.M13 = a.M10 * b.M03 + a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33;

			result.M20 = a.M20 * b.M00 + a.M21 * b.M10 + a.M22 * b.M20 + a.M23 * b.M30;
			result.M21 = a.M20 * b.M01 + a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31;
			result.M22 = a.M20 * b.M02 + a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32;
			result.M23 = a.M20 * b.M03 + a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33;

			result.M30 = a.M30 * b.M00 + a.M31 * b.M10 + a.M32 * b.M20 + a.M33 * b.M30;
			result.M31 = a.M30 * b.M01 + a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31;
			result.M32 = a.M30 * b.M02 + a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32;
			result.M33 = a.M30 * b.M03 + a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33;

			return result;
		}


		public static Vector3 operator *(Matrix4 mat, Vector3 vec)
		{
			Vector3 result;

			float inv = 1.0f / (mat.M30 + mat.M31 + mat.M32 + mat.M33);
			result.X = inv * (mat.M00 * vec.X + mat.M01 * vec.Y + mat.M02 * vec.Z + mat.M03);
			result.Y = inv * (mat.M10 * vec.X + mat.M11 * vec.Y + mat.M12 * vec.Z + mat.M13);
			result.Z = inv * (mat.M20 * vec.X + mat.M21 * vec.Y + mat.M22 * vec.Z + mat.M23);

			return result;
		}


		public static Matrix4 Identity
		{
			get { return identity; }
		}


		public static Matrix4 Projection(float fov, float aspect, float close, float distant)
		{
			Matrix4 result = Matrix4.Zero;
			
			float ty = fov * 0.5f;
			float tty = (float)Math.Tan(ty);

			float w = 1.0f / tty / aspect;
			float h = 1.0f / tty;
			float q = -(distant + close) / (distant - close);
			float n = -2.0f * (distant * close) / (distant - close);

			result.M00 = w;
			result.M11 = h;
			result.M22 = q;
			result.M23 = n;
			result.M32 = -1.0f;

			return result;
		}


		public static Matrix4 FromAxes(Vector3 x, Vector3 y, Vector3 z)
		{
			Matrix4 result;
			result.M00 = x.X;
			result.M10 = x.Y;
			result.M20 = x.Z;
			result.M30 = 0.0f;
			result.M01 = y.X;
			result.M11 = y.Y;
			result.M21 = y.Z;
			result.M31 = 0.0f;
			result.M02 = z.X;
			result.M12 = z.Y;
			result.M22 = z.Z;
			result.M32 = 0.0f;
			result.M03 = 0.0f;
			result.M13 = 0.0f;
			result.M23 = 0.0f;
			result.M33 = 1.0f;
			return result;
		}


		public static Matrix4 FromQuaternion(Quaternion quat)
		{
			float tx  = 2.0f * quat.X;
			float ty  = 2.0f * quat.Y;
			float tz  = 2.0f * quat.Z;
			float twx = tx * quat.W;
			float twy = ty * quat.W;
			float twz = tz * quat.W;
			float txx = tx * quat.X;
			float txy = ty * quat.X;
			float txz = tz * quat.X;
			float tyy = ty * quat.Y;
			float tyz = tz * quat.Y;
			float tzz = tz * quat.Z;

			Matrix4 result;
			result.M00 = 1.0f - (tyy + tzz);
			result.M01 = txy - twz;
			result.M02 = txz + twy;
			result.M03 = 0.0f;
			result.M10 = txy + twz;
			result.M11 = 1.0f - (txx + tzz);
			result.M12 = tyz - twx;
			result.M13 = 0.0f;
			result.M20 = txz - twy;
			result.M21 = tyz + twx;
			result.M22 = 1.0f - (txx + tyy);
			result.M23 = 0.0f;
			result.M30 = 0.0f;
			result.M31 = 0.0f;
			result.M32 = 0.0f;
			result.M33 = 1.0f;
			return result;
		}


		public void SetTranslation(float x, float y, float z)
		{
			M03 = x;
			M13 = y;
			M23 = z;
		}


		public static Matrix4 Translation(float x, float y, float z)
		{
			Matrix4 result = Matrix4.Identity;
			result.M03 = x;
			result.M13 = y;
			result.M23 = z;
			return result;
		}


		public static Matrix4 Translation(Vector3 vec)
		{
			Matrix4 result = Matrix4.Identity;
			result.M03 = vec.X;
			result.M13 = vec.Y;
			result.M23 = vec.Z;
			return result;
		}


		public static Matrix4 Zero
		{
			get { return zero; }
		}
	}
}
