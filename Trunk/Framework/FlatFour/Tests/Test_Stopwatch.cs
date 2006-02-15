#region BSD License
/* FlatFour.Tests - Test_Stopwatch.cs
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

namespace FlatFour.Tests
{
	[TestFixture]
	public class Test_Stopwatch
	{
		private Stopwatch _watch;

		[SetUp]
		public void Test_Setup()
		{
			_watch = new Stopwatch();
		}

		[Test]
		public void IsStartedClearedInitially()
		{
			Assert.IsFalse(_watch.IsStarted);
		}

		[Test]
		public void IsStartedSetOnStart()
		{
			_watch.Start();
			Assert.IsTrue(_watch.IsStarted);
		}

		[Test]
		public void IsStartedClearedOnStop()
		{
			_watch.Start();
			_watch.Stop();
			Assert.IsFalse(_watch.IsStarted);
		}

		[Test]
		public void ElapsedStartsAtZero()
		{
			Assert.AreEqual(0.0f, _watch.Elapsed);
		}

		[Test]
		public void IntervalWorksRoughlyRight()
		{
			_watch.Start();
			Thread.Sleep(100);
			_watch.MarkInterval();
			Assert.IsTrue(_watch.Elapsed >= 0.09f && _watch.Elapsed <= 0.11f, "Elapsed time out of range (" + _watch.Elapsed + ")");
			Thread.Sleep(100);
			_watch.MarkInterval();
			Assert.IsTrue(_watch.Elapsed >= 0.09f && _watch.Elapsed <= 0.11f, "Elapsed time out of range (" + _watch.Elapsed + ")");
		}

		[Test]
		public void TotalTimeRoughlyRight()
		{
			_watch.Start();
			Thread.Sleep(100);
			_watch.Stop();
			Assert.IsTrue(_watch.Total >= 0.09 && _watch.Total <= 0.11, "Total time out of range (" + _watch.Total + ")");
		}

		[Test]
		public void ResetReturnsToZero()
		{
			_watch.Start();
			Thread.Sleep(100);
			_watch.Stop();
			Assert.IsTrue(_watch.Elapsed > 0.0f, "Watch never started");
			_watch.Reset();
			Assert.IsFalse(_watch.IsStarted, "Watch is still running");
			Assert.AreEqual(0.0f, _watch.Elapsed, "Elapsed time did not reset");
			Assert.AreEqual(0.0, _watch.Total, "Total time did not reset");
		}

		[Test]
		public void CanCallStartMultipleTimes()
		{
			_watch.Start();
			Thread.Sleep(100);
			_watch.Start();
			_watch.MarkInterval();
			Assert.IsTrue(_watch.Elapsed >= 0.09f, "Elapsed time out of range (" + _watch.Elapsed + ")");
		}
	}
}
