using System;
using PayrolleeMate.Common.Periods;
using System.Linq;

namespace PayrolleeMate.EngineService
{
	public class PeriodOperations
	{
		public const Int32 TIME_MULTIPLY_SIXTY = 60;

		public const uint TERM_BEG_FINISHED = 32;

		public const uint TERM_END_FINISHED =  0;

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

		public static uint DateFromInPeriod(MonthPeriod period, DateTime? dateFrom)
		{
			uint dayTermFrom = TERM_BEG_FINISHED;

			DateTime periodDateBeg = new DateTime((int)period.Year(), (int)period.Month(), 1);

			if (dateFrom != null)
			{
				dayTermFrom = (uint)dateFrom.Value.Day;
			}

			if (dateFrom == null || dateFrom < periodDateBeg)
			{
				dayTermFrom = 1;
			}
			return dayTermFrom;
		}

		public static uint DateEndsInPeriod(MonthPeriod period, DateTime? dateEnds)
		{
			uint dayTermEnd = TERM_END_FINISHED;
			uint daysPeriod = (uint)DateTime.DaysInMonth((int)period.Year(), (int)period.Month());

			DateTime periodDateEnd = new DateTime((int)period.Year(), (int)period.Month(), (int)daysPeriod);

			if (dateEnds != null)
			{
				dayTermEnd = (uint)dateEnds.Value.Day;
			}

			if (dateEnds == null || dateEnds > periodDateEnd)
			{
				dayTermEnd = daysPeriod;
			}
			return dayTermEnd;
		}

		public static Int32[] WeekSchedule(MonthPeriod period, Int32 secondsWeekly, Int32 workdaysWeekly)
		{
			Int32 secondsDaily = (secondsWeekly / Math.Min(workdaysWeekly, 7));

			Int32 secRemainder = secondsWeekly - (secondsDaily * workdaysWeekly);

			Int32[] weekSchedule = Enumerable.Range(1, 7).
				Select((x) => (WeekDaySeconds(x, workdaysWeekly, secondsDaily, secRemainder))).ToArray();

			return weekSchedule;
		}

		private static Int32 WeekDaySeconds(int dayOrdinal, int daysOfWork, Int32 secondsDaily, Int32 secRemainder)
		{
			if (dayOrdinal < daysOfWork) 
			{
				return secondsDaily;
			}
			else if (dayOrdinal == daysOfWork)
			{
				return secondsDaily + secRemainder;
			}
			return (0);
		}

		public static Int32[] MonthSchedule(MonthPeriod period, Int32[] weekSchedule)
		{
			int periodDaysCount = period.DaysInMonth();

			int periodBeginCwd = period.WeekDayOfMonth(1);

			Int32[] monthSchedule = Enumerable.Range(1, periodDaysCount).
				Select( (x) => (SecondsFromWeekSchedule(period, weekSchedule, x, periodBeginCwd))).ToArray();

			return monthSchedule;
		}

		private static Int32 SecondsFromWeekSchedule(MonthPeriod period, Int32[] weekSchedule, int dayOrdinal, int periodBeginCwd)
		{
			int dayOfWeek = DayOfWeekFromOrdinal(dayOrdinal, periodBeginCwd);

			return weekSchedule[dayOfWeek-1];
		}

		private static int DayOfWeekFromOrdinal(int dayOrdinal, int periodBeginCwd)
		{
			// dayOrdinal 1..31
			// periodBeginCwd 1..7
			// dayOfWeek 1..7

			int dayOfWeek = (((dayOrdinal - 1) + (periodBeginCwd - 1)) % 7) + 1;

			return dayOfWeek;
		}

		public static Int32[] TimesheetSchedule(Int32[] monthSchedule, uint dayOrdFrom, uint dayOrdEnds)
		{
			Int32[] timeSheet = monthSchedule.Select((x, i) => (HoursFromCalendar(dayOrdFrom, dayOrdEnds, i, x))).ToArray();

			return timeSheet;
		}

		private static int HoursFromCalendar(uint dayOrdFrom, uint dayOrdEnds, int dayIndex, Int32 workSeconds)
		{
			int dayOrdinal = dayIndex + 1;

			int workingDay = workSeconds;

			if (dayOrdFrom > dayOrdinal)
			{
				workingDay = 0;
			}
			if (dayOrdEnds < dayOrdinal)
			{
				workingDay = 0;
			}
			return workingDay;
		}

		public static Int32 TotalTimesheetHours(Int32[] monthTimesheet)
		{
			if (monthTimesheet == null)
			{
				return 0;
			}
			Int32 timesheetHours = monthTimesheet.Aggregate(0, (agr, dh) => (agr + dh));

			return timesheetHours;
		}

	}
}

