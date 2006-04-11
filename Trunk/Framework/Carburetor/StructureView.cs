#region BSD License
/* Carburetor - StructureView.cs
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
using FlatFour;

namespace Carburetor
{
	/// <summary>
	///  The StructureView control is the tree view containing the list of
	///  actors and behaviors contained in the scene.
	/// </summary>
	public class StructureView : TreeView
	{
		public StructureView()
		{
			this.MouseDown += new MouseEventHandler(StructureView_MouseDown);
		}

		public void NewActor(Actor actor)
		{
			TreeNode node = new TreeNode("Actor");
			this.Nodes.Add(node);
			this.SelectedNode = node;
			node.BeginEdit();
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
	}
}
