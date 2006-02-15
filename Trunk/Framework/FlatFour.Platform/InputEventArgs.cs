#region BSD License
/* FlatFour.Platform - InputEventArgs.cs
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
using GameGuts;

namespace FlatFour.Platform
{
	public enum InputKind
	{
		None             = Toolkit.utEventKind.UT_EVENT_NONE,
		Key              = Toolkit.utEventKind.UT_EVENT_KEY,
		KeyRepeat        = Toolkit.utEventKind.UT_EVENT_KEY_REPEAT,
		Character        = Toolkit.utEventKind.UT_EVENT_CHAR,
		MouseAxis        = Toolkit.utEventKind.UT_EVENT_MOUSE_AXIS,
		MouseButton      = Toolkit.utEventKind.UT_EVENT_MOUSE_BUTTON,
		ControllerAxis   = Toolkit.utEventKind.UT_EVENT_CTRL_AXIS,
		ControllerButton = Toolkit.utEventKind.UT_EVENT_CTRL_BUTTON
	}

	public class InputEventArgs
	{
		private InputKind _kind;
		private int       _index;
		private int       _value;

		public char Char
		{
			get 
			{ 
				return (char)_index; 
			}
		}

		public int Index
		{
			get { return _index; }
			set { _index = value; }
		}

		public bool IsPressed
		{
			get { return (_value != 0); }
		}

		public Key Key
		{
			get { return (Key)_index; }
		}

		public InputKind Kind
		{
			get { return _kind; }
			set { _kind = value; }
		}

		public int Value
		{
			get { return _value; }
			set { _value = value; }
		}


		internal static InputEventArgs FromEvent(Toolkit.utEvent e)
		{
			InputEventArgs args = new InputEventArgs();
			args.Kind  = (InputKind)e.what;
			args.Index = e.arg1;
			args.Value = e.arg2;
			return args;
		}
	}
}
