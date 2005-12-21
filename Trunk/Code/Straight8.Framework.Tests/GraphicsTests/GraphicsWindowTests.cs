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
		private GraphicsWindow _wnd;

		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			Platform.Connect();
			_wnd = new GraphicsWindow("", 128, 128);
		}

		[TearDown]
		public void Test_Teardown()
		{
			_wnd.Dispose();
			Platform.Disconnect();
		}
		
		#endregion

		#region Creation Tests

		[Test]
		public void CanCreateWindow()
		{
			Assert.IsNotNull(_wnd);
		}

		[Test]
		public void CanAttachToExistingWindow()
		{
			IntPtr wnd = Toolkit.utCreateWindow("", 10, 10);
			using (GraphicsWindow gfx = new GraphicsWindow(Toolkit.utGetWindowHandle(wnd)))
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
			_wnd.ResizeTo(200, 100);
			Assert.AreEqual(200, _wnd.Width);
			Assert.AreEqual(100, _wnd.Height);
		}


		[Test]
		public void GetRealSizeOnCreate()
		{
			/* Try to create a too-small window and make sure I pick up 
			 * larger size actually provided by the OS */
			using (GraphicsWindow gfx = new GraphicsWindow("", 1, 1))
			{
				Assert.IsTrue(gfx.Width > 1, "GraphicsWindow is not getting post-create size");
			}
		}

		#endregion

		#region Render Target Tests

		[Test]
		public void CanClearAndSwap()
		{
			Graphics.BeginFrame();
			Graphics.Clear(1.0f, 1.0f, 1.0f, 1.0f);
			Graphics.EndFrame();
			Graphics.Swap();

			Bitmap image = _wnd.GrabScreen();
			Color color = image.GetPixel(1, 1);
			Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
		}

		[Test]
		public void GraphicsResizeWithWindow()
		{
			_wnd.ResizeTo(256, 128);

			Graphics.BeginFrame();
			Graphics.Clear(1.0f, 1.0f, 1.0f, 1.0f);
			Graphics.EndFrame();
			Graphics.Swap();

			Bitmap image = _wnd.GrabScreen();
			Color color = image.GetPixel(250, 1);
			Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
		}

		#endregion
	}
}
