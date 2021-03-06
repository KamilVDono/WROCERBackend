﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WROCERBackend.Model.DataModel
{
	public abstract class AbstractDataModel : IDataModel, IEqualityComparer<AbstractDataModel>, IEquatable<AbstractDataModel>
	{
		[Key]
		public long ID { get; set; }

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

		public static bool operator ==(AbstractDataModel left, AbstractDataModel right)
		{
			if (ReferenceEquals(left, null))
			{
				return ReferenceEquals(right, null);
			}
			if (ReferenceEquals(right, null)) return false;
			return left.Equals(right);
		}

		public static bool operator !=(AbstractDataModel left, AbstractDataModel right)
		{
			return !(left == right);
		}
	}
}
