using System;
namespace WROCERBackend.Model.DataModel {
	public class DataGracz : AbstractDataModel
	{
		public long CzasNaBoisku { get; set; }

		public int Numer { get; set; }

		public DataSklad Sklad { get; set; }

		public DataPozycja Pozycja { get; set; }

		public DataZawodnik Zawodnik{ get; set; } 

		public DataRaport Raport{ get; set; } 

	}

}
