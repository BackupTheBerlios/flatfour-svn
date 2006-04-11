#region BSD License
/* Carburetor - Program.cs
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
using FlatFour.Editing;

namespace Carburetor
{
	class Program : IDisposable
	{
		/// <summary>
		///  Connects the editing system to the framework.
		/// </summary>
		public Program()
		{
			Editor.UI = new MainForm();
			Editor.Plugins = new PluginCollection();
			Editor.Plugins.LoadEnabledPlugins();
		}


		/// <summary>
		///  Detach the editor from the framework.
		/// </summary>
		public void Dispose()
		{
			Editor.UI.Dispose();
			Editor.UI = null;

			Editor.Plugins.Dispose();
			Editor.Plugins = null;
		}


		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			using (Program program = new Program())
			{
				Application.Run((MainForm)Editor.UI);
			}
		}
	}
}