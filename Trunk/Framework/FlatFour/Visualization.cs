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

namespace FlatFour
{
	public class Visualization
	{
		private static IVisualizer _visualizer;

		public static void DrawLine(Vector3 p0, Vector3 p1)
		{
			if (_visualizer != null)
				_visualizer.DrawLine(p0, p1);
		}

		public static IVisualizer Visualizer
		{
			get { return _visualizer; }
			set { _visualizer = value; }
		}
	}
}
