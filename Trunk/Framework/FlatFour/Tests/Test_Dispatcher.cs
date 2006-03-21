#region BSD License
/* FlatFour.Tests - Test_Dispatcher.cs
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
	public class Test_Dispatcher
	{
		private class MyBehavior : Behavior { }
		private class TestHandler
		{
			public int Count = 0;
			public void OnCall(MyBehavior tb)
			{
				Count++;
			}
		}

		private TestHandler _handler;
		private Dispatcher<Behavior> _d;

		[SetUp]
		public void Test_Setup()
		{
			_handler = new TestHandler();
			_d = new Dispatcher<Behavior>();
		}


		[Test]
		public void CanCreate()
		{
			Assert.IsNotNull(_d, "Unable to create");
		}

		[Test]
		public void CanAdd()
		{
			_d.Add(_handler);
		}

		[Test]
		public void CanCall()
		{
			_d.Add(_handler);
			_d.Dispatch(new MyBehavior());
			Assert.AreEqual(1, _handler.Count);
		}
	}
}
