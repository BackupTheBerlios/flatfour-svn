#region BSD License
/* FlatFour.Tests - Test_Actor.cs
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
	public class Test_Actor
	{
		private class MyBehavior : Behavior { }
		private class MyPose : Pose { }

		[Test]
		public void SetsActorRef()
		{
			Actor a = new Actor();
			MyBehavior b = new MyBehavior();
			a.Add(b);
			Assert.AreSame(a, b.Actor);
		}

		[Test]
		public void SetsPoseShortcut()
		{
			Actor a = new Actor();
			Pose p = new Pose();
			a.Add(p);
			Assert.AreSame(p, a.Pose);
		}

		[Test]
		public void SetsPoseShutcutFromSubclass()
		{
			Actor a = new Actor();
			MyPose p = new MyPose();
			a.Add(p);
			Assert.AreSame(p, a.Pose);
		}
	}
}
