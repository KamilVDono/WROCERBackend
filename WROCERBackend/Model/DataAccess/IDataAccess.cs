using WROCERBackend.Model.DataDirectAccess;

namespace WROCERBackend.Model.DataAccess
{
	public interface IDataAccess<T> : IDataDirectAccess<T> where T : new()
	{
		void AddDirectPoint(T directPoint);
		void RemoveDirectPoint(T directPoint);
	}
}