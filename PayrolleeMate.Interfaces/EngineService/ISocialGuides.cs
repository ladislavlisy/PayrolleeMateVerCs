using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public interface ISocialGuides
	{
		bool ValidatePeriod (MonthPeriod period);

		Int32 MandatoryBasis ();

		decimal MaximumAnnualBasis ();

		decimal EmployeeFactor ();

		decimal EmployeeGarantFactor ();

		decimal GarantReduceFactor ();

		decimal EmployerFactor ();

		decimal EmployerElevatedFactor ();

	}

}

