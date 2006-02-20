#region BSD License
/* FlatFour.Graphics.Tests - Test_Camera.cs
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
	public class Test_Camera
	{
		[Test]
		public void BackgroundColorDefaultsToBlack()
		{
			Camera c = new Camera();
			Assert.AreEqual(Color.Black, c.BackgroundColor);
		}

		[Test]
		public void CanSetBackgroundColor()
		{
			Camera c = new Camera();
			c.BackgroundColor = Color.Firebrick;
			Assert.AreEqual(Color.Firebrick, c.BackgroundColor);
		}
	}
}
