using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataDirectAccess
{
	public class FakeDatabase : IDataDirectAccess
	{
		private readonly Dictionary<Type, List<AbstractDataModel>> _Data = new Dictionary<Type, List<AbstractDataModel>>();

		public FakeDatabase()
		{
			FillData(_Data);
		}

		public FakeDatabase(Dictionary<Type, List<AbstractDataModel>> data)
		{
			_Data = data;
		}

		public bool AddItem<T>(T item) where T : AbstractDataModel
		{
			if (HasModel<T>() && item != null)
			{
				var list = _Data[typeof(T)];

				if (item.ID == 0)
				{
					long lastID = list.Max(i => i.ID);
					item.ID = lastID + 1;
					list.Add(item);
				}
				else
				{
					if (list.Contains(item)) return false;

					list.Add(item);
				}
				return true;
			}

			return false;
		}

		public IEnumerable<T> GetAll<T>() where T : AbstractDataModel
		{
			if (HasModel<T>())
			{
				var list = _Data[typeof(T)];

				return list.Cast<T>();
			}

			return new List<T>();
		}

		public T GetItem<T>(long id) where T : AbstractDataModel
		{
			return GetAll<T>()?.FirstOrDefault(item => item.ID == id);
		}

		public bool HasModel(Type modelType)
		{
			return _Data.ContainsKey(modelType);
		}

		public bool HasModel<T>() where T : AbstractDataModel
		{
			return HasModel(typeof(T));
		}

		public bool RemoveItem<T>(T item) where T : AbstractDataModel
		{
			if (HasModel<T>() && item != null)
			{
				var list = _Data[typeof(T)];

				if (list.Contains(item) == false) return false;

				list.Remove(item);
				return true;
			}

			return false;
		}

		public bool UpdateItem<T>(T item) where T : AbstractDataModel
		{
			if (HasModel<T>() && item != null)
			{
				var list = _Data[typeof(T)];

				if (list.Contains(item) == false) return false;

				list[list.IndexOf(item)] = item;
				return true;
			}

			return false;
		}

		public static void FillData(Dictionary<Type, List<AbstractDataModel>> _Data)
		{
			_Data.Add(typeof(DataSezon), new List<AbstractDataModel>()
			{
				new DataSezon(){ID = 1, Rok = 2018},
				new DataSezon(){ID = 2, Rok = 2019},
			});

			_Data.Add(typeof(DataMecz), new List<AbstractDataModel>()
			{
				new DataMecz(){ID = 1, Sezon = (DataSezon)_Data[typeof(DataSezon)][0], Termin = (new DateTime(2018, 1, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 2, Sezon = (DataSezon)_Data[typeof(DataSezon)][0], Termin = (new DateTime(2018, 2, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 3, Sezon = (DataSezon)_Data[typeof(DataSezon)][0], Termin = (new DateTime(2018, 3, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 4, Sezon = (DataSezon)_Data[typeof(DataSezon)][1], Termin = (new DateTime(2019, 4, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 5, Sezon = (DataSezon)_Data[typeof(DataSezon)][1], Termin = (new DateTime(2019, 5, 5, 18, 00, 00)).Ticks},
				new DataMecz(){ID = 6, Sezon = (DataSezon)_Data[typeof(DataSezon)][1], Termin = (new DateTime(2019, 6, 5, 18, 00, 00)).Ticks},
			});
		}
	}
}
