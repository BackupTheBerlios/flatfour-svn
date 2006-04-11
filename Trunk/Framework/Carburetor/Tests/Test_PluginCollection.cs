#region BSD License
/* Carburetor.Tests - Test_PluginManager.cs
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
using FlatFour.Editing;

namespace Carburetor.Tests
{
	[TestFixture]
	public class Test_PluginCollection
	{
		private PluginCollection _mgr;

		[SetUp]
		public void Setup()
		{
			_mgr = new PluginCollection();
		}

		[TearDown]
		public void Teardown()
		{
			_mgr.Dispose();
		}

		[Test]
		public void LoadsSystemPlugins()
		{
			_mgr.LoadEnabledPlugins();
			Assert.IsTrue(_mgr.IsLoaded("Carburetor.PluginManager.PluginManagerPlugin"));
		}
	}
}
