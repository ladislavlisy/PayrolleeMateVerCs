using System;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IResultValues : ITargetValues
	{
		uint PeriodDayFromOrdinal ();

		uint PeriodDayEndsOrdinal ();

		Int32[] ShiftTimetable ();

		Int32[] WorkTimetable ();

		Int32[] OverTimetable ();

		Int32[] AbsenceTimetable ();

		Int32 WorktimeCount ();

		Int32 OvertimeCount ();

		Int32 AbsenceCount ();


		Int32 RecordTime ();

		decimal RecordAmount ();

		decimal RecordIncome ();


		decimal AmountIncome ();

		decimal AmountPayments ();

		decimal AmountDeducted ();
	}
}

