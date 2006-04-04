#region BSD License
/* FlatFour.Editor - MainForm.Designer.cs
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

namespace FlatFour.Editor
{
	public partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ctlStructure = new System.Windows.Forms.TreeView();
			this.ctlStructureMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctlStructureMenu_NewActor = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlStructureMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// ctlStructure
			// 
			this.ctlStructure.ContextMenuStrip = this.ctlStructureMenu;
			this.ctlStructure.Dock = System.Windows.Forms.DockStyle.Right;
			this.ctlStructure.Location = new System.Drawing.Point(450, 0);
			this.ctlStructure.Name = "ctlStructure";
			this.ctlStructure.Size = new System.Drawing.Size(121, 404);
			this.ctlStructure.TabIndex = 0;
			// 
			// ctlStructureMenu
			// 
			this.ctlStructureMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctlStructureMenu_NewActor});
			this.ctlStructureMenu.Name = "ctlStructureMenu";
			this.ctlStructureMenu.Size = new System.Drawing.Size(136, 26);
			// 
			// ctlStructureMenu_NewActor
			// 
			this.ctlStructureMenu_NewActor.Name = "ctlStructureMenu_NewActor";
			this.ctlStructureMenu_NewActor.Size = new System.Drawing.Size(135, 22);
			this.ctlStructureMenu_NewActor.Text = "New &Actor";
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(571, 404);
			this.Controls.Add(this.ctlStructure);
			this.Name = "MainForm";
			this.Text = "Flat Four Framework Editor";
			this.ctlStructureMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView ctlStructure;
		private System.Windows.Forms.ContextMenuStrip ctlStructureMenu;
		private System.Windows.Forms.ToolStripMenuItem ctlStructureMenu_NewActor;

	}
}

