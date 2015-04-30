using System;
using PayrolleeMate.EngineService.Constants;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public interface ISocialGuides
	{
		bool ValidatePeriod (MonthPeriod period);

		Int32 MandatoryBasis ();

		decimal MaximumAnnualBasis ();

		decimal EmployeeFactor ();

		decimal EmployeePensionsFactor ();

		decimal PensionsReduceFactor ();

		decimal EmployerFactor ();

		decimal EmployerElevatedFactor ();

	}

}

