using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public interface IFactualPeriodGuides
	{
		Int32 PeriodWeeklyWorkingDays (MonthPeriod period); 

		Int32 PeriodDailyWorkingHours (MonthPeriod period);

		Int32 PeriodDailyWorkingSeconds (MonthPeriod period); 

		Int32 PeriodWeeklyWorkingSeconds (MonthPeriod period); 
	}
}

