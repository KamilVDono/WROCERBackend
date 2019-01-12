using WROCERBackend.Model.DataDirectAccess;

namespace WROCERBackend.Model.DataAccess
{
	public interface IDataAccess : IDataDirectAccess
	{
		void AddDirectPoint(IDataDirectAccess directPoint);
		void RemoveDirectPoint(IDataDirectAccess directPoint);
	}
}