#region BSD License
/* Carburetor - MainForm.Designer.cs
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

namespace Carburetor
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
			this.ctlMainMenu = new System.Windows.Forms.MenuStrip();
			this.MainMenu_File = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MainMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctlMainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// ctlMainMenu
			// 
			this.ctlMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenu_File,
            this.toolsToolStripMenuItem});
			this.ctlMainMenu.Location = new System.Drawing.Point(0, 0);
			this.ctlMainMenu.Name = "ctlMainMenu";
			this.ctlMainMenu.Size = new System.Drawing.Size(770, 24);
			this.ctlMainMenu.TabIndex = 1;
			this.ctlMainMenu.Text = "menuStrip1";
			// 
			// MainMenu_File
			// 
			this.MainMenu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.MainMenu_Exit});
			this.MainMenu_File.Name = "MainMenu_File";
			this.MainMenu_File.Size = new System.Drawing.Size(35, 20);
			this.MainMenu_File.Text = "&File";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
			// 
			// MainMenu_Exit
			// 
			this.MainMenu_Exit.Name = "MainMenu_Exit";
			this.MainMenu_Exit.Size = new System.Drawing.Size(103, 22);
			this.MainMenu_Exit.Text = "E&xit";
			this.MainMenu_Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(770, 473);
			this.Controls.Add(this.ctlMainMenu);
			this.Name = "MainForm";
			this.Text = "Carburetor";
			this.ctlMainMenu.ResumeLayout(false);
			this.ctlMainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip ctlMainMenu;
		private System.Windows.Forms.ToolStripMenuItem MainMenu_File;
		private System.Windows.Forms.ToolStripMenuItem MainMenu_Exit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
	}
}

