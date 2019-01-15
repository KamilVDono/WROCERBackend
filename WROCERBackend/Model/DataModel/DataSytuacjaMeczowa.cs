using System;
namespace WROCERBackend.Model.DataModel {
	public class DataSytuacjaMeczowa : AbstractDataModel
	{

		public long Czas { get; set; }

		public DataGracz Gracz{ get; set; } 

		public DataSytuacjaTyp Typ{ get; set; } 

	}

}
