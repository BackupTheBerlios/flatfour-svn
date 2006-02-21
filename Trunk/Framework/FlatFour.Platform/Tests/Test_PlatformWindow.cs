#region BSD License
/* FlatFour.Platform.Tests - Test_PlatformWindow.cs
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
using System.Drawing;
using NUnit.Framework;

namespace FlatFour.Platform.Tests
{
	[TestFixture]
	public class Test_PlatformWindow
	{
		private int _callbackCount;

		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			Framework.Connect();
			_callbackCount = 0;
		}

		[TearDown]
		public void Test_Teardown()
		{
			Framework.Disconnect();
		}

		#endregion

		private void OnEventCallback(object sender, EventArgs e)
		{
			_callbackCount++;
		}


		[Test]
		public void CanCreateWindow()
		{
			using (PlatformWindow wnd = new PlatformWindow("Test Window", 128, 128))
			{
				Assert.IsNotNull(wnd);
			}
		}

		[Test]
		public void CanResize()
		{
			using (PlatformWindow wnd = new PlatformWindow("Test Window", 128, 128))
			{
				wnd.Size = new Size(200, 100);
				Assert.AreEqual(200, wnd.Width);
				Assert.AreEqual(100, wnd.Height);
			}
		}

		[Test]
		public void ResizeCallsEvent()
		{
			using (PlatformWindow wnd = new PlatformWindow("Test Window", 128, 128))
			{
				wnd.Resize += new EventHandler(OnEventCallback);
				wnd.Size = new Size(200, 100);
				Assert.AreEqual(1, _callbackCount);
			}
		}
	}
}
