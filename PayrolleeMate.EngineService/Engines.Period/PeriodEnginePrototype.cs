using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Period
{
	public class PeriodEnginePrototype : IPeriodEngine
	{
		public PeriodEnginePrototype  (PeriodGuides currentGuides)
		{
			__guides = currentGuides.Clone() as PeriodGuides;
		}

		private IPeriodGuides __guides;

		#region IPeriodEngine implementation

		public IPeriodGuides Guides ()
		{
			return __guides;
		}
			
		public uint DayFromOrdinal (MonthPeriod period, DateTime? dateFrom)
		{
			return PeriodOperations.DateFromInPeriod(period, dateFrom);
		}

		public uint DayEndsOrdinal (MonthPeriod period, DateTime? dateEnds)
		{
			return PeriodOperations.DateEndsInPeriod(period, dateEnds);
		}

		#endregion

		#region IFactualPeriodGuides implementation

		public int PeriodWeeklyWorkingDays (MonthPeriod period)
		{
			return __guides.WeeklyWorkingDays();
		}

		public int PeriodDailyWorkingHours (MonthPeriod period)
		{
			return __guides.DailyWorkingHours();
		}

		public int PeriodDailyWorkingSeconds (MonthPeriod period)
		{
			return __guides.DailyWorkingSeconds();
		}

		public int PeriodWeeklyWorkingSeconds (MonthPeriod period)
		{
			return __guides.WeeklyWorkingSeconds();
		}

		#endregion
	}
}

