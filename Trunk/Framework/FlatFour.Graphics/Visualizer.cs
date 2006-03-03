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
		private List<Position> _lines = new List<Position>();
		private List<Position> _points = new List<Position>();

		public void DrawLine(Position p0, Position p1)
		{
			_lines.Add(p0);
			_lines.Add(p1);
		}

		public void DrawPoint(Position p)
		{
			_points.Add(p);
		}


		/* Called by GraphicsSystem when it is time to draw the queued list */
		public void Flush(Camera camera)
		{
			/* Turn off lighting and texturing which will change the color
			 * of the visualization lines */
			GraphicsSystem.Lighting = false;
			GraphicsSystem.Texture = null;

			if (_points.Count > 0)
			{
				Vector3[] verts = ConvertPointsToViewSpace(_points, camera);
				if (!Toolkit.utDrawPoints(ref verts[0].X, verts.Length))
					throw new FrameworkException();
			}

			if (_lines.Count > 0)
			{
				Vector3[] verts = ConvertPointsToViewSpace(_lines, camera);
				if (!Toolkit.utDrawLines(ref verts[0].X, verts.Length))
					throw new FrameworkException();
			}

			/* These will move down to Swap() once I code the double buffering */
			_points.Clear();
			_lines.Clear();
		}

		public void Swap()
		{
//			_points.Clear();
//			_lines.Clear();
		}


		/* Convert world space coordinates (doubles) to view space (floats) */
		private Vector3[] ConvertPointsToViewSpace(List<Position> points, Camera camera)
		{
			Vector3[] verts = new Vector3[points.Count];
			for (int i = 0; i < points.Count; ++i)
				verts[i] = points[i].Diff(camera.Position);
			return verts;
		}
	}
}
