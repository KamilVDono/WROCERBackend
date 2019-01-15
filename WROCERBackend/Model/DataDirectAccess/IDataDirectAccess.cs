using System;
using System.Collections.Generic;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataDirectAccess
{
	public interface IDataDirectAccess
	{
		/// <summary>
		/// Get all objects of type T stored in this access point.
		/// </summary>
		/// <typeparam name="T">Data Model type</typeparam>
		/// <returns>Collections of all items of type T in point. Collection can be empty but not null.</returns>
		IEnumerable<T> GetAll<T>() where T : AbstractDataModel;
		/// <summary>
		/// Get item of type T stored in this access point with ID equal id.
		/// </summary>
		/// <typeparam name="T">Data Model type</typeparam>
		/// <param name="id">Id of search item</param>
		/// <returns>If exist object of type T with ID = id or null if not exist</returns>
		T GetItem<T>(long id) where T : AbstractDataModel;
		/// <summary>
		/// Add item to collection of stored
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		bool AddItem<T>(T item) where T : AbstractDataModel;
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		bool UpdateItem<T>(T item) where T : AbstractDataModel;
		bool RemoveItem<T>(T item) where T : AbstractDataModel;
		bool HasModel(Type modelType);
		bool HasModel<T>() where T : AbstractDataModel;
	}
}