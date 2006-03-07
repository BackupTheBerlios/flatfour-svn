#region BSD License
/* FlatFour.Tests - Test_ReflectedHandlers.cs
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
		/* I don't seem to be able to unit test the Dispatcher...I get a 
		 * MethodAccessException when I try to make the callback. I'll
		 * need to revist this later. */

		private class TestHandler
		{
		}

		[Test]
		public void CanCreate()
		{
			Dispatcher<Behavior> d = new Dispatcher<Behavior>();
			Assert.IsNotNull(d, "Unable to create");
		}

		[Test]
		public void CanAdd()
		{
			Dispatcher<Behavior> d = new Dispatcher<Behavior>();
			d.Add(new TestHandler());
		}

		[Test]
		protected void CanGarbageCollect()
		{
			/* In the case that I attach to a remote object, I should still be
			 * able to garbage collect the handler class */
		}

		[Test]
		protected void CanCallSingle()
		{
			/* Dispatch an object to a handler which contains one matching method */
		}

		[Test]
		protected void CanCallMultiple()
		{
			/* Dispatch to an object that defines multiple matching methods */
		}

		[Test]
		protected void CanCallInherited()
		{
			/* Call a handler that has been inherited from a base class */
		}

		[Test]
		protected void CanCallFromDerivedType()
		{
			/* Send a data object derived from a base class, should arrive at handlers 
			 * for that base class */
		}
	}
}
