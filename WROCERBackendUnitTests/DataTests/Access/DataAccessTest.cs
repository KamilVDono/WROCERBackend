using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataDirectAccess;
using WROCERBackend.Model.DataModel;
using WROCERBackendUnitTests.DataTests.DirectAccess;
using Xunit;

namespace WROCERBackendUnitTests.DataTests.Access
{
	public class DataAccessTest
	{
		WrocerDataAccess _Database;

		public DataAccessTest()
		{
			Dictionary<Type, List<AbstractDataModel>> _Data = new Dictionary<Type, List<AbstractDataModel>>();
			FakeDatabase.FillData(_Data);
			var fakeDataBase = new FakeDatabase(_Data);
			_Database = new WrocerDataAccess(new List<IDataDirectAccess>(){ fakeDataBase });
		}

		[Fact]
		public void HasModel_FakeDataModel()
		{
			bool hasGeneric = _Database.HasModel<FakeDataModel>();
			bool hasType = _Database.HasModel(typeof(FakeDataModel));

			Assert.False(hasGeneric);
			Assert.False(hasType);
		}

		[Fact]
		public void HasModel_DataMecz()
		{
			bool hasGeneric = _Database.HasModel<DataMecz>();
			bool hasType = _Database.HasModel(typeof(DataMecz));

			Assert.True(hasGeneric);
			Assert.True(hasType);
		}

		[Fact]
		public void HasModel_DataSezon()
		{
			bool hasGeneric = _Database.HasModel<DataSezon>();
			bool hasType = _Database.HasModel(typeof(DataSezon));

			Assert.True(hasGeneric);
			Assert.True(hasType);
		}

		[Fact]
		public void GetAll_FakeModel()
		{
			var models = _Database.GetAll<FakeDataModel>();

			Assert.Empty(models);
		}

		[Fact]
		public void GetAll_DataSezon()
		{
			var models = _Database.GetAll<DataSezon>();

			Assert.IsAssignableFrom<IEnumerable<DataSezon>>(models);
			Assert.NotNull(models);
			Assert.Equal(2, models.Count());
		}

		[Fact]
		public void GetAll_DataMecze()
		{
			var models = _Database.GetAll<DataMecz>();

			Assert.IsAssignableFrom<IEnumerable<DataMecz>>(models);
			Assert.NotNull(models);
			Assert.Equal(6, models.Count());
		}

		[Fact]
		public void GetItem_FakeModel()
		{
			var model = _Database.GetItem<FakeDataModel>(0);

			Assert.Null(model);
		}

		[Fact]
		public void GetItem_DataSezon_Outside()
		{
			var modelZero = _Database.GetItem<DataSezon>(0);
			var modelTen = _Database.GetItem<DataSezon>(10);

			Assert.Null(modelZero);
			Assert.Null(modelTen);
		}

		[Fact]
		public void GetItem_DataMecz_Inside()
		{
			var model = _Database.GetItem<DataMecz>(1);

			Assert.IsType<DataMecz>(model);
			Assert.Equal(1, model.ID);
		}

		[Fact]
		public void AddItem_Null()
		{
			bool success = _Database.AddItem<DataSezon>(null);

			Assert.False(success);
		}

		[Fact]
		public void AddItem_WithSameId()
		{
			bool success = _Database.AddItem<DataSezon>(new DataSezon() { ID = 1, Rok = 2020 });

			Assert.False(success);
		}

		[Fact]
		public void AddItem_NewWithID()
		{
			bool success = _Database.AddItem<DataSezon>(new DataSezon() { ID = 3, Rok = 2020 });

			Assert.True(success);
		}

		[Fact]
		public void AddItem_NewWithoutID()
		{
			long biggestId = _Database.GetAll<DataSezon>().Max(i => i.ID);
			var item = new DataSezon() { Rok = 2020 };
			bool success = _Database.AddItem<DataSezon>(item);

			Assert.True(success);
			Assert.Equal(biggestId + 1, item.ID);
		}

		[Fact]
		public void UpdateItem_Null()
		{
			bool success = _Database.UpdateItem<DataSezon>(null);

			Assert.False(success);
		}

		[Fact]
		public void UpdateItem_NoExisting()
		{
			var item = new DataSezon() { ID = 4, Rok = 2020 };
			//_Database.AddItem(item);
			item.Rok = 2021;
			bool success = _Database.UpdateItem<DataSezon>(item);

			Assert.False(success);
		}

		[Fact]
		public void UpdateItem_Existing()
		{
			var item = new DataSezon() { Rok = 2020 };
			_Database.AddItem(item);
			item.Rok = 2021;
			bool success = _Database.UpdateItem<DataSezon>(item);

			int inBaseRok = _Database.GetItem<DataSezon>(item.ID).Rok;

			Assert.True(success);
			Assert.Equal(2021, inBaseRok);
		}

		[Fact]
		public void Item_Eq()
		{
			var item1 = new DataSezon() { ID = 1 };
			var item2 = new DataSezon() { ID = 1 };

			Assert.True(item1 == item2);
		}
	}
}
