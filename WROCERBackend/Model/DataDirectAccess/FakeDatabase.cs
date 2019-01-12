using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataDirectAccess
{
	public class FakeDatabase : IDataDirectAccess
	{
		private readonly Dictionary<Type, List<IDataModel>> _Data = new Dictionary<Type, List<IDataModel>>();

		public FakeDatabase()
		{
			FillData();
		}

		public FakeDatabase(Dictionary<Type, List<IDataModel>> data)
		{
			_Data = data;
		}

		public bool AddItem<T>(T item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAll<T>()
		{
			throw new NotImplementedException();
		}

		public T GetItem<T>(long id)
		{
			throw new NotImplementedException();
		}

		public bool HasModel(Type modelType)
		{
			return _Data.ContainsKey(modelType);
		}

		public bool HasModel<T>()
		{
			return HasModel(typeof(T));
		}

		public bool RemoveItem<T>(T item)
		{
			throw new NotImplementedException();
		}

		public bool UpdateItem<T>(T item)
		{
			throw new NotImplementedException();
		}

		private void FillData()
		{
			_Data.Add(typeof(DataSezon), new List<IDataModel>()
			{
				new DataSezon(){ID = 1, Rok = 2018},
				new DataSezon(){ID = 2, Rok = 2019},
			});

			_Data.Add(typeof(DataMecz), new List<IDataModel>()
			{
				new DataMecz(){ID = 1, Sezon = 1, Tremin = (new DateTime(2018, 1, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 2, Sezon = 1, Tremin = (new DateTime(2018, 2, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 3, Sezon = 1, Tremin = (new DateTime(2018, 3, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 4, Sezon = 2, Tremin = (new DateTime(2019, 4, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 5, Sezon = 2, Tremin = (new DateTime(2019, 5, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 6, Sezon = 2, Tremin = (new DateTime(2019, 6, 5, 18, 00, 00)).Ticks},
			});
		}
	}
}
