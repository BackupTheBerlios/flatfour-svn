#region BSD License
/* Straight8.Framework Tests - IndexBufferTests.cs
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
	public class IndexBufferTests
	{
		public static readonly int[] CUBE_INDICES = 
			{
				0, 1, 2,
				0, 2, 3
			};

		private IndexBuffer _buf;

		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			Platform.Connect();
			//	_wnd = new GraphicsWindow("GraphicsWindow Tests", 128, 128);
			_buf = new IndexBuffer(CUBE_INDICES.Length);
		}

		[TearDown]
		public void Test_Teardown()
		{
			_buf.Dispose();
			//	_wnd.Dispose();
			Platform.Disconnect();
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
			_buf.CopyData(CUBE_INDICES);
		}
	}
}
