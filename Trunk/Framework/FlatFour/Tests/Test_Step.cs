#region BSD License
/* FlatFour.Tests - Test_Step.cs
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
using System.Threading;
using NUnit.Framework;
using FlatFour;

namespace FlatFour.Tests
{
	[TestFixture]
	public class Test_Step
	{
		private int _fixedUpdates;
		private int _frameUpdates;

		private void OnFixedUpdate(object sender, EventArgs e)
		{
			_fixedUpdates++;
		}

		private void OnFrameUpdate(object sender, EventArgs e)
		{
			_frameUpdates++;
		}
		

		[SetUp]
		public void Test_Setup()
		{
			_fixedUpdates = 0;
			_frameUpdates = 0;
		}


		[Test]
		public void ClockStartsOnFirstStep()
		{
			Framework.Clock.Stop();
			Framework.Step();
			Assert.IsTrue(Framework.Clock.IsStarted);
		}


		[Test]
		public void StepDoesNotCallFixedUpdateOnZeroInterval()
		{
			Framework.FixedUpdate += new EventHandler(OnFixedUpdate);
			Framework.Clock.Reset();
			Framework.Step();
			Assert.AreEqual(0, _fixedUpdates, "Fixed update handler called on zero interval");
		}


		[Test]
		public void StepCallsFrameUpdate()
		{
			Framework.FrameUpdate += new EventHandler(OnFrameUpdate);
			Framework.Step();
			Assert.AreEqual(1, _frameUpdates, "Frame update handler not called");
		}
	}
}
