using System;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface ITargetValues
	{
		DateTime? DateFrom ();

		DateTime? DateEnds ();

		Int32 TimesheetWeekly ();

		Int32 TimesheetWorked ();

		Int32 TimesheetMissed ();

		decimal AmountMonthly ();

		uint CodeInterests ();

		uint CodeResidency ();

		uint CodeMandatory ();

		uint CodeStatement ();

		uint CodeHandicaps ();

		uint CodeCardinals ();
	}
}

