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

		Int32[] TimesheetWorkSchedule (MonthPeriod period, Int32[] monthSchedule, uint dayFrom, uint dayEnds);

		Int32[] TimesheetAbsenceSchedule (MonthPeriod period, Int32[] absenceHours, uint dayFrom, uint dayEnds);

		Int32 TotalHoursForSalary (MonthPeriod period, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours);

		decimal SalaryAmountFullSchedule (MonthPeriod period, decimal amountMonthly);

		decimal SalaryAmountWorkingTime (MonthPeriod period, decimal amountMonthly, Int32 fulltimeHour, Int32 workingHours, Int32 absenceHours);
	}
}

