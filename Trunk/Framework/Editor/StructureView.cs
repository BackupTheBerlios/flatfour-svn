#region BSD License
/* FlatFour.Editor - StructureView.cs
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

namespace FlatFour.Editor
{
	public partial class StructureView : TreeView
	{
		private ContextMenuStrip _menu;
		private ToolStripMenuItem _menu_NewActor;

		public StructureView()
		{
			InitializeComponent();
			CreateContextMenu();

			this.LabelEdit = true;

			this.MouseDown += new MouseEventHandler(StructureView_MouseDown);
			_menu_NewActor.Click += new EventHandler(StructureView_NewActor);
		}

		private void CreateContextMenu()
		{
			_menu_NewActor = new ToolStripMenuItem();
			_menu_NewActor.Name = "StructureViewMenu_NewActor";
			_menu_NewActor.Text = "New &Actor";

			_menu = new ContextMenuStrip();
			_menu.Items.AddRange(new ToolStripItem[] { 
				_menu_NewActor });
			_menu.Name = "StructureViewMenu";
			this.ContextMenuStrip = _menu;
		}

		private void StructureView_MouseDown(object sender, MouseEventArgs e)
		{
			/* I want right-click to also select the node, so the context
			 * menu callback will know which item to operate on */
			if (e.Button == MouseButtons.Right)
			{
				this.SelectedNode = this.GetNodeAt(e.X, e.Y);
			}
		}

		private void StructureView_NewActor(object sender, EventArgs e)
		{
			/* Create a new node for the actor */
			TreeNode node = new TreeNode("Hi there!");

			/* Add it to the tree */
			TreeNode selected = this.SelectedNode;
			if (selected != null)
			{
				selected.Nodes.Add(node);
				selected.Expand();
			}
			else
			{
				this.Nodes.Add(node);
			}

			/* Select the newly added node */
			this.SelectedNode = node;
			node.BeginEdit();
		}
	}
}
