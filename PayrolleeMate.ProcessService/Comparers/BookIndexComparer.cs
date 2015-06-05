using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService.Comparers
{
	public class BookIndexComparer : IEqualityComparer<KeyValuePair<IBookIndex, IBookResult>>
	{
		public bool Equals(KeyValuePair<IBookIndex, IBookResult> pair_x, KeyValuePair<IBookIndex, IBookResult> pair_y)
		{
			//Let's say we are comparing the keys only.
			return pair_x.Key.CompareTo(pair_y.Key)==0;
		}

		public int GetHashCode(KeyValuePair<IBookIndex, IBookResult> pair)
		{
			return pair.Key.GetHashCode();
		}
	}
}

