#region BSD License
/* FlatFour.Dynamics - DynamicsSystem.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using OpenDE;

namespace FlatFour.Dynamics
{
	public class DynamicsSystem
	{
		private static IntPtr _world;
		private static IntPtr _contacts;

		#region Setup and Shutdown

		static DynamicsSystem()
		{
			Framework.Startup += new EventHandler(OnStartup);
			Framework.Shutdown += new EventHandler(OnShutdown);
			Framework.FixedUpdate += new EventHandler(OnTick);
		}

		/* Stub used by other subsystems that depend on this one to force it 
		 * to call its static constructor and initialize */
		public static void EnsureReady()
		{
		}

		private static void OnStartup(object sender, EventArgs e)
		{
			Trace.WriteLine("Starting dynamics subsystem");
			_world = d.WorldCreate();
			_contacts = d.JointGroupCreate(0);
			CreateObjectList();
			Trace.WriteLine("Dynamics subsystem started");
		}


		private static void OnShutdown(object sender, EventArgs e)
		{
			Trace.WriteLine("Stopping dynamics subsystem");
			DisposeObjectList();
			if (_world != IntPtr.Zero)
			{
				d.JointGroupDestroy(_contacts);
				d.WorldDestroy(_world);
				_world = IntPtr.Zero;
			}
			Trace.WriteLine("Dynamics subsystem stopped");
		}

		#endregion

		#region Object Management

		private static List<RigidBody> _objects;

		private static void CreateObjectList()
		{
			_objects = new List<RigidBody>();
		}

		private static void DisposeObjectList()
		{
			while (_objects.Count > 0)
				_objects[0].Dispose();
			_objects.Clear();
		}

		internal static List<RigidBody> Objects
		{
			get { return _objects; }
		}

		private static void ReloadObjects()
		{
			foreach (RigidBody obj in _objects)
				obj.Reload();
		}

		#endregion

		public static void SetGravity(float x, float y, float z)
		{
			d.WorldSetGravity(_world, x, y, z);
		}


		internal static IntPtr Handle
		{
			get { return _world; }
		}

		private static void OnTick(object sender, EventArgs e)
		{
			d.WorldStep(_world, Framework.FixedInterval);
			d.JointGroupEmpty(_contacts);
			ReloadObjects();
		}
	}
}
