#region BSD License
/* FlatFour - Pose.cs
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

namespace FlatFour
{
	public class Pose
	{
		public Position Position;
		public Quaternion Orientation;

		public Pose()
		{
			Position = Position.Zero;
			Orientation = Quaternion.Identity;
		}
	}
}
