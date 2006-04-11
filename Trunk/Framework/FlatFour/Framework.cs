#region BSD License
/* FlatFour - Framework.cs
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
using System.Reflection;

namespace FlatFour
{
	/// <summary>
	///  The Framework class acts as a static singleton providing access to all
	///  of the components and subsystems that make up the current environment.
	/// </summary>
	public static class Framework
	{
		/* Subsystem management */
		private static bool _connected;
		private static EventHandler _startup;
		private static EventHandler _shutdown;

		/* Time management */
		private static Stopwatch _clock;
		private static double _fixedTotal;
		private static float _fixedInterval;
		private static float _maxInterval;
		private static EventHandler _fixedUpdate;
		private static EventHandler _frameUpdate;

		static Framework()
		{
			_connected = true;

			_clock = new Stopwatch();
			_fixedInterval = 0.01f;
			_maxInterval = 0.25f;

			/* Ensure that Disconnect() is always called before app exit */
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
		}

		#region Subsystem Startup & Shutdown

		/* Initialize all subsystems. The system defaults to a connected state,
		 * so you only need to call this if you disconnect. */
		public static void Connect()
		{
			if (!_connected)
			{
				Trace.WriteLine("Connecting Framework");

				_connected = true;
				
				Startup(null, EventArgs.Empty);
			}
		}


		/* Shut down all subsystems */
		public static void Disconnect()
		{
			if (_connected)
			{
				_connected = false;
				Trace.WriteLine("Disconnecting Framework");

				/* Call subsystems in reverse order. If B depends on A, A will 
				 * still be connected when B is shutdown */
				if (_shutdown != null)
				{
					object[] args = new object[] { null, EventArgs.Empty };
					Delegate[] delegates = _shutdown.GetInvocationList();
					for (int i = delegates.Length - 1; i >= 0; --i)
					{
						try
						{
							delegates[i].DynamicInvoke(args);
						}
						catch (System.Reflection.TargetInvocationException ex)
						{
							throw ex.InnerException;
						}
					}
				}
			}
		}


		/* Drop all subsystems and start again. Used for unit testing */
		internal static void ResetSubsystems()
		{
			_startup = null;
			_shutdown = null;
			_connected = true;
			Clock.Reset();
			_fixedTotal = 0.0;
		}


		/* Event fired when framework is connected; also called immediately
		 * at the time of registration */
		public static EventHandler Startup
		{
			get 
			{ 
				return _startup; 
			}
			set
			{
				_startup = value;

				/* Call the delegate that was just added to the end of the list */
				if (_connected)
				{
					object[] args = new object[] { null, EventArgs.Empty };
					Delegate[] delegates = _startup.GetInvocationList();
					delegates[delegates.Length - 1].DynamicInvoke(args);
				}
			}
		}


		/* Event called when the framework is disconnected */
		public static EventHandler Shutdown
		{
			get { return _shutdown; }
			set { _shutdown = value; }
		}

		/* Called when the AppDomain exists; cleans up */
		private static void OnProcessExit(object sender, EventArgs e)
		{
			Disconnect();
		}

		#endregion

		#region Stepping & Time Management

		/* The internal clock; tracks world time */
		public static Stopwatch Clock
		{
			get { return _clock; }
		}

		/* The time elapsed since the last fixed update */
		public static float FixedInterval
		{
			get { return _fixedInterval; }
			set { _fixedInterval = value; }
		}

		/* The time elapsed since the last frame update */
		public static float FrameInterval
		{
			get { return Clock.Elapsed; }
		}

		/* A cap on the amount of time that can elapse between steps;
		 * used to prevent things from exploding while debugging */
		public static float MaxInterval
		{
			get { return _maxInterval; }
			set { _maxInterval = value; }
		}

		/* Event that is called repeatedly at the fixed interval rate */
		public static EventHandler FixedUpdate
		{
			get { return _fixedUpdate; }
			set { _fixedUpdate = value; }
		}

		/* Event that is called once per frame */
		public static EventHandler FrameUpdate
		{
			get { return _frameUpdate; }
			set { _frameUpdate = value; }
		}

		/* Advance all systems to the current time */
		public static void Tick()
		{
			/* Calculate the time elapsed since the last step */
			if (!Clock.IsStarted)
				Clock.Start();
			else
				Clock.MarkInterval();

			/* Make sure I haven't run over the maximum step size */
			float delta = Clock.Elapsed - _maxInterval;
			if (delta > 0.0f)
			{
				Clock.Elapsed = delta;
				_fixedTotal += delta;
			}

			/* Run fixed updates to catch up with current time */
			if (FixedUpdate != null)
			{
				while (_fixedTotal < Clock.Total)
				{
					FixedUpdate(null, EventArgs.Empty);
					_fixedTotal += _fixedInterval;
				}
			}
			
			/* Send queued visualizations to the renderer for the next frame */
			Visualization.Swap();

			/* Run a frame update */
			if (FrameUpdate != null)
				FrameUpdate(null, EventArgs.Empty);
		}

		#endregion


		public static object CreateInstance(string typeName)
		{
			/* Split into namespace and type names */
			int split = typeName.LastIndexOf('.');
			if (split <= 0)
				throw new ArgumentException("Must specify a namespace");

			string assembly = typeName.Substring(0, split);
			return CreateInstance(assembly, typeName);
		}


		private static object CreateInstance(string assemblyName, string typeName)
		{
			try
			{
				Assembly assembly = Assembly.Load(assemblyName);
				Type type = assembly.GetType(typeName);
				if (type != null)
					return Activator.CreateInstance(type);
			}
			catch (System.IO.FileNotFoundException ex)
			{
				/* See if I can break this assembly name down further */
				if (assemblyName.IndexOf('.') < 0)
					throw ex;
			}

			/* Not found...trim off last bit of namespace and try again */
			int split = assemblyName.LastIndexOf('.');
			if (split <= 0)
				throw new TypeLoadException("Type " + typeName + " not found");

			assemblyName = assemblyName.Substring(0, split);
			return CreateInstance(assemblyName, typeName);
		}
	}
}
