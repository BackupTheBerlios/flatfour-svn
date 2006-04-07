#region BSD License
/* FlatFour.Editor.Tests - Test_MainForm.cs
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
	public class Test_MainForm : NUnitFormTest
	{
		DynamicMock _controller;
		MainForm _form;

		public override void Setup()
		{
			_controller = new DynamicMock(typeof(Controller));
			_form = new MainForm((Controller)_controller.MockInstance);
			_form.Show();
		}
	}
}
