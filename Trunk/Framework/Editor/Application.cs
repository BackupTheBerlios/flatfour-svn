#region BSD License
/* Flat Four Editor - Application.cs
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

namespace Editor
{
	#region Frame Window - Sample

	public class MyFrame : wx.Frame
	{
		enum Cmd { About, Quit }

		public MyFrame(string title, Point pos, Size size)
			: base(title, pos, size)
		{
			/* Create a menu */
			wx.Menu fileMenu = new wx.Menu();
			fileMenu.Append((int)Cmd.Quit, "E&xit\tAlt-X", "Quit this program");

			wx.Menu helpMenu = new wx.Menu();
			helpMenu.Append((int)Cmd.About, "&About...\tF1", "Show about dialog");

			wx.MenuBar menuBar = new wx.MenuBar();
			menuBar.Append(fileMenu, "&File");
			menuBar.Append(helpMenu, "&Help");

			MenuBar = menuBar;

			/* Create a status bar */
			CreateStatusBar(2);
			StatusText = "Welcome to wxWidgets!";

			/* Wire up the events */
			EVT_MENU((int)Cmd.Quit,    new wx.EventListener(OnQuit));
			EVT_MENU((int)Cmd.About,   new wx.EventListener(OnAbout));
		}


		public void OnQuit(object sender, wx.Event e)
		{
			Close();
		}


		public void OnAbout(object sender, wx.Event e)
		{
			string msg = "This is the About dialog of the minimal sample.";
			wx.MessageDialog.ShowModal(this, msg, "About Minimal", wx.Dialog.wxOK | wx.Dialog.wxICON_INFORMATION);
		}
	}

	#endregion


	public class Application : wx.App
	{
		public override bool OnInit()
		{
			MyFrame frame = new MyFrame("Minimal wxWidgets App", new Point(50,50), new Size(450,340));
			frame.Show(true);

			return true;
		}

		[STAThread]
		static void Main()
		{
			Application app = new Application();
			app.Run();
		}
	}
}
