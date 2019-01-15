using System;
namespace WROCERBackend.Model.DataModel {
	public class DataZmiana : AbstractDataModel
	{

		public long Czas { get; set; }

		public DataGracz Schodzacy{ get; set; } 
		public DataGracz Wchodzacy{ get; set; } 

	}

}
