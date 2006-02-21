#region BSD License
/* FlatFour.Graphics.Tests - Test_GraphicsWindow.cs
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
using System.Windows.Forms;
using NUnit.Framework;

namespace FlatFour.Graphics.Tests
{
	[TestFixture]
	public class Test_GraphicsWindow
	{
		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			Framework.Connect();
		}

		[TearDown]
		public void Test_Teardown()
		{
			Framework.Disconnect();
		}

		#endregion

		[Test]
		public void CanCreateWindow()
		{
			using (GraphicsWindow wnd = new GraphicsWindow("Test Window", 128, 128))
			{
			}
		}

		[Test]
		public void RegistersWithSubsystem()
		{
			using (GraphicsWindow wnd = new GraphicsWindow("Test Window", 128, 128))
			{
				Assert.AreEqual(1, GraphicsSystem.RenderTarget.Count);
			}
			Assert.AreEqual(0, GraphicsSystem.RenderTarget.Count);
		}

		private class TestForm : Form
		{
		}

		[Test]
		public void CanUseSystemWindow()
		{
			using (TestForm form = new TestForm())
			{
				form.Text = "Test Form";
				form.Width = 256;
				form.Height = 256;
				form.Show();

				using (GraphicsWindow wnd = new GraphicsWindow(form.Handle))
				{
					wnd.Camera.BackgroundColor = Color.White;
					GraphicsSystem.DrawFrame();
					Bitmap image = wnd.GrabScreen();
					Color color = image.GetPixel(1, 1);
					Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
				}
			}
		}

		[Test]
		public void CanResizeWindow()
		{
			using (GraphicsWindow wnd = new GraphicsWindow("Test Window", 128, 128))
			{
				wnd.Camera.BackgroundColor = Color.White;
				wnd.Size = new Size(256, 256);

				GraphicsSystem.DrawFrame(wnd);
				Bitmap image = wnd.GrabScreen();
				Color color = image.GetPixel(250, 250);
				Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
			}
		}
	}
}
