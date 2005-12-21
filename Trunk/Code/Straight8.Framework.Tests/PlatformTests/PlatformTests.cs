#region BSD License
/* Straight8.Framework Tests - PlatformTests.cs
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
using NUnit.Framework;
using Straight8.Framework;
using Sim8.GameGuts;

namespace Straight8.Framework.Tests.PlatformTests
{
	[TestFixture]
	public class PlatformTests
	{
		[Test]
		public void ConnectAndDisconnectWork()
		{
			Platform.Connect();
			Platform.Disconnect();
		}


		[Test]
		public void ToolkitLoggingWorks()
		{
			using (TestTraceListener log = new TestTraceListener())
			{
				Platform.Connect();
				Platform.Disconnect();
				Assert.IsTrue(log.Contains("GameGuts Toolkit"), "Toolkit connection messages missing from trace log");
			}
		}


		[Test]
		[ExpectedException(typeof(FrameworkException))]
		public void PlatformCatchesToolkitMemoryLeaks()
		{
			IntPtr ptr = IntPtr.Zero;
			try
			{
				Sim8.GameGuts.Toolkit.LoggingEnabled = false;
				Platform.Connect();
				ptr = Toolkit.utAlloc(4, null, 0);
				Platform.Disconnect();
			}
			finally
			{
				Toolkit.utFree(ptr, null, 0);
				Sim8.GameGuts.Toolkit.LoggingEnabled = true;
			}
		}
	}
}
