using System;
using PayrolleeMate.EngineService.Constants;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public interface IHealthGuides
	{
		bool ValidatePeriod (MonthPeriod period);

		Int32 MandatoryBasis ();

		decimal MaximumAnnualBasis ();

		decimal EmployerFactor ();

		decimal EmployeeFactor ();

		decimal CompoundFactor ();
	}
}

