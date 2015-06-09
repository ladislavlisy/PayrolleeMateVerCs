using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.Common.Rounding;

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

		public Int32[] WeekWorkSchedule (MonthPeriod period, Int32 secondsWeekly, Int32 workdaysWeekly)
		{
			return PeriodOperations.WeekSchedule(period, secondsWeekly, workdaysWeekly);
		}

		public Int32[] MonthWorkSchedule (MonthPeriod period, Int32[] weekSchedule)
		{
			return PeriodOperations.MonthSchedule(period, weekSchedule);
		}

		public Int32[] TimesheetWorkSchedule (MonthPeriod period, Int32[] monthSchedule, uint dayFrom, uint dayEnds)
		{
			return PeriodOperations.TimesheetSchedule(period, monthSchedule, dayFrom, dayEnds);
		}

		public Int32[] TimesheetAbsenceSchedule (MonthPeriod period, Int32[] absenceHours, uint dayFrom, uint dayEnds)
		{
			return PeriodOperations.TimesheetAbsence(period, absenceHours, dayFrom, dayEnds);
		}

		public Int32 TotalHoursForSalary (MonthPeriod period, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours)
		{
			return PayRounding.TotalHoursForPayment(fulltimeHour, workingHours, absenceHours);
		}

		public decimal SalaryAmountFullSchedule (MonthPeriod period, decimal amountMonthly)
		{
			return PayRounding.FactorizeAmount(amountMonthly, 1m);
		}

		public decimal SalaryAmountWorkingTime (MonthPeriod period, decimal amountMonthly, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours)
		{
			return PayRounding.MonthlyAmountWithWorkingHours(amountMonthly, 1m, fulltimeHour, workingHours, absenceHours);
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

