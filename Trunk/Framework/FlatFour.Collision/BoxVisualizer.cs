#region BSD License
/* FlatFour.Collision - BoxVisualizer.cs
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

namespace FlatFour.Collision
{
	public class BoxVisualizer : Visualization
	{
		public void Draw(BoxShape shape)
		{
			Vector3 lengths = shape.Lengths;
			DrawBox(shape.Actor.Pose, lengths.X, lengths.Y, lengths.Z);
		}
	}
}
