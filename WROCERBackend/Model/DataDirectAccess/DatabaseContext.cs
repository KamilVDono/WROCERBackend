using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WROCERBackend.Model.DataModel;
using WROCERBackend.Utils;


namespace WROCERBackend.Model.DataDirectAccess
{
	public class DatabaseContext : DbContext, IDataDirectAccess
	{
		public DatabaseContext(DbContextOptions options)
			: base(options)
		{
			_DataDictionaryGet = new Dictionary<Type, Func<IEnumerable<AbstractDataModel>>>()
			{
				{ typeof(DataDruzyna), () => EntityFrameworkQueryableExtensions.Include<DataDruzyna>(DataDruzynas, "Trener").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataGracz), () => EntityFrameworkQueryableExtensions.Include<DataGracz>(DataGraczs.Include("Sklad").Include("Pozycja").Include("Zawodnik"), "Raport").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataMecz), () => EntityFrameworkQueryableExtensions.Include<DataMecz>(DataMeczs.Include("Sedzia").Include("Gospodarz").Include("Gosc"), "Sezon").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataPozycja), () => DataPozycjas.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataRaport), () => EntityFrameworkQueryableExtensions.Include<DataRaport>(DataRaports, "Mecz").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataSezon), () => DataSezons.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataSytuacjaMeczowa), () => EntityFrameworkQueryableExtensions.Include<DataSytuacjaMeczowa>(DataSytuacjaMeczowas.Include("Gracz"), "Typ").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataSytuacjaTyp), () => DataSytuacjaTyps.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataUzytkownik), () => EntityFrameworkQueryableExtensions.Include<DataUzytkownik>(DataUzytkowniks, "Typ").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataUzytkownikTyp), () => DataUzytkownikTyps.Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataZawodnik), () => EntityFrameworkQueryableExtensions.Include<DataZawodnik>(DataZawodniks.Include("Pozycja"), "Druzyna").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataZmiana), () => EntityFrameworkQueryableExtensions.Include<DataZmiana>(DataZmianas.Include("Schodzacy"), "Wchodzacy").Cast<AbstractDataModel>().AsEnumerable()},
				{ typeof(DataSklad), () => DataSklads.Cast<AbstractDataModel>().AsEnumerable()},
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
				{ typeof(DataSklad), (d) => DataSklads.Update((DataSklad)d)},
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
				{ typeof(DataSklad), (d) => DataSklads.Add((DataSklad)d)},
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
				{ typeof(DataSklad), (d) => DataSklads.Remove((DataSklad)d)},
			};
		}

		public Microsoft.EntityFrameworkCore.DbSet<DataDruzyna> DataDruzynas { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataGracz> DataGraczs { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataMecz> DataMeczs { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataPozycja> DataPozycjas { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataRaport> DataRaports { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataSezon> DataSezons { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataSytuacjaMeczowa> DataSytuacjaMeczowas { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataSytuacjaTyp> DataSytuacjaTyps { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataUzytkownik> DataUzytkowniks { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataUzytkownikTyp> DataUzytkownikTyps { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataZawodnik> DataZawodniks { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataZmiana> DataZmianas { get; set; }
		public Microsoft.EntityFrameworkCore.DbSet<DataSklad> DataSklads { get; set; }

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

			return new List<T>();
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

				item.NullReferences();
				_DataDictionaryUpdate[typeof(T)](item);
				SaveChanges();
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// I know I don't need both statements, and my guess is I need the first, but at this point I don't know anything anymore
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
			}
		}
	}
}
