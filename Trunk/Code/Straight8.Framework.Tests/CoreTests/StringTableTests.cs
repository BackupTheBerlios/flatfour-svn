#region BSD License
/* Straight8.Framework Tests - StringTableTests.cs
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
using NUnit.Framework;
using Straight8.Framework;

namespace Straight8.Framework.Tests.CoreTests
{
	[TestFixture]
	public class StringTableTests
	{
		[Test]
		public void CanGetExistingString()
		{
			string result = T.Get("My Test String");
			Assert.AreEqual("OK", result);
		}

		[Test]
		public void ReturnSameStringIfNotFound()
		{
			string result = T.Get("Missing");
			Assert.AreEqual("Missing", result);
		}
	}
}
