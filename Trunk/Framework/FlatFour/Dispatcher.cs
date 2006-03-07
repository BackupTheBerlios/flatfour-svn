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
	/* The Dispatcher is the base class for my generic data handling containers
	 * like Actor and Visualization. These container classes receive data
	 * objects and need to route them to one or more handler classes that do
	 * the actual work. To make the system easily extensible, I want to
	 * automatically find these handler methods and call them, without needing
	 * a special registration step. This class makes that possible. */
	public class Dispatcher<T>
	{
		/* Generic callback signature */
		private delegate void GenericDispatch(object arg);

		/* Cache of runtime generated hooks, keyed by type */
		private class DynamicMethodCache : Dictionary<Type, DynamicMethod> { }
		private static Dictionary<Type, DynamicMethodCache> _methods;

		/* Handlers registered to this specific instance */
		private Dictionary<Type, GenericDispatch> _handlers;

		static Dispatcher()
		{
			_methods = new Dictionary<Type, DynamicMethodCache>();
		}

		public Dispatcher()
		{
			_handlers = new Dictionary<Type, GenericDispatch>();
		}


		public void Add(object target)
		{
			Type targetType = target.GetType();

			/* Have I already registered this type? If so I already have a
			 * list of the suitable methods for registration */
			DynamicMethodCache cache;
			if (!_methods.TryGetValue(targetType, out cache))
			{
				/* Create a new cache */
				cache = new DynamicMethodCache();
				_methods.Add(targetType, cache);

				/* Search for suitable methods */
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

					/* Rather than create a custom delegate -- with all of the
					 * metadata and overhead associated with a type -- I create
					 * a small wrapper method to do the call. Since I've already
					 * type-checked the signature, this can be very small */
					DynamicMethod dm = new DynamicMethod("", typeof(void), new Type[] { typeof(object), typeof(object) }, targetType);
					ILGenerator il = dm.GetILGenerator();
					il.Emit(OpCodes.Ldarg_0);
					il.Emit(OpCodes.Ldarg_1);
					il.Emit(OpCodes.Call, method);
					il.Emit(OpCodes.Ret);
					cache.Add(parmType, dm);
				}
			}

			/* For each type registered by the handler, create an entry in 
			 * my local dispatch table */
			foreach (Type argType in cache.Keys)
			{
				DynamicMethod dm = cache[argType];
				GenericDispatch gd = (GenericDispatch)dm.CreateDelegate(typeof(GenericDispatch), target);
				if (_handlers.ContainsKey(argType))
					_handlers[argType] += gd;
				else
					_handlers[argType] = gd;
			}
		}

		public void Remove(object target)
		{
			throw new NotImplementedException("Still need to figure this one out");
			/*
			foreach (Type argType in _handlers.Keys)
			{
				GenericDispatch gd = _handlers[argType];
				Delegate[] delegates = gd.GetInvocationList();
				foreach (Delegate d in delegates)
				{
					if (d.Target == target)
						_handlers[argType] -= (GenericDispatch)d;
				}
			}
			*/
		}

		public void Dispatch(T item)
		{
			GenericDispatch handler;
			if (_handlers.TryGetValue(item.GetType(), out handler))
				handler(item);
		}
	}
}
