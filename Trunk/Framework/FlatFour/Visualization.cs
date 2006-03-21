#region BSD License
/* FlatFour - Visualization.cs
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
using System.Collections;
using System.Reflection;

namespace FlatFour
{
	public class Visualization
	{
		private static Dispatcher<Behavior> _visualizers;
		private static IVisualizer _renderer;

		static Visualization()
		{
			_visualizers = new Dispatcher<Behavior>();
		}


		/* Enable a visualization */
		public static void Add(string typename)
		{
			Visualization viz = (Visualization)Framework.CreateInstance(typename);
			_visualizers.Add(viz);
		}


		/* Draw visualizations for a particular actor */
		public static void Draw(Actor actor)
		{
			foreach (Behavior behavior in actor)
				_visualizers.Dispatch(behavior);
		}


		/* Returns true if at least one visualizer has been registered */
		public static bool IsEmpty
		{
			get { return (_visualizers.Count == 0); }
		}


		/* The implementation; what actually does the drawing */
		public static IVisualizer Renderer
		{
			get { return _renderer; }
			set { _renderer = value; }
		}


		/* Called by Framework after fixed updates are complete. Swaps the
		 * current list of visualizations for a new list so a new update can
		 * start while the old list is being rendered */
		internal static void Swap()
		{
			if (_renderer != null)
				_renderer.Swap();
		}

		#region Draw Methods

		/* Draw an axis-aligned box located at the origin */
		public static void DrawBox(Pose pose, float xLength, float yLength, float zLength)
		{
			float x2 = xLength / 2.0f;
			float y2 = yLength / 2.0f;
			float z2 = zLength / 2.0f;
			DrawBox(pose, Vector3.Create(-x2, -y2, -z2), Vector3.Create(x2, y2, z2));
		}


		/* Draw an axis-aligned box off the origin*/
		public static void DrawBox(Pose pose, Vector3 min, Vector3 max)
		{
			if (_renderer != null)
			{
				Position p0, p1, p2, p3, p4, p5, p6, p7;
				if (pose != null)
				{
					p0 = pose.Orientation * min + pose.Position;
					p1 = pose.Orientation * Vector3.Create(max.X, min.Y, min.Z) + pose.Position;
					p2 = pose.Orientation * Vector3.Create(max.X, max.Y, min.Z) + pose.Position;
					p3 = pose.Orientation * Vector3.Create(min.X, max.Y, min.Z) + pose.Position;
					p4 = pose.Orientation * Vector3.Create(min.X, min.Y, max.Z) + pose.Position;
					p5 = pose.Orientation * Vector3.Create(max.X, min.Y, max.Z) + pose.Position;
					p6 = pose.Orientation * max + pose.Position;
					p7 = pose.Orientation * Vector3.Create(min.X, max.Y, max.Z) + pose.Position;
				}
				else
				{
					p0 = Position.Create(min.X, min.Y, min.Z);
					p1 = Position.Create(max.X, min.Y, min.Z);
					p2 = Position.Create(max.X, max.Y, min.Z);
					p3 = Position.Create(min.X, max.Y, min.Z);
					p4 = Position.Create(min.X, min.Y, max.Z);
					p5 = Position.Create(max.X, min.Y, max.Z);
					p6 = Position.Create(max.X, max.Y, max.Z);
					p7 = Position.Create(min.X, max.Y, max.Z);
				}

				DrawLine(p0, p1);
				DrawLine(p1, p2);
				DrawLine(p2, p3);
				DrawLine(p3, p0);
				DrawLine(p1, p5);
				DrawLine(p5, p6);
				DrawLine(p6, p2);
				DrawLine(p5, p4);
				DrawLine(p4, p7);
				DrawLine(p7, p6);
				DrawLine(p4, p0);
				DrawLine(p7, p3);
			}
		}

		public static void DrawLine(double x0, double y0, double z0, double x1, double y1, double z1)
		{
			DrawLine(Position.Create(x0, y0, z0), Position.Create(x1, y1, z1));
		}

		public static void DrawLine(Position p0, Position p1)
		{
			if (_renderer != null)
				_renderer.DrawLine(p0, p1);
		}

		public static void DrawPoint(Pose pose, float x, float y, float z)
		{
			if (_renderer != null)
			{
				Position pos;
				if (pose != null)
					pos = pose.Orientation * Vector3.Create(x, y, z) + pose.Position;
				else
					pos = Position.Create(x, y, z);

				_renderer.DrawPoint(pos);
			}
		}

		#endregion
	}
}
