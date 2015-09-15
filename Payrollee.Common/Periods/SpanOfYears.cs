using System;
using System.Text;

namespace PayrolleeMate.Common.Periods
{
	public class SpanOfYears : IComparable
	{
		public static SpanOfYears CreateFromYear(UInt16 year)
		{
			return new SpanOfYears(year, year);
		}

		public static SpanOfYears CreateFromYearToYear(UInt16 from, UInt16 upto)
		{
			return new SpanOfYears(from, upto);
		}

		public UInt16 YearFrom { get; private set; }
		public UInt16 YearUpto { get; private set; }

		public SpanOfYears ()
		{
			this.YearFrom = 0;
			this.YearUpto = 0;
		}

		public SpanOfYears (UInt16 from, UInt16 upto)
		{
			this.YearFrom = from;
			this.YearUpto = upto;
		}

		public static bool operator <(SpanOfYears x, SpanOfYears y)
		{
			return (x.YearFrom < y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto < y.YearUpto));
		}

		public static bool operator >(SpanOfYears x, SpanOfYears y)
		{
			return (x.YearFrom > y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto > y.YearUpto));
		}

		public static bool operator <=(SpanOfYears x, SpanOfYears y)
		{
			return (x.YearFrom <= y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto <= y.YearUpto));
		}

		public static bool operator >=(SpanOfYears x, SpanOfYears y)
		{
			return (x.YearFrom >= y.YearFrom) || (x.YearFrom == y.YearFrom && (x.YearUpto >= y.YearUpto));
		}

		public int CompareTo(object obj)
		{
			SpanOfYears other = obj as SpanOfYears;

			if (this.YearFrom != other.YearFrom)
			{
				return this.YearFrom.CompareTo(other.YearFrom);
			}
			return (this.YearUpto.CompareTo(other.YearUpto));
		}

		public bool isEqualToInterval(SpanOfYears other)
		{
			return (this.YearFrom == other.YearFrom && this.YearUpto == other.YearUpto);
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			SpanOfYears other = obj as SpanOfYears;

			return this.isEqualToInterval(other);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.YearFrom;
			result += prime * result + (int)this.YearUpto;

			return result;
		}

		public string ClassName()
		{
			StringBuilder classNameBuilder = new StringBuilder(YearFrom.ToString ());

			if (YearFrom != YearUpto) {
				classNameBuilder.Append("to").Append(YearUpto.ToString());
			}
			return classNameBuilder.ToString();
		}

		public override string ToString()
		{
			return this.ClassName();
		}

	}
}

