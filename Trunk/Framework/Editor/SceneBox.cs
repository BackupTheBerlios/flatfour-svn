#region BSD License
/* Flat Four Editor - SceneBox.cs
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
using FlatFour.Graphics;

namespace Editor
{
	public partial class SceneBox : Control
	{
		private GraphicsWindow _gfx;

		public SceneBox()
		{
			InitializeComponent();
			_gfx = new GraphicsWindow(this.Handle);
			_gfx.Camera.BackgroundColor = Color.SkyBlue;

			this.Resize += new EventHandler(SceneBox_Resize);
		}

		private void SceneBox_Resize(object sender, EventArgs e)
		{
			_gfx.Size = this.ClientSize;
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			GraphicsSystem.DrawFrame(_gfx);
			base.OnPaint(pe);
		}
	}
}
