using System;
namespace WROCERBackend.Model.DataModel {
	public class DataUzytkownik : AbstractDataModel
	{

		public string Login { get; set; }
		public string Haslo { get; set; }
		public string Imie { get; set; }
		public string Nazwisko { get; set; }

		public DataUzytkownikTyp Typ{ get; set; } 


	}

}
