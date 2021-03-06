#region BSD License
/* Carburetor - MainForm.cs
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
using System.Drawing;
using System.Windows.Forms;
using FlatFour.Editing;

namespace Carburetor
{
	public partial class MainForm : Form, IEditorUI
	{
		public MainForm()
		{
			InitializeComponent();

			/* The SceneView control is not designer-friendly right now, so it
			 * needs to be added to the form manually */
#if OBSOLETE
			SceneView scene = new SceneView();
			scene.Name = "ctlSceneView";
			scene.Dock = DockStyle.Fill;
			ctlSplitContainer1.Panel1.Controls.Add(scene);
#endif
		}


		/// <summary>
		///  Called on "File...Exit", exits the application.
		/// </summary>
		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}