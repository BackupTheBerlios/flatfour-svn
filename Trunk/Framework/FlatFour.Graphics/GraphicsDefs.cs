#region BSD License
/* FlatFour.Graphics - GraphicsDefs.cs
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
	public enum GraphicsMatrix
	{
		Projection = Toolkit.utRenderMatrix.UT_MATRIX_PROJECTION,
		View       = Toolkit.utRenderMatrix.UT_MATRIX_VIEW,
		Model      = Toolkit.utRenderMatrix.UT_MATRIX_MODEL
	}

	public enum TextureFormat
	{
		RGB8 = Toolkit.utTextureFormat.UT_TEXTURE_RGB8,
		RGBA8 = Toolkit.utTextureFormat.UT_TEXTURE_RGBA8
	};


	public enum VertexAttribute
	{
		Position = Toolkit.utVertexAttribute.UT_VERTEX_POSITION,
		Normal   = Toolkit.utVertexAttribute.UT_VERTEX_NORMAL,
		Texture2 = Toolkit.utVertexAttribute.UT_VERTEX_TEXTURE2
	}
}
