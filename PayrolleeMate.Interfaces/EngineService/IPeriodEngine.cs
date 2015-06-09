using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Period;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IPeriodEngine : IFactualPeriodGuides
	{
		IPeriodGuides Guides ();

		uint DayFromOrdinal (MonthPeriod period, DateTime? dateFrom);

		uint DayEndsOrdinal (MonthPeriod period, DateTime? dateEnds);

		Int32[] WeekWorkSchedule (MonthPeriod period, Int32 secondsWeekly, Int32 workdaysWeekly);

		Int32[] MonthWorkSchedule (MonthPeriod period, Int32[] weekSchedule);
	}
}

