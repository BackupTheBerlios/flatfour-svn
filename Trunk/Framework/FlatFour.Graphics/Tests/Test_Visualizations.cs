#region BSD License
/* FlatFour.Graphics.Tests - Test_Visualizations.cs
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

namespace FlatFour.Graphics.Tests
{
	[TestFixture]
	public class Test_Visualizations
	{
		GraphicsWindow _wnd;

		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			Framework.Connect();
			_wnd = new GraphicsWindow("", 128, 128);
		}

		[TearDown]
		public void Test_Teardown()
		{
			_wnd.Dispose();
			Framework.Disconnect();
		}

		#endregion

		[Test]
		public void CanDrawLines()
		{
			Position p0 = new Position(-1.5f, 0.0f, -1.0f);
			Position p1 = new Position( 1.5f, 0.0f, -1.0f);
			Visualization.DrawLine(p0, p1);

			GraphicsSystem.DrawFrame();
			Console.ReadLine();

			Bitmap image = _wnd.GrabScreen();
			Color color = image.GetPixel(63, 63);
			Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
		}
	}
}
