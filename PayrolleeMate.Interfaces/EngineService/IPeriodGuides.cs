using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Period
{
	public interface IPeriodGuides
	{
		bool ValidatePeriod (MonthPeriod period);

		Int32 WeeklyWorkingDays (); 

		Int32 DailyWorkingHours ();

		Int32 DailyWorkingSeconds (); 

		Int32 WeeklyWorkingSeconds (); 
	}
}

