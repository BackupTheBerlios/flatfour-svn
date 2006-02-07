#region BSD License
/* FlatFour.Platform.Tests - Test_PlatformSystem.cs
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
using NUnit.Framework;
using GameGuts;

namespace FlatFour.Platform.Tests
{
	#region TestTraceListener
	
	/* A custom TraceListener to intercept messages written to the log */
	public class TestTraceListener : TraceListener, IDisposable
	{
		private string _buffer;

		public TestTraceListener()
		{
			Trace.Listeners.Add(this);
			_buffer = String.Empty;
		}

		void System.IDisposable.Dispose()
		{
			Trace.Listeners.Remove(this);
			base.Dispose(true);
		}


		public bool Contains(string message)
		{
			return (_buffer.IndexOf(message) > 0);
		}


		public override void Write(string message)
		{
			_buffer += message;
		}

		public override void WriteLine(string message)
		{
			_buffer += message + "\n";
		}


		public override string ToString()
		{
			return _buffer;
		}
	}
	
	#endregion

	[TestFixture]
	public class Test_PlatformSystem
	{
		[Test]
		public void CanConnectAndDisconnectCleanly()
		{
			PlatformSystem.EnsureReady();
			Framework.Connect();
			Framework.Disconnect();
		}

		[Test]
		[ExpectedException(typeof(FrameworkException))]
		public void CanCatchToolkitMemoryLeaks()
		{
			IntPtr ptr = IntPtr.Zero;
			try
			{
				Toolkit.LoggingEnabled = false;
				PlatformSystem.EnsureReady();
				Framework.Connect();
				ptr = Toolkit.utAlloc(4, null, 0);
				Framework.Disconnect();
			}
			finally
			{
				Toolkit.utFree(ptr, null, 0);
				Toolkit.LoggingEnabled = true;
			}
		}

		[Test]
		public void ToolkitLoggingWorks()
		{
			using (TestTraceListener log = new TestTraceListener())
			{
				PlatformSystem.EnsureReady();
				Framework.Disconnect();
				Framework.Connect();
				Assert.IsTrue(log.Contains("GameGuts Toolkit"), "Toolkit connection messages missing from trace log");
			}
		}

	}
}
