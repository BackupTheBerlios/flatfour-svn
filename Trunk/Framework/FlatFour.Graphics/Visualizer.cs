#region BSD License
/* FlatFour.Graphics - Visualizer.cs
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
using System.Diagnostics;
using System.Collections.Generic;
using GameGuts;

namespace FlatFour.Graphics
{
	class Visualizer : IVisualizer
	{
		private List<float> _lines = new List<float>();

		public void DrawLine(Vector3 p0, Vector3 p1)
		{
			_lines.Add(p0.X);
			_lines.Add(p0.Y);
			_lines.Add(p0.Z);
			_lines.Add(p1.X);
			_lines.Add(p1.Y);
			_lines.Add(p1.Z);
		}

		public void Flush()
		{
			/* Turn off lighting and texturing which will change the color
			 * of the visualization lines */
			GraphicsSystem.Lighting = false;
			GraphicsSystem.Texture = null;

			float[] verts = _lines.ToArray();
			if (!Toolkit.utDrawLines(verts, _lines.Count / 2))
				throw new FrameworkException();
		}
	}
}
