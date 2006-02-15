#region BSD License
/* FlatFour.Graphics.Tests - Test_VertexBuffer.cs
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
	public class VertexBufferTests
	{
		public static readonly float[] CUBE_VERTICES = 
			{
				-0.5f, -0.5f, 0.0f, 0.0f, 0.0f, 1.0f,
				 0.5f, -0.5f, 0.0f, 0.0f, 0.0f, 1.0f,
				 0.5f,  0.5f, 0.0f, 0.0f, 0.0f, 1.0f,
				-0.5f,  0.5f, 0.0f, 0.0f, 0.0f, 1.0f
			};

		private VertexBuffer _buf;

		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			GraphicsSystem.EnsureReady();
			Framework.Connect();
			_buf = new VertexBuffer(CUBE_VERTICES.Length);
		}

		[TearDown]
		public void Test_Teardown()
		{
			_buf.Dispose();
			Framework.Disconnect();
		}
		
		#endregion

		[Test]
		public void CanCreate()
		{
			Assert.IsNotNull(_buf);
		}

		[Test]
		public void CanCopyData()
		{
			_buf.CopyData(CUBE_VERTICES);
		}
	}
}
