using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WROCERBackend.Model.DataDirectAccess;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataAccess
{
	public class WrocerDataAccess : IDataAccess
	{
		private readonly List<IDataDirectAccess> _DirectAccesses = new List<IDataDirectAccess>();

		public WrocerDataAccess()
		{
			_DirectAccesses.Add(new FakeDatabase());
		}

		public WrocerDataAccess(List<IDataDirectAccess> directAccesses)
		{
			_DirectAccesses = directAccesses;
		}

		public IEnumerable<T> GetAll<T>() where T : AbstractDataModel
		{
			HashSet<T> set = new HashSet<T>();
			_DirectAccesses.ForEach(access => set.UnionWith(access.GetAll<T>()));
			return set;
		}

		public T GetItem<T>(long id) where T : AbstractDataModel
		{
			return _DirectAccesses.SelectMany(access => access.GetAll<T>()).FirstOrDefault(item => item.ID == id);
		}

		public bool AddItem<T>(T item) where T : AbstractDataModel
		{
			return _DirectAccesses.Any(access => access.AddItem(item));
		}

		public bool UpdateItem<T>(T item) where T : AbstractDataModel
		{
			return _DirectAccesses.Any(access => access.UpdateItem(item));
		}

		public bool RemoveItem<T>(T item) where T : AbstractDataModel
		{
			return _DirectAccesses.Any(access => access.RemoveItem(item));
		}

		public bool HasModel(Type modelType)
		{
			return _DirectAccesses.Any(access => access.HasModel(modelType));
		}

		public bool HasModel<T>() where T : AbstractDataModel
		{
			return HasModel(typeof(T));
		}

		public void AddDirectPoint(IDataDirectAccess directPoint)
		{
			if (_DirectAccesses.Contains(directPoint) || directPoint == null) return;
			_DirectAccesses.Add(directPoint);
		}

		public void RemoveDirectPoint(IDataDirectAccess directPoint)
		{
			_DirectAccesses.Remove(directPoint);
		}
	}
}
