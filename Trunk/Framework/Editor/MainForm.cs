#region BSD License
/* Flat Four Editor - MainForm.cs
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

namespace Editor
{
    public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			/* Add a view into the scene */
			SceneBox scene = new SceneBox();
			scene.Name = "scene";
			scene.Dock = System.Windows.Forms.DockStyle.Fill;
			scene.Location = new System.Drawing.Point(0, 0);
			scene.TabIndex = 0;
			scene.TabStop = true;
			Controls.Add(scene);
		}
	}
}