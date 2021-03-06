﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WROCERBackend.Utils
{
	public static class ReflectinoUtils
	{
		/// <summary>
		/// Copy properties from source object to destination object.
		/// Objects can have different types and only common properties will be copied.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="destination"></param>
		public static void CopyProperties(this object source, object destination)
		{
			// If any this null throw an exception
			if (source == null || destination == null) return;
			// Getting the Types of the objects
			Type typeDest = destination.GetType();
			Type typeSrc = source.GetType();

			// Iterate the Properties of the source instance and  
			// populate them from their desination counterparts  
			PropertyInfo[] srcProps = typeSrc.GetProperties();
			foreach (PropertyInfo srcProp in srcProps)
			{
				if (!srcProp.CanRead)
				{
					continue;
				}
				PropertyInfo targetProperty = typeDest.GetProperty(srcProp.Name);
				if (targetProperty == null)
				{
					continue;
				}
				if (!targetProperty.CanWrite)
				{
					continue;
				}
				if (targetProperty.GetSetMethod(true) != null &&
					targetProperty.GetSetMethod(true).IsPrivate)
				{
					continue;
				}
				if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
				{
					continue;
				}
				if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
				{
					continue;
				}
				// Passed all tests, lets set the value
				targetProperty.SetValue(destination, srcProp.GetValue(source, null), null);
			}
		}

		public static void NullReferences(this object obj)
		{
			if (ReferenceEquals(obj, null))
			{
				return;
			}

			Type type = obj.GetType();
			PropertyInfo[] props = type.GetProperties();
			foreach (var propertyInfo in props)
			{
				if (!propertyInfo.CanWrite)
				{
					continue;
				}
				if (propertyInfo.GetSetMethod(true) != null &&
				    propertyInfo.GetSetMethod(true).IsPrivate)
				{
					continue;
				}
				if (propertyInfo.PropertyType.IsClass == false)
				{
					continue;
				}
				propertyInfo.SetValue(obj, null, null);
			}
		}
	}
}
