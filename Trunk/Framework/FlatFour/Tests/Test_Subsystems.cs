#region BSD License
/* FlatFour.Tests - Subsystems.cs
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

namespace FlatFour.Tests
{
	[TestFixture]
	public class Test_Subsystems
	{
		#region Setup and Teardown

		[SetUp]
		public void Setup()
		{
			Framework.ResetSubsystems();
			Result = String.Empty;
		}

		#endregion

		#region Event Callbacks

		private string Result;

		private void CallbackA(object sender, EventArgs e)
		{
			Result += "A";
		}

		private void CallbackB(object sender, EventArgs e)
		{
			Result += "B";
		}
		
		#endregion


		[Test]
		public void CanConnectWithNoSubsystems()
		{
			Framework.Connect();
		}

		[Test]
		public void CanDisconnectWithNoSubsystems()
		{
			Framework.Disconnect();
		}

		[Test]
		public void StartupCalledOnRegistration()
		{
			Framework.Startup += new EventHandler(CallbackA);
			Assert.AreEqual("A", Result);
		}

		[Test]
		public void ShutdownCallOnDisconnect()
		{
			Framework.Shutdown += new EventHandler(CallbackA);
			Framework.Disconnect();
			Assert.AreEqual("A", Result);
		}			

		[Test]
		public void StartupCalledInRegistrationOrder()
		{
			Framework.Disconnect();
			Framework.Startup += new EventHandler(CallbackA);
			Framework.Startup += new EventHandler(CallbackB);
			Framework.Connect();
			Assert.AreEqual("AB", Result);
		}

		[Test]
		public void ShutdownCalledInReverseOrder()
		{
			Framework.Shutdown += new EventHandler(CallbackA);
			Framework.Shutdown += new EventHandler(CallbackB);
			Framework.Disconnect();
			Assert.AreEqual("BA", Result);
		}

		[Test]
		public void MultipleConnectsCallStartupOnce()
		{
			Framework.Disconnect();
			Framework.Startup += new EventHandler(CallbackA);
			Framework.Connect();
			Framework.Connect();
			Assert.AreEqual("A", Result);
		}

		[Test]
		public void MultipleDisconnectsCallShutdownOnce()
		{
			Framework.Shutdown += new EventHandler(CallbackA);
			Framework.Disconnect();
			Framework.Disconnect();
			Assert.AreEqual("A", Result);
		}
	}
}
