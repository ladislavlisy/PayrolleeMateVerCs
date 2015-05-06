using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public interface IHealthGuides
	{
		bool ValidatePeriod (MonthPeriod period);

		Int32 MandatoryBasis ();

		decimal MaximumAnnualBasis ();

		decimal CompoundFactor ();

		decimal MarginalIncomeEmployment ();

		decimal MarginalIncomeAgreeTasks ();
	}
}

