using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WROCERBackend.Model.DataModel
{
	public class DataMecz
	{
		[Required]
		public long ID { get; set; }

		[ForeignKey("DataSezon")]
		public long Sezon { get; set; }

		public long Tremin { get; set; }
	}
}
