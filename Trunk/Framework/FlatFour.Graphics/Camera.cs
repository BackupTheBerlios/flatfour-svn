#region BSD License
/* FlatFour.Graphics - Camera.cs
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
using System.Drawing;

namespace FlatFour.Graphics
{
	public class Camera : Behavior
	{
		public Color BackgroundColor;
		public Position Position;
		public Position Target;

		public Camera()
		{
			BackgroundColor = Color.Black;
		}

		/* Called by GraphicsSystem at the start of a new frame */
		internal void ApplySettings(RenderTarget target)
		{
			Size size = target.Size;
			float aspect = (float)size.Width / (float)size.Height;
			GraphicsSystem.ProjectionMatrix = Matrix4.Projection(1.0f, aspect, 0.1f, 100.0f);

			GraphicsSystem.Clear(BackgroundColor);
		}
	}
}
