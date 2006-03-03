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
		private List<Vector3> _lines = new List<Vector3>();

		public void DrawLine(Vector3 p0, Vector3 p1)
		{
			_lines.Add(p0);
			_lines.Add(p1);
		}

		public void Flush()
		{
			/* Turn off lighting and texturing which will change the color
			 * of the visualization lines */
			GraphicsSystem.Lighting = false;
			GraphicsSystem.Texture = null;

			/* Do I really need to convert to an array? I can't figure out
			 * how to make C# give me the address of the first item */
			if (_lines.Count > 0)
			{
				Vector3[] verts = _lines.ToArray();
				if (!Toolkit.utDrawLines(ref verts[0].X, verts.Length))
					throw new FrameworkException();
			}
		}
	}
}
