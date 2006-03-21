#region BSD License
/* FlatFour.Tests - Test_Scene.cs
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
using NUnit.Framework;

namespace FlatFour.Tests
{
	[TestFixture]
	public class Test_Scene
	{
		[Test]
		public void SetsSceneRef()
		{
			Scene s = new Scene();
			Actor a = new Actor();
			s.Add(a);
			Assert.AreSame(s, a.Scene);
		}
	}
}
