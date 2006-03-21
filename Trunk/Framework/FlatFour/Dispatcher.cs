#region BSD License
/* FlatFour - ReflectedHandlerList.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace FlatFour
{
	/* The Dispatcher is the base class for my composition-based containers
	 * like Actor and Visualization. These container classes receive objects
	 * and route them to one or more handlers that act on them. To make the 
	 * system easily extensible, I want to automatically find these handler 
	 * methods and call them, without needing a special registration step. 
	 * Like Rails: Convention Over Configuration. */
	public class Dispatcher<T>
	{
		private delegate void GenericHandler(object arg);
		private Dictionary<Type, GenericHandler> _handlers;
		private int _count;

		public Dispatcher()
		{
			_handlers = new Dictionary<Type, GenericHandler>();
		}

		
		/* Build myself up through composition */
		public void Add(object target)
		{
			Type targetType = target.GetType();
			_count++;

			/* Search for suitable handler methods */
			MethodInfo[] methods = targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
			foreach (MethodInfo method in methods)
			{
				/* Must return void */
				if (method.ReturnType != typeof(void))
					continue;

				/* Must have a single parameter */
				ParameterInfo[] parms = method.GetParameters();
				if (parms.Length != 1)
					continue;

				/* Parameter type must be a subclass of my target type */
				Type parmType = parms[0].ParameterType;
				if (!parmType.IsSubclassOf(typeof(T)))
					continue;

				/* Looks good, create a delegate to call this method. I have to
				 * resort to some trickery to avoid the type checking */
				object[] args = new object[] { target, method.MethodHandle.GetFunctionPointer() };
				GenericHandler handler = (GenericHandler)Activator.CreateInstance(typeof(GenericHandler), args);

				/* Add it to my dispatch table */
				if (_handlers.ContainsKey(parmType))
					_handlers[parmType] += handler;
				else
					_handlers[parmType] = handler;
			}
		}


		public void Remove(object target)
		{
			_count--;
			throw new NotImplementedException("Still need to figure this one out");
		}


		public void Dispatch(T item)
		{
			GenericHandler handler;
			if (_handlers.TryGetValue(item.GetType(), out handler))
				handler(item);
		}


		public int Count
		{
			get { return _count; }
		}
	}
}
