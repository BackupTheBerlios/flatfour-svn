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
				components.Dispose();
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
			this.ctlSplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.ctlStructureTreeView = new System.Windows.Forms.TreeView();
			this.ctlStructureMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newActorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlSplitContainer1.Panel2.SuspendLayout();
			this.ctlSplitContainer1.SuspendLayout();
			this.ctlStructureMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// ctlSplitContainer1
			// 
			this.ctlSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlSplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.ctlSplitContainer1.Name = "ctlSplitContainer1";
			// 
			// ctlSplitContainer1.Panel2
			// 
			this.ctlSplitContainer1.Panel2.Controls.Add(this.ctlStructureTreeView);
			this.ctlSplitContainer1.Size = new System.Drawing.Size(571, 404);
			this.ctlSplitContainer1.SplitterDistance = 351;
			this.ctlSplitContainer1.TabIndex = 0;
			// 
			// ctlStructureTreeView
			// 
			this.ctlStructureTreeView.ContextMenuStrip = this.ctlStructureMenu;
			this.ctlStructureTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctlStructureTreeView.LabelEdit = true;
			this.ctlStructureTreeView.Location = new System.Drawing.Point(0, 0);
			this.ctlStructureTreeView.Name = "ctlStructureTreeView";
			this.ctlStructureTreeView.Size = new System.Drawing.Size(216, 404);
			this.ctlStructureTreeView.TabIndex = 0;
			// 
			// ctlStructureMenu
			// 
			this.ctlStructureMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newActorToolStripMenuItem});
			this.ctlStructureMenu.Name = "ctlStructureMenu";
			this.ctlStructureMenu.Size = new System.Drawing.Size(153, 48);
			// 
			// newActorToolStripMenuItem
			// 
			this.newActorToolStripMenuItem.Name = "newActorToolStripMenuItem";
			this.newActorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newActorToolStripMenuItem.Text = "New &Actor";
			this.newActorToolStripMenuItem.Click += new System.EventHandler(this.NewActor_Click);
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(571, 404);
			this.Controls.Add(this.ctlSplitContainer1);
			this.Name = "MainForm";
			this.Text = "Flat Four Framework Editor";
			this.ctlSplitContainer1.Panel2.ResumeLayout(false);
			this.ctlSplitContainer1.ResumeLayout(false);
			this.ctlStructureMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer ctlSplitContainer1;
		private System.Windows.Forms.TreeView ctlStructureTreeView;
		private System.Windows.Forms.ContextMenuStrip ctlStructureMenu;
		private System.Windows.Forms.ToolStripMenuItem newActorToolStripMenuItem;
	}
}

