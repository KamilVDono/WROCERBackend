using System.Collections.Generic;

namespace WROCERBackend.Model.DataDirectAccess
{
	public interface IDataDirectAccess<T> where T: new()
	{
		IEnumerable<T> GetAll();
		T GetItem(long id);
		bool AddItem(T item);
		bool UpdateItem(T item);
		bool RemoveItem(T item);
	}
}