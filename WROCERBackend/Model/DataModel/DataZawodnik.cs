using System;
namespace WROCERBackend.Model.DataModel {
	public class DataZawodnik : AbstractDataModel
	{

		public string Imie { get; set; }
		public string Nazwisko { get; set; }
		public long DataUrodzenia { get; set; }
		public int NumerKoszulki { get; set; }

		public DataPozycja Pozycja{ get; set; } 
		public DataDruzyna Druzyna{ get; set; } 


	}

}
