using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public interface ISocialGuides
	{
		Int32 MandatoryBasis ();

		decimal MaximumAnnualBasis ();

		decimal EmployeeFactor ();

		decimal EmployeePensionsFactor ();

		decimal PensionsReduceFactor ();

		decimal EmployerFactor ();

		decimal EmployerElevatedFactor ();

	}

}

