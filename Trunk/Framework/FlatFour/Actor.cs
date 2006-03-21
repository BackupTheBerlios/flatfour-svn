#region BSD License
/* FlatFour - Actor.cs
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
	public class Actor : Collection<Behavior>
	{
		private Dispatcher<Message> _dispatcher;
		private Scene _scene;
		private Pose _pose;

		public Actor()
		{
			_dispatcher = new Dispatcher<Message>();
		}


		public Scene Scene
		{
			get { return _scene; }
			internal set { _scene = value; }
		}


		protected override void InsertItem(int index, Behavior item)
		{
			base.InsertItem(index, item);
			_dispatcher.Add(item);
			item.Actor = this;
			SetShortcut(item, item);
		}


		protected override void RemoveItem(int index)
		{
			Behavior item = this[index];
			_dispatcher.Remove(item);
			base.RemoveItem(index);
			item.Actor = null;
			SetShortcut(item, null);
		}


		internal void Dispatch(Message message)
		{
			_dispatcher.Dispatch(message);
		}


		#region Behavior Shortcuts

		private void SetShortcut(Behavior item, Behavior value)
		{
			if (typeof(Pose).IsInstanceOfType(item))
				_pose = (Pose)value;
		}

		public Pose Pose
		{
			get { return _pose; }
		}

		#endregion
	}
}
