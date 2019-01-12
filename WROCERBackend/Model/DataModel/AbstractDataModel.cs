using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WROCERBackend.Model.DataModel
{
	public abstract class AbstractDataModel : IDataModel, IEqualityComparer<IDataModel>, IEquatable<IDataModel>
	{
		public abstract long ID { get; set; }

		public bool Equals(IDataModel left, IDataModel right)
		{
			return left.ID == right.ID;
		}

		public bool Equals(IDataModel other)
		{
			return ID == other.ID;
		}

		public int GetHashCode(IDataModel obj)
		{
			return ID.GetHashCode();
		}
	}
}
