#region BSD License
/* FlatFour.Platform.Tests - Test_PlatformSystem.cs
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

namespace FlatFour.Platform.Tests
{
	[TestFixture]
	public class Test_PlatformSystem
	{
		[Test]
		public void CanConnectAndDisconnectCleanly()
		{
			PlatformSystem.EnsureReady();
			Framework.Connect();
			Framework.Disconnect();
		}
	}
}