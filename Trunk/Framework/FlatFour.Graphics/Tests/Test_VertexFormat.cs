#region BSD License
/* FlatFour.Graphics.Tests - Test_VertexFormat.cs
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
	public class VertexFormatTests
	{
		public static readonly VertexAttribute[] CUBE_ATTRIBUTES = 
			{
				VertexAttribute.Position,
				VertexAttribute.Normal
			};

		private VertexFormat _fmt;

		#region Setup and Teardown

		[SetUp]
		public void Test_Setup()
		{
			GraphicsSystem.EnsureReady();
			Framework.Connect();
			_fmt = new VertexFormat(CUBE_ATTRIBUTES);
		}

		[TearDown]
		public void Test_Teardown()
		{
			_fmt.Dispose();
			Framework.Disconnect();
		}
		
		#endregion

		[Test]
		public void CanCreate()
		{
			Assert.IsNotNull(_fmt);
		}
	}
}
