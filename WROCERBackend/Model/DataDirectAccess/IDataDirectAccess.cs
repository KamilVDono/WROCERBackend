using System;
using System.Collections.Generic;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataDirectAccess
{
	public interface IDataDirectAccess
	{
		IEnumerable<T> GetAll<T>();
		T GetItem<T>(long id);
		bool AddItem<T>(T item);
		bool UpdateItem<T>(T item);
		bool RemoveItem<T>(T item);
		bool HasModel(Type modelType);
		bool HasModel<T>();
	}
}