using System;
using System.Collections.Generic;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataDirectAccess
{
	/// <summary>
	/// Interface for direct access point.
	/// Define interface to communicate with data providers eg.
	/// Relation database (eg. MySQL, SQLite)
	/// In-cache database (eg. Dictionary, Redis)
	/// Text-based (eg. csv file).
	/// This is abstraction layer between specific data storage and application. 
	/// </summary>
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
		/// Add item to database.
		/// </summary>
		/// <typeparam name="T">Data Model type</typeparam>
		/// <param name="item">Item to insert to database</param>
		/// <returns>True if success, false when can't add item</returns>
		bool AddItem<T>(T item) where T : AbstractDataModel;
		/// <summary>
		/// Update database element properties to item properties based on item ID
		/// </summary>
		/// <typeparam name="T">Data Model type</typeparam>
		/// <param name="item">Item with new properties</param>
		/// <returns>True if success, false when can't add item</returns>
		bool UpdateItem<T>(T item) where T : AbstractDataModel;
		/// <summary>
		/// Remove item from database based on item ID.
		/// </summary>
		/// <typeparam name="T">Data Model type</typeparam>
		/// <param name="item">Item to remove</param>
		/// <returns>True if success, false when can't add item</returns>
		bool RemoveItem<T>(T item) where T : AbstractDataModel;
		/// <summary>
		/// Check if database store items of type;
		/// </summary>
		/// <param name="modelType">Type of item</param>
		/// <returns>True if store otherwise false</returns>
		bool HasModel(Type modelType);
		/// <summary>
		/// Check if database store items of type;
		/// </summary>
		/// <typeparam name="T">Type of item</typeparam>
		/// <returns>True if store otherwise false</returns>
		bool HasModel<T>() where T : AbstractDataModel;
	}
}