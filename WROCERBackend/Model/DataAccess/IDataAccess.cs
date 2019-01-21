using WROCERBackend.Model.DataDirectAccess;

namespace WROCERBackend.Model.DataAccess
{
	/// <summary>
	/// Abstraction above IDataDirectAccess interface.
	/// Can aggregate data providers and hide them.
	/// With this abstraction application see one data access point
	/// so it is only one class to refactor/add when we need add another data provider.
	/// </summary>
	public interface IDataAccess : IDataDirectAccess
	{
		/// <summary>
		/// Add access point to this access point
		/// </summary>
		/// <param name="directPoint">Data provider</param>
		void AddDirectPoint(IDataDirectAccess directPoint);
		/// <summary>
		/// Remove access point to this access point
		/// </summary>
		/// <param name="directPoint">Data provider</param>
		void RemoveDirectPoint(IDataDirectAccess directPoint);
	}
}