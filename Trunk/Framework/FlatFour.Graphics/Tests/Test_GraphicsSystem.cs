#region BSD License
/* FlatFour.Graphics.Tests - Test_GraphicsSystem.cs
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
	public class Test_GraphicsSystem
	{
		[Test]
		public void CanConnectAndDisconnectCleanly()
		{
			GraphicsSystem.EnsureReady();
			Framework.Disconnect();
			Framework.Connect();
		}

		[Test]
		public void OnTickClearsTargets()
		{
			using (GraphicsWindow wnd = new GraphicsWindow("Test", 128, 128))
			{
				wnd.Camera.BackgroundColor = Color.White;
				GraphicsSystem.DrawFrame();

				Bitmap image = wnd.GrabScreen();
				Color color = image.GetPixel(1, 1);
				Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
			}
		}
	}
}
