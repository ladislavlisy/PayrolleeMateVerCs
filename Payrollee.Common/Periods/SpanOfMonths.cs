using System;
using System.Text;

namespace PayrolleeMate.Common.Periods
{
	public class SpanOfMonths : IComparable
	{
		public static SpanOfMonths CreateFromYear(UInt16 year)
		{
			return new SpanOfMonths(MonthPeriod.BeginYear(year), MonthPeriod.EndYear(year));
		}

		public static SpanOfMonths CreateFromMonth(MonthPeriod period)
		{
			return new SpanOfMonths(period, period);
		}

		public MonthPeriod PeriodFrom { get; private set; }
		public MonthPeriod PeriodUpto { get; private set; }

		public SpanOfMonths()
		{
			this.PeriodFrom = MonthPeriod.Empty();
			this.PeriodUpto = MonthPeriod.Empty();
		}

		public SpanOfMonths(MonthPeriod from, MonthPeriod upto)
		{
			this.PeriodFrom = (MonthPeriod) from.Clone();
			this.PeriodUpto = (MonthPeriod) upto.Clone();
		}

		public static bool operator <(SpanOfMonths x, SpanOfMonths y)
		{
			return (x.PeriodFrom < y.PeriodFrom) || (x.PeriodFrom == y.PeriodFrom && (x.PeriodUpto < y.PeriodUpto));
		}

		public static bool operator >(SpanOfMonths x, SpanOfMonths y)
		{
			return (x.PeriodFrom > y.PeriodFrom) || (x.PeriodFrom == y.PeriodFrom && (x.PeriodUpto > y.PeriodUpto));
		}

		public static bool operator <=(SpanOfMonths x, SpanOfMonths y)
		{
			return (x.PeriodFrom <= y.PeriodFrom) || (x.PeriodFrom == y.PeriodFrom && (x.PeriodUpto <= y.PeriodUpto));
		}

		public static bool operator >=(SpanOfMonths x, SpanOfMonths y)
		{
			return (x.PeriodFrom >= y.PeriodFrom) || (x.PeriodFrom == y.PeriodFrom && (x.PeriodUpto >= y.PeriodUpto));
		}

		public int CompareTo(object obj)
		{
			SpanOfMonths other = obj as SpanOfMonths;

			if (this.PeriodFrom != other.PeriodFrom)
			{
				return this.PeriodFrom.CompareTo(other.PeriodFrom);
			}
			return (this.PeriodUpto.CompareTo(other.PeriodUpto));
		}

		public bool isEqualToInterval(SpanOfMonths other)
		{
			return (this.PeriodFrom == other.PeriodFrom && this.PeriodUpto == other.PeriodUpto);
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			if (obj == null || this.GetType() != obj.GetType())
				return false;

			SpanOfMonths other = obj as SpanOfMonths;

			return this.isEqualToInterval(other);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = this.PeriodFrom.GetHashCode();
			result += prime * result + (int)this.PeriodUpto.GetHashCode();

			return result;
		}

		public string ClassName()
		{
			StringBuilder classNameBuilder = new StringBuilder(PeriodFrom.ToString());

			if(PeriodFrom != PeriodUpto)
			{
				classNameBuilder.Append("to").Append(PeriodUpto.ToString());
			}
			return classNameBuilder.ToString();
		}

		public override string ToString()
		{
			return this.ClassName();
		}

	}
}

