#region BSD License
/* FlatFour.Editor.Tests - Test_StructureView.cs
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
using System.Windows.Forms;
using NUnit.Framework;
using NUnit.Extensions.Forms;
using NMock;

namespace FlatFour.Editor.Tests
{
	[TestFixture]
	public class Test_StructureView : NUnitFormTest
	{
		DynamicMock _controller;
		MainForm _form;
		TreeViewTester _ctrl;

		public override void Setup()
		{
			_controller = new DynamicMock(typeof(Controller));
			_form = new MainForm((Controller)_controller.MockInstance);
			_form.Show();
			_ctrl = new TreeViewTester("ctlStructureTreeView");
		}


		[Test]
		public void ControlIsVisible()
		{
			Assert.IsTrue((bool)_ctrl["Visible"]);
		}


		[Test]
		public void Test_HasContextMenu()
		{
			ContextMenuStrip menu = (ContextMenuStrip)_ctrl["ContextMenuStrip"];
			Assert.IsNotNull(menu);
			Assert.AreEqual("ctlStructureMenu", menu.Name);
		}


		[Test]
		public void Test_NewActorCallsController()
		{
			_controller.ExpectAndReturn("NewActor", new Actor(), null);
			// _form.Structure.StructureView_NewActor(null, EventArgs.Empty);
			_controller.Verify();
		}
	}
}
