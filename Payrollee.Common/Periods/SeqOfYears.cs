using System;
using System.Linq;

namespace PayrolleeMate.Common.Periods
{
	public class SeqOfYears
	{
		public static readonly UInt16 END_YEAR_ARRAY = 2100;
		public static readonly UInt16 END_YEAR_INTER = 2099;

		public SpanOfYears[] Milestones { get; private set; }

		static UInt16 TransformZeroToUpto(UInt16 year)
		{
			return (year == 0 ? SeqOfYears.END_YEAR_ARRAY : year);
		}

		private static SpanOfYears TransformYearsToSpans(UInt16 yearFrom, UInt16 yearUpto)
		{
			UInt16 tranUpto = SeqOfYears.TransformZeroToUpto(yearUpto);
			UInt16 spanUpto = (tranUpto == yearFrom ? tranUpto : (UInt16)(tranUpto - 1u));
			return new SpanOfYears(yearFrom, spanUpto);
		}

		public SeqOfYears (UInt16[] years)
		{
			UInt16[] sortedYears = years.OrderBy((x) => SeqOfYears.TransformZeroToUpto(x)).ToArray();
			int beginsCount = sortedYears.Length - 1;
			UInt16[] beginsYears = sortedYears.Take(beginsCount).ToArray();
			UInt16[] finishYears = sortedYears.Skip(1).ToArray();
			UInt16[][] sortedZiped = beginsYears.Zip(finishYears, (x, y) => new UInt16[] {x, y}).ToArray();
			this.Milestones = sortedZiped.Select((x) => SeqOfYears.TransformYearsToSpans(x.First(), x.Last())).ToArray();
		}

		private static bool SelectForPeriod(SpanOfYears span, MonthPeriod period) 
		{
			return period.Year() >= span.YearFrom && period.Year() <= span.YearUpto;
		}

		public SpanOfYears YearsIntervalForPeriod(MonthPeriod period)
		{
			SpanOfYears[] validSpan = Milestones.Where((x) => SeqOfYears.SelectForPeriod(x, period)).ToArray();
			SpanOfYears firstSpan = validSpan.FirstOrDefault();
			return firstSpan == null ? SpanOfYears.Empty() : firstSpan;
		}

		public SpanOfYears[] YearsIntervalList()
		{
			return Milestones.ToArray();
		}
	}
}

