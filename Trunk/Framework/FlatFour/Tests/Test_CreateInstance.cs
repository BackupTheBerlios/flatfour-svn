#region BSD License
/* FlatFour.Tests - Test_CreateInstance.cs
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
	public class Test_CreateInstance
	{
		[Test]
		public void CreateFromFrameworkAssembly()
		{
			Pose instance = (Pose)Framework.CreateInstance("FlatFour.Pose");
			Assert.IsNotNull(instance, "Object not instantiated");
		}

		[Test]
		public void CreateFromExternalAssembly()
		{
			object instance = Framework.CreateInstance("FlatFour.Graphics.Camera");
			Assert.IsNotNull(instance, "Object not instantiated");
			Assert.AreEqual("FlatFour.Graphics.Camera", instance.GetType().ToString());
		}

		[Test]
		public void FindAssemblyWhenSubsetOfNamespace()
		{
			object instance = Framework.CreateInstance("FlatFour.Tests.Test_CreateInstance");
			Assert.IsNotNull(instance, "Object not instantiated");
			Assert.AreEqual("FlatFour.Tests.Test_CreateInstance", instance.GetType().ToString());
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void ExceptionIfNoNamespace()
		{
			object instance = Framework.CreateInstance("NoSuchClass");
		}

		[Test]
		[ExpectedException(typeof(System.IO.FileNotFoundException))]
		public void ExceptionIfAssemblyNotFound()
		{
			object instance = Framework.CreateInstance("NoSuchAssembly.NoSuchClass");
		}


		[Test]
		[ExpectedException(typeof(TypeLoadException))]
		public void ExceptionIfTypeNotFound()
		{
			object instance = Framework.CreateInstance("FlatFour.NoSuchClass");
		}
	}
}
