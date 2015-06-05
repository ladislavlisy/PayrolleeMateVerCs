using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Period
{
	public class PeriodGuides : EngineGeneralGuides, IPeriodGuides
	{
		private readonly Int32 __weeklyWorkingDays;

		private readonly Int32 __dailyWorkingHours;

		private readonly Int32 __dailyWorkingSeconds;

		private readonly Int32 __weeklyWorkingSeconds;

		public static PeriodGuides Guides2015()
		{
			return new PeriodGuides (PeriodProperties2015.YEAR_2015,
				PeriodProperties2015.DAYS_WORKING_WEEKLY,
				PeriodProperties2015.HOURS_WORKING_DAILY);
		}

		private PeriodGuides(
			uint validYear,
			Int32 weeklyWorkingDays,
			Int32 dailyWorkingHours) : base(validYear)
		{
			__weeklyWorkingDays = weeklyWorkingDays;

			__dailyWorkingHours = dailyWorkingHours;

			__dailyWorkingSeconds = PeriodOperations.WorkingSecondsDaily(__dailyWorkingHours);

			__weeklyWorkingSeconds = PeriodOperations.WorkingSecondsWeekly(__weeklyWorkingDays, __dailyWorkingHours);

		}

		public Int32 WeeklyWorkingDays () 
		{
			return __weeklyWorkingDays;
		}

		public Int32 DailyWorkingHours () 
		{
			return __dailyWorkingHours;
		}

		public Int32 DailyWorkingSeconds () 
		{
			return __dailyWorkingSeconds;
		}

		public Int32 WeeklyWorkingSeconds () 
		{
			return __weeklyWorkingSeconds;
		}

		public virtual object Clone()
		{
			PeriodGuides other = (PeriodGuides)this.MemberwiseClone();
			return other;
		}
	}
}

