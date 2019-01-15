using System;
namespace WROCERBackend.Model.DataModel {
	public class DataGracz : AbstractDataModel
	{
		public long CzasNaBoisku { get; set; }

		public DataZawodnik Zawodnik{ get; set; } 

		public DataRaport Raport{ get; set; } 

	}

}
