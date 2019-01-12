using System;
using System.Collections.Generic;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataDirectAccess
{
	public interface IDataDirectAccess
	{
		IEnumerable<T> GetAll<T>() where T : AbstractDataModel;
		T GetItem<T>(long id) where T : AbstractDataModel;
		bool AddItem<T>(T item) where T : AbstractDataModel;
		bool UpdateItem<T>(T item) where T : AbstractDataModel;
		bool RemoveItem<T>(T item) where T : AbstractDataModel;
		bool HasModel(Type modelType);
		bool HasModel<T>() where T : AbstractDataModel;
	}
}