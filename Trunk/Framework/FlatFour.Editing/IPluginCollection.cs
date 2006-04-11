#region BSD License
/* FlatFour.Editing - IPluginManager.cs
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
	///  Interface to the editor plugin collection.
	/// </summary>
	public interface IPluginCollection : IDisposable
	{
		/// <summary>
		///  The number of currently enabled plugins.
		/// </summary>
		int Count { get; }

		/// <summary>
		///  Loads a specific plugin.
		/// </summary>
		/// <param name="name">type plugin type name</param>
		void Load(string name);

		/// <summary>
		///  Load the set of enabled plugins.
		/// </summary>
		void LoadEnabledPlugins();

		/// <summary>
		///  Unload all plugins.
		/// </summary>
		void UnloadAll();

		/// <summary>
		///  Returns true if the specified plugin is loaded.
		/// </summary>
		/// <param name="name">plugin type name</param>
		/// <returns>True if the plugin is enabled</returns>
		bool IsLoaded(string name);
	}
}
