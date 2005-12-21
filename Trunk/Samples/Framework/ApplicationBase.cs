#region BSD License
/* Straight8.Framework Samples - ApplicationBase.cs
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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Straight8.Framework;

namespace Samples.Framework
{
	/* This is a sample base class for a Flat Four application. It demonstrates
	 * the basics of connecting to the engine and running the event loop. */
	public abstract class ApplicationBase : IDisposable
	{
		/* You must provide implementations for these methods in your class */
		public abstract void Setup();
		public abstract void Dispose();
		public abstract void Input(InputEventArgs args);
		public abstract void Tick();

		public static void Run(ApplicationBase app)
		{
			/* Create a log file for this application */
			OpenLogFile();

			/* In a real application you would want to catch exceptions here
			 * and exit gracefully. I've left the catch block out here to 
			 * make it easier to debug for now */
			try
			{
				Sim8.GameGuts.Toolkit.utEnableMemoryDebugging();
				Platform.Connect();
				app.Setup();

				/* Event Loop */
				Platform.Input += new Platform.InputHandler(app.Input);
				Platform.Tick += new Platform.TickHandler(app.Tick);
				Platform.EventLoop();
			}
#if !DEBUG
			catch (Exception ex)
			{
				Trace.WriteLine("An unhandled exception was caught: " + ex.ToString());
			}
#endif
			finally
			{
			}

			/* Cleanup should always occur, which is why I placed it outside of
			 * the try block above. This code could also throw exceptions, which
			 * is why I didn't put it in the finally block */
			try
			{
				app.Dispose();
				Platform.Disconnect();
				Sim8.GameGuts.Toolkit.utShowMemoryReport();
			}
			finally
			{
				CloseLogFile();
			}
		}

		#region Log File Handling

		private static TraceListener _listener;

		private static void OpenLogFile()
		{
			/* Grab some useful information about the application */
			Assembly assembly = Assembly.GetEntryAssembly();
			AssemblyName assemblyName = assembly.GetName();
			string name = assemblyName.Name;
			Version version = assemblyName.Version;

			/* Open a log file */
			StreamWriter writer = new StreamWriter(name + ".log", false);

			/* Route all trace messages to the log file */
			_listener = new TextWriterTraceListener(writer, "LoggingListener");
			Trace.Listeners.Add(_listener);
			Trace.WriteLine(name + " " + version + " started at " + DateTime.Now);
		}

		private static void CloseLogFile()
		{
			Trace.WriteLine("Exiting application at " + DateTime.Now);
			Trace.Flush();
			Trace.Listeners.Remove(_listener);
			_listener.Close();
		}
	
		#endregion
		}
}
