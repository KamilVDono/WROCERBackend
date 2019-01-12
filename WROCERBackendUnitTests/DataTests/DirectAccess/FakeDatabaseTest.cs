using System;
using System.Collections.Generic;
using System.Linq;
using WROCERBackend.Model.DataDirectAccess;
using WROCERBackend.Model.DataModel;
using Xunit;

namespace WROCERBackendUnitTests.DataTests.DirectAccess
{
	public class FakeDatabaseTest
	{
		FakeDatabase _Database;

		public FakeDatabaseTest()
		{
			Dictionary<Type, List<AbstractDataModel>> _Data = new Dictionary<Type, List<AbstractDataModel>>();
			FillTestData(_Data);
			_Database = new FakeDatabase(_Data);
		}

		private static void FillTestData(Dictionary<Type, List<AbstractDataModel>> _Data)
		{
			_Data.Add(typeof(DataSezon), new List<AbstractDataModel>()
			{
				new DataSezon() {ID = 1, Rok = 2018},
				new DataSezon() {ID = 2, Rok = 2019},
			});

			_Data.Add(typeof(DataMecz), new List<AbstractDataModel>()
			{
				new DataMecz() {ID = 1, Sezon = 1, Tremin = (new DateTime(2018, 1, 5, 18, 00, 00)).Ticks},
				new DataMecz() {ID = 2, Sezon = 1, Tremin = (new DateTime(2018, 2, 5, 18, 00, 00)).Ticks},
				new DataMecz() {ID = 3, Sezon = 1, Tremin = (new DateTime(2018, 3, 5, 18, 00, 00)).Ticks},
				new DataMecz() {ID = 4, Sezon = 2, Tremin = (new DateTime(2019, 4, 5, 18, 00, 00)).Ticks},
				new DataMecz() {ID = 5, Sezon = 2, Tremin = (new DateTime(2019, 5, 5, 18, 00, 00)).Ticks},
				new DataMecz() {ID = 6, Sezon = 2, Tremin = (new DateTime(2019, 6, 5, 18, 00, 00)).Ticks},
			});
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

			Assert.Null(models);
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
			bool success = _Database.AddItem<DataSezon>(new DataSezon(){ID = 1, Rok = 2020});

			Assert.False(success);
		}

		[Fact]
		public void AddItem_NewWithID()
		{
			bool success = _Database.AddItem<DataSezon>(new DataSezon() { ID = 3, Rok = 2020});

			Assert.True(success);
		}

		[Fact]
		public void AddItem_NewWithoutID()
		{
			long biggestId = _Database.GetAll<DataSezon>().Max(i => i.ID);
			var item = new DataSezon() {Rok = 2020};
			bool success = _Database.AddItem<DataSezon>(item);

			Assert.True(success);
			Assert.Equal(biggestId+1, item.ID);
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
			var item = new DataSezon() {ID = 4, Rok = 2020};
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
	}
}
