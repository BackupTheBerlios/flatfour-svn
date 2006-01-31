#region BSD License
/* Straight8.Framework - Graphics.cs
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
	public class Graphics
	{
		public static void BeginFrame()
		{
			if (!Toolkit.utBeginFrame())
				throw new FrameworkException();
		}

		public static void Clear(float red, float green, float blue, float alpha)
		{
			if (!Toolkit.utClear(red, green, blue, alpha))
				throw new FrameworkException();
		}

		public static void Draw(VertexBuffer vertices, VertexFormat format, IndexBuffer indices)
		{
			if (!Toolkit.utDraw(vertices.Handle, format.Handle, indices.Handle, 0, indices.Length))
				throw new FrameworkException();
		}

		public static void EndFrame()
		{
			if (!Toolkit.utEndFrame())
				throw new FrameworkException();
		}

		public static void SetMatrix(GraphicsMatrix which, Matrix4 matrix)
		{
			if (!Toolkit.utSetRenderMatrix((Toolkit.utRenderMatrix)which, ref matrix.M00))
				throw new FrameworkException();
		}

		public static void SetTexture(int stage, Texture texture)
		{
			if (!Toolkit.utSetTexture(stage, texture.Handle))
				throw new FrameworkException();
		}

		public static void Swap()
		{
			if (!Toolkit.utSwapAllRenderTargets())
				throw new FrameworkException();
		}
	}
}
