using System;
using System.Linq;

namespace PayrolleeMate.Common.Periods
{
	public class SeqOfYears
	{
		public static readonly UInt16 END_YEAR_ARRAY = 2100;
		public static readonly UInt16 END_YEAR_INTER = 2099;

		public UInt16[] Milestones { get; private set; }

		public SeqOfYears (UInt16[] years)
		{
			this.Milestones = years.OrderBy(x => (x==0 ? END_YEAR_ARRAY : x)).ToArray();
		}

		public SpanOfYears YearsIntervalForPeriod(MonthPeriod period)
		{
			SpanOfYears validSpan = Milestones.Aggregate (new SpanOfYears (), (agr, x) => {
				UInt16 intFrom = agr.YearFrom;
				UInt16 intUpto = agr.YearUpto;
				UInt16 intYear = x;
				if (x == 0)
				{
					intYear = END_YEAR_ARRAY;
				}
				if (period.Year() >= intYear)
				{
					intFrom = intYear;
				}
				if (period.Year() < intYear && intUpto == 0)
				{
					intUpto = (UInt16)(intYear-1);
				}
				return new SpanOfYears(intFrom, intUpto);
			});
			return validSpan;
		}

		public SpanOfYears[] ToYearsIntervalList()
		{
			SpanOfYears[] history = Milestones.Aggregate (new SpanOfYears[0], (agr, x) => {
				SpanOfYears[] firstPart = agr.TakeWhile((y) => (y.YearUpto != 0)).ToArray();
				if (agr.Length == 0)
				{
					return firstPart.Concat( new SpanOfYears[] { 
						new SpanOfYears(x, 0) 
					} ).ToArray();
				}
				else
				{
					SpanOfYears lastPart = agr.Last();	

					if (x == 0)
					{
						UInt16 historyFrom = lastPart.YearFrom;
						UInt16 historyUpto = END_YEAR_INTER;

						return firstPart.Concat( new SpanOfYears[] { 
							new SpanOfYears(historyFrom, historyUpto)
						} ).ToArray();
					}
					else
					{
						UInt16 historyFrom = lastPart.YearFrom;
						UInt16 historyUpto = Math.Max((UInt16)(x-1), historyFrom);

						return firstPart.Concat( new SpanOfYears[] { 
							new SpanOfYears(historyFrom, historyUpto),
							new SpanOfYears(x, 0) 
						} ).ToArray();
					}
				}
			});

			SpanOfYears lastHistoryPart = history.Last();	

			if (lastHistoryPart.YearUpto == 0)
			{
				SpanOfYears[] firstHistoryPart = history.TakeWhile((y) => (y.YearUpto != 0)).ToArray();

				UInt16 historyFrom = lastHistoryPart.YearFrom;
				UInt16 historyUpto = lastHistoryPart.YearFrom;

				return firstHistoryPart.Concat( new SpanOfYears[] { 
					new SpanOfYears(historyFrom, historyUpto)
				} ).ToArray();
			}
			return history;
		}
	}
}

