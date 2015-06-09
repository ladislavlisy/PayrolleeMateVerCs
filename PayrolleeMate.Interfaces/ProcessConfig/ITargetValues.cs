using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface ITargetValues
	{
		WorkRelationTerms ContractType ();

		WorkHealthTerms HealthWorkType ();

		WorkSocialTerms SocialWorkType ();

		DateTime? DateFrom ();

		DateTime? DateEnds ();

		Int32 TimesheetWeekly ();

		Int32 WorkdaysWeekly ();

		Int32 TimesheetWorked ();

		Int32 TimesheetAbsent ();

		decimal AmountMonthly ();

		uint CodeInterests ();

		uint CodeResidency ();

		uint CodeMandatory ();

		uint CodeStatement ();

		uint CodeHandicaps ();

		uint CodeCardinals ();
	}
}

