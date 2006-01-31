#region BSD License
/* Straight8.Framework.Tests - TestTraceListener.cs
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

namespace Straight8.Framework.Tests
{
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
}
