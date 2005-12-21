#region BSD License
/* Straight8.Framework Tests - GraphicsCoreTests.cs
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

namespace Straight8.Framework.Tests.GraphicsTests
{
	[TestFixture]
	public class GraphicsCoreTests
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

		[Test]
		public void CanDrawSquare()
		{
			VertexBuffer vbuf = new VertexBuffer(VertexBufferTests.CUBE_VERTICES.Length);
			vbuf.CopyData(VertexBufferTests.CUBE_VERTICES);

			IndexBuffer ibuf = new IndexBuffer(IndexBufferTests.CUBE_INDICES.Length);
			ibuf.CopyData(IndexBufferTests.CUBE_INDICES);

			VertexFormat vfmt = new VertexFormat(VertexFormatTests.CUBE_ATTRIBUTES);

			Graphics.BeginFrame();
			Graphics.Clear(0.0f, 0.0f, 0.0f, 0.0f);
			Graphics.Draw(vbuf, vfmt, ibuf);
			Graphics.EndFrame();
			Graphics.Swap();

			Bitmap image = _wnd.GrabScreen();
			image.Save("/home/jason/Desktop/screenshot.bmp");
			Assert.IsTrue(0 == image.GetPixel(30,30).R, "Square is larger than expected");
			Assert.IsTrue(0 < image.GetPixel(48,48).R, "Square was not rendered");
		}
	}
}
