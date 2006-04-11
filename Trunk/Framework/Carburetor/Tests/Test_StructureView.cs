#region BSD License
/* Carburetor.Tests - Test_StructureView.cs
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
using FlatFour;

namespace Carburetor.Tests
{
	[TestFixture]
	public class Test_StructureView : NUnitFormTest
	{
		MainForm _form;

		public override void Setup()
		{
			_form = new MainForm();
			_form.Show();
		}


		[Test]
		public void ControlIsVisible()
		{
//			Assert.IsTrue(_form.StructureView.Visible);
		}


		[Test]
		public void HasContextMenu()
		{
//			ContextMenuStrip menu = _form.StructureView.ContextMenuStrip;
//			Assert.IsNotNull(menu);
//			Assert.AreEqual("ctlStructureMenu", menu.Name);
		}


		[Test]
		public void NewActorAddsNode()
		{
//			int before = _form.StructureView.Nodes.Count;
//			_form.StructureView.NewActor(new Actor());
//			Assert.AreEqual(before + 1, _form.StructureView.Nodes.Count);
		}

		[Test]
		public void NewActorNodeIsEditable()
		{
//			_form.StructureView.NewActor(new Actor());
//			TreeNode node = _form.StructureView.SelectedNode;
//			Assert.IsTrue(node.IsEditing);
		}
	}
}
