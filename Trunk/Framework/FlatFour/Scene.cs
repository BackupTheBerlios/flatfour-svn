#region BSD License
/* FlatFour - Scene.cs
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
using System.Collections.ObjectModel;

namespace FlatFour
{
	public class Scene : Collection<Actor>
	{
		public void Dispatch(Message message)
		{
			/* Stupid, brute force approach for now */
			foreach (Actor actor in this)
			{
				message.Notify(actor);
			}
		}


		protected override void InsertItem(int index, Actor item)
		{
			base.InsertItem(index, item);
			item.Scene = this;
		}


		protected override void RemoveItem(int index)
		{
			Actor item = this[index];
			base.RemoveItem(index);
			item.Scene = null;
		}
	}
}
