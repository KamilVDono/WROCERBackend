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
			Dictionary<Type, List<IDataModel>> _Data = new Dictionary<Type, List<IDataModel>>();
			FillTestData(_Data);
			_Database = new FakeDatabase(_Data);
		}

		private static void FillTestData(Dictionary<Type, List<IDataModel>> _Data)
		{
			_Data.Add(typeof(DataSezon), new List<IDataModel>()
			{
				new DataSezon() {ID = 1, Rok = 2018},
				new DataSezon() {ID = 2, Rok = 2019},
			});

			_Data.Add(typeof(DataMecz), new List<IDataModel>()
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
			bool hasGeneric = _Database.HasModel<FakeDatabase>();
			bool hasType = _Database.HasModel(typeof(FakeDatabase));

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

			Assert.IsAssignableFrom<IEnumerable<FakeDataModel>>(models);
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

			Assert.IsType<FakeDataModel>(model);
			Assert.Null(model);
		}

		[Fact]
		public void GetItem_DataSezon_Outside()
		{
			var modelZero = _Database.GetItem<DataSezon>(0);
			var modelTen = _Database.GetItem<DataSezon>(10);

			Assert.IsType<DataSezon>(modelZero);
			Assert.IsType<DataSezon>(modelTen);
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
	}
}
