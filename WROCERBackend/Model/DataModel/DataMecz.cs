using System;
namespace WROCERBackend.Model.DataModel {
	public class DataMecz : AbstractDataModel
	{

		public long Termin { get; set; }

		public DataUzytkownik Sedzia{ get; set; } 
		public DataDruzyna Gospodarz{ get; set; } 
		public DataDruzyna Gosc{ get; set; } 

		public DataSezon Sezon{ get; set; } 

	}

}
