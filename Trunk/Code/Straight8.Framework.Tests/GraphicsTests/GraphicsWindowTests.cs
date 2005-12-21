#region BSD License
/* Straight8.Framework Tests - GraphicsWindowTests.cs
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
using System.Drawing;
using NUnit.Framework;
using Sim8.GameGuts;

namespace Straight8.Framework.Tests.GraphicsTests
{
	[TestFixture]
	public class GraphicsWindowTests
	{
		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			Platform.Connect();
		}

		[TearDown]
		public void Test_Teardown()
		{
			Platform.Disconnect();
		}
		
		#endregion

		#region Creation Tests

		[Test]
		public void CanCreateWindow()
		{
			GraphicsWindow wnd = new GraphicsWindow("", 128, 128);			
			Assert.IsNotNull(wnd);
		}

		[Test]
		public void CanAttachToExistingWindow()
		{
			IntPtr wnd = Toolkit.utCreateWindow("", 16, 16);
			IntPtr hwnd = Toolkit.utGetWindowHandle(wnd);
			using (GraphicsWindow gfx = new GraphicsWindow(hwnd))
			{
				Assert.IsNotNull(gfx);
			}
			Toolkit.utDestroyWindow(wnd);
		}

		#endregion

		#region Size Tests

		[Test]
		public void CanResizeWindow()
		{
			GraphicsWindow wnd = new GraphicsWindow("", 128, 128);
			wnd.ResizeTo(200, 100);
			Assert.AreEqual(200, wnd.Width);
			Assert.AreEqual(100, wnd.Height);
		}

		[Test]
		public void GraphicsResizeWithWindow()
		{
			GraphicsWindow wnd = new GraphicsWindow("", 128, 128);
			wnd.ResizeTo(256, 128);

			Graphics.BeginFrame();
			Graphics.Clear(1.0f, 1.0f, 1.0f, 1.0f);
			Graphics.EndFrame();
			Graphics.Swap();

			Bitmap image = wnd.GrabScreen();
			Color color = image.GetPixel(250, 1);
			Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
		}

		#endregion

		#region Render Target Tests

		[Test]
		public void CanClearAndSwap()
		{
			GraphicsWindow wnd = new GraphicsWindow("", 128, 128);
			
			Graphics.BeginFrame();
			Graphics.Clear(1.0f, 1.0f, 1.0f, 1.0f);
			Graphics.EndFrame();
			Graphics.Swap();

			Bitmap image = wnd.GrabScreen();
			Color color = image.GetPixel(1, 1);
			Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
		}

		#endregion
	}
}
