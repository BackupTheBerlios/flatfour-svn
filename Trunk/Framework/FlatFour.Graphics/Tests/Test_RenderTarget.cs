#region BSD License
/* FlatFour.Graphics.Tests - Test_RenderTarget.cs
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
	public class Test_RenderTarget
	{
		private GraphicsWindow _wnd;

		[SetUp]
		public void Test_Setup()
		{
			_wnd = new GraphicsWindow("Test", 128, 128);
		}

		[TearDown]
		public void Test_Teardown()
		{
			_wnd.Dispose();
		}

		[Test]
		public void CreatesDefaultCamera()
		{
			Assert.IsNotNull(_wnd.Camera, "No default camera");
		}
	}
}
