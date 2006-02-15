#region BSD License
/* FlatFour - Stopwatch.cs
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

namespace FlatFour
{
	public class Stopwatch
	{
		private bool _isStarted;
		private int _startTick;
		private int _markedTick;
		private float _elapsed;
		private double _total;

		public Stopwatch()
		{
		}

		public bool IsStarted
		{
			get { return _isStarted; }
		}

		public void Start()
		{
			if (!_isStarted)
			{
				_isStarted = true;
				_startTick = Environment.TickCount;
				_markedTick = _startTick;
				_elapsed = 0.0f;
				_total = 0.0;
			}
		}

		public void Stop()
		{
			MarkInterval();
			_isStarted = false;
		}

		public void MarkInterval()
		{
			if (_isStarted)
			{
				int currentTick = Environment.TickCount;
				_elapsed = (currentTick - _markedTick) / 1000.0f;
				_total = (currentTick - _startTick) / 1000.0f;
				_markedTick = currentTick;
			}
		}

		public void Reset()
		{
			_isStarted = false;
			_elapsed = 0.0f;
			_total = 0.0f;
		}

		public float Elapsed
		{
			get { return _elapsed; }
			set { _elapsed = value; }
		}

		public double Total
		{
			get { return _total; }
		}
	}
}
