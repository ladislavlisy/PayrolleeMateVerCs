using System;

namespace PayrolleeMate.EngineService
{
	public class PeriodOperations
	{
		public const Int32 TIME_MULTIPLY_SIXTY = 60;

		public static int WorkingSecondsDaily (int workingHours)
		{
			Int32 secondsInHour = (TIME_MULTIPLY_SIXTY * TIME_MULTIPLY_SIXTY);

			return (workingHours*secondsInHour);
		}

		public static int WorkingSecondsWeekly (int workingDays, int workingHours)
		{
			Int32 secondsDaily = WorkingSecondsDaily (workingHours);

			return (workingDays*secondsDaily);
		}
	}
}

