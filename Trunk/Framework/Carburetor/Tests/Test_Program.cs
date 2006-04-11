#region BSD License
/* Carburetor.Tests - Test_Program.cs
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
using FlatFour;
using FlatFour.Editing;

namespace Carburetor.Tests
{
	[TestFixture]
	public class Test_Program
	{
		[Test]
		public void UISetAndCleared()
		{
			using (Program program = new Program())
				Assert.IsNotNull(Editor.UI);
			Assert.IsNull(Editor.UI);
		}

		[Test]
		public void PluginsSetAndCleared()
		{
			using (Program program = new Program())
				Assert.IsNotNull(Editor.Plugins);
			Assert.IsNull(Editor.Plugins);
		}

		[Test]
		public void PluginsLoadedAndDisposed()
		{
			using (Program program = new Program())
				Assert.IsTrue(Editor.Plugins.Count > 0);
		}
	}
}
