#region BSD License
/* FlatFour.Editing - Editor.cs
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

namespace FlatFour.Editing
{
	/// <summary>
	///  Like the Framework class, Editor is a static singleton providing
	///  a central access point to all of the major editing objects.
	/// </summary>
	public static class Editor
	{
		private static IEditorUI _ui;
		private static IPluginCollection _plugins;

		/// <summary>
		///  The editor UI interface.
		/// </summary>
		public static IEditorUI UI
		{
			get { return _ui; }
			set { _ui = value; }
		}

		public static IPluginCollection Plugins
		{
			get { return _plugins; }
			set { _plugins = value; }
		}
	}
}
