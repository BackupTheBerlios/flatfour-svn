#region BSD License
/* FlatFour.Graphics.Tests - Test_BasicDrawing.cs
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
	public class Test_BasicDrawing
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
		public void CanClearAndSwap()
		{
			_wnd.Camera.BackgroundColor = Color.White;
			GraphicsSystem.DrawFrame(_wnd);

			Bitmap image = _wnd.GrabScreen();
			Color color = image.GetPixel(1, 1);
			Assert.AreEqual(Color.FromArgb(0xff, 0xff, 0xff, 0xff), color);
		}

		[Test]
		public void CanDrawSquare()
		{
			VertexBuffer vbuf = new VertexBuffer(Test_VertexBuffer.CUBE_VERTICES.Length);
			vbuf.CopyData(Test_VertexBuffer.CUBE_VERTICES);

			IndexBuffer ibuf = new IndexBuffer(Test_IndexBuffer.CUBE_INDICES.Length);
			ibuf.CopyData(Test_IndexBuffer.CUBE_INDICES);

			VertexFormat vfmt = new VertexFormat(Test_VertexFormat.CUBE_ATTRIBUTES);

			GraphicsSystem.BeginFrame();
			GraphicsSystem.Clear(0.0f, 0.0f, 0.0f, 0.0f);
			GraphicsSystem.Draw(vbuf, vfmt, ibuf);
			GraphicsSystem.EndFrame();
			GraphicsSystem.Swap();

			Bitmap image = _wnd.GrabScreen();
			Assert.IsTrue(0 == image.GetPixel(30,30).R, "Square is larger than expected");
			Assert.IsTrue(0 < image.GetPixel(48,48).R, "Square was not rendered");
		}
	}
}
