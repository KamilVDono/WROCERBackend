using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WROCERBackend.Model.DataModel
{
	public abstract class AbstractDataModel : IDataModel, IEqualityComparer<AbstractDataModel>, IEquatable<AbstractDataModel>
	{
		public abstract long ID { get; set; }

		public bool Equals(AbstractDataModel left, AbstractDataModel right)
		{
			return left.ID == right.ID;
		}

		public bool Equals(AbstractDataModel other)
		{
			return ID == other.ID;
		}

		public int GetHashCode(AbstractDataModel obj)
		{
			return ID.GetHashCode();
		}
	}
}
