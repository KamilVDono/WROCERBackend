using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Model.DataDirectAccess
{
	public class DatabaseContext : DbContext, IDataDirectAccess
	{
		public DatabaseContext(DbContextOptions options)
			: base(options)
		{
			_DataDictionaryGet = new Dictionary<Type, Func<IEnumerable<AbstractDataModel>>>()
			{
				{ typeof(DataDruzyna), () => DataDruzynas.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataGracz), () => DataGraczs.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataMecz), () => DataMeczs.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataPozycja), () => DataPozycjas.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataRaport), () => DataRaports.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataSezon), () => DataSezons.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataSytuacjaMeczowa), () => DataSytuacjaMeczowas.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataSytuacjaTyp), () => DataSytuacjaTyps.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataUzytkownik), () => DataUzytkowniks.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataUzytkownikTyp), () => DataUzytkownikTyps.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataZawodnik), () => DataZawodniks.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataZmiana), () => DataZmianas.Cast<AbstractDataModel>().AsEnumerable()},
			};

			_DataDictionaryUpdate = new Dictionary<Type, Action<AbstractDataModel>>()
			{
				{ typeof(DataDruzyna), (d) => DataDruzynas.Update((DataDruzyna)d)},
				{ typeof(DataGracz), (d) => DataGraczs.Update((DataGracz)d)},
				{ typeof(DataMecz), (d) => DataMeczs.Update((DataMecz)d)},
				{ typeof(DataPozycja), (d) => DataPozycjas.Update((DataPozycja)d)},
				{ typeof(DataRaport), (d) => DataRaports.Update((DataRaport)d)},
				{ typeof(DataSezon), (d) => DataSezons.Update((DataSezon)d)},
				{ typeof(DataSytuacjaMeczowa), (d) => DataSytuacjaMeczowas.Update((DataSytuacjaMeczowa)d)},
				{ typeof(DataSytuacjaTyp), (d) => DataSytuacjaTyps.Update((DataSytuacjaTyp)d)},
				{ typeof(DataUzytkownik), (d) => DataUzytkowniks.Update((DataUzytkownik)d)},
				{ typeof(DataUzytkownikTyp), (d) => DataUzytkownikTyps.Update((DataUzytkownikTyp)d)},
				{ typeof(DataZawodnik), (d) => DataZawodniks.Update((DataZawodnik)d)},
				{ typeof(DataZmiana), (d) => DataZmianas.Update((DataZmiana)d)},
			};

			_DataDictionaryAdd = new Dictionary<Type, Action<AbstractDataModel>>()
			{
				{ typeof(DataDruzyna), (d) => DataDruzynas.Add((DataDruzyna)d)},
				{ typeof(DataGracz), (d) => DataGraczs.Add((DataGracz)d)},
				{ typeof(DataMecz), (d) => DataMeczs.Add((DataMecz)d)},
				{ typeof(DataPozycja), (d) => DataPozycjas.Add((DataPozycja)d)},
				{ typeof(DataRaport), (d) => DataRaports.Add((DataRaport)d)},
				{ typeof(DataSezon), (d) => DataSezons.Add((DataSezon)d)},
				{ typeof(DataSytuacjaMeczowa), (d) => DataSytuacjaMeczowas.Add((DataSytuacjaMeczowa)d)},
				{ typeof(DataSytuacjaTyp), (d) => DataSytuacjaTyps.Add((DataSytuacjaTyp)d)},
				{ typeof(DataUzytkownik), (d) => DataUzytkowniks.Add((DataUzytkownik)d)},
				{ typeof(DataUzytkownikTyp), (d) => DataUzytkownikTyps.Add((DataUzytkownikTyp)d)},
				{ typeof(DataZawodnik), (d) => DataZawodniks.Add((DataZawodnik)d)},
				{ typeof(DataZmiana), (d) => DataZmianas.Add((DataZmiana)d)},
			};

			_DataDictionaryRemove = new Dictionary<Type, Action<AbstractDataModel>>()
			{
				{ typeof(DataDruzyna), (d) => DataDruzynas.Remove((DataDruzyna)d)},
				{ typeof(DataGracz), (d) => DataGraczs.Remove((DataGracz)d)},
				{ typeof(DataMecz), (d) => DataMeczs.Remove((DataMecz)d)},
				{ typeof(DataPozycja), (d) => DataPozycjas.Remove((DataPozycja)d)},
				{ typeof(DataRaport), (d) => DataRaports.Remove((DataRaport)d)},
				{ typeof(DataSezon), (d) => DataSezons.Remove((DataSezon)d)},
				{ typeof(DataSytuacjaMeczowa), (d) => DataSytuacjaMeczowas.Remove((DataSytuacjaMeczowa)d)},
				{ typeof(DataSytuacjaTyp), (d) => DataSytuacjaTyps.Remove((DataSytuacjaTyp)d)},
				{ typeof(DataUzytkownik), (d) => DataUzytkowniks.Remove((DataUzytkownik)d)},
				{ typeof(DataUzytkownikTyp), (d) => DataUzytkownikTyps.Remove((DataUzytkownikTyp)d)},
				{ typeof(DataZawodnik), (d) => DataZawodniks.Remove((DataZawodnik)d)},
				{ typeof(DataZmiana), (d) => DataZmianas.Remove((DataZmiana)d)},
			};
		}

		public DbSet<DataDruzyna> DataDruzynas { get; set; }
		public DbSet<DataGracz> DataGraczs { get; set; }
		public DbSet<DataMecz> DataMeczs { get; set; }
		public DbSet<DataPozycja> DataPozycjas { get; set; }
		public DbSet<DataRaport> DataRaports { get; set; }
		public DbSet<DataSezon> DataSezons { get; set; }
		public DbSet<DataSytuacjaMeczowa> DataSytuacjaMeczowas { get; set; }
		public DbSet<DataSytuacjaTyp> DataSytuacjaTyps { get; set; }
		public DbSet<DataUzytkownik> DataUzytkowniks { get; set; }
		public DbSet<DataUzytkownikTyp> DataUzytkownikTyps { get; set; }
		public DbSet<DataZawodnik> DataZawodniks { get; set; }
		public DbSet<DataZmiana> DataZmianas { get; set; }

		private readonly Dictionary<Type, Func<IEnumerable<AbstractDataModel>>> _DataDictionaryGet;
		private readonly Dictionary<Type, Action<AbstractDataModel>> _DataDictionaryUpdate;
		private readonly Dictionary<Type, Action<AbstractDataModel>> _DataDictionaryAdd;
		private readonly Dictionary<Type, Action<AbstractDataModel>> _DataDictionaryRemove;

		public IEnumerable<T> GetAll<T>() where T : AbstractDataModel
		{
			if (HasModel<T>())
			{
				var list = _DataDictionaryGet[typeof(T)];

				return list().Cast<T>();
			}

			return null;
		}

		public T GetItem<T>(long id) where T : AbstractDataModel
		{
			return GetAll<T>()?.FirstOrDefault(item => item.ID == id);
		}

		public bool AddItem<T>(T item) where T : AbstractDataModel
		{
			if (HasModel<T>() && item != null)
			{
				if (item.ID != 0)
				{
					return false;
				}
				else
				{
					_DataDictionaryAdd[typeof(T)](item);
				}

				SaveChanges();
				return true;
			}

			return false;
		}

		public bool UpdateItem<T>(T item) where T : AbstractDataModel
		{
			if (HasModel<T>() && item != null)
			{
				var list = _DataDictionaryGet[typeof(T)]().ToList();

				if (list.Contains(item) == false) return false;

				_DataDictionaryUpdate[typeof(T)](item);
				SaveChanges();
				return true;
			}

			return false;
		}

		public bool RemoveItem<T>(T item) where T : AbstractDataModel
		{
			if (HasModel<T>() && item != null)
			{
				var list = _DataDictionaryGet[typeof(T)]().ToList();

				if (list.Contains(item) == false) return false;

				_DataDictionaryRemove[typeof(T)](item);
				SaveChanges();
				return true;
			}

			return false;
		}

		public bool HasModel(Type modelType)
		{
			return _DataDictionaryGet.ContainsKey(modelType);
		}

		public bool HasModel<T>() where T : AbstractDataModel
		{
			return HasModel(typeof(T));
		}
	}
}
