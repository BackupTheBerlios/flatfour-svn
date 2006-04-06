#region BSD License
/* FlatFour.Editor - Controller.cs
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

namespace FlatFour.Editor
{
	public class Controller
	{
		/// <summary>
		///  Add a new actor to the world.
		/// </summary>
		/// <remarks>
		///  This returns an Actor to the view, which is technically a business
		///  object. I don't think it makes sense to have a specific view-only
		///  proxy in this case though.
		/// </remarks>
		public virtual Actor NewActor()
		{
			Actor actor = new Actor();
			return actor;
		}
	}
}
