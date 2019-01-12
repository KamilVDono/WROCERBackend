using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WROCERBackend.Model.DataModel
{
	public class DataSezon
	{
		[Required]
		public long ID { get; set; }

		public int Rok { get; set; }
	}
}
