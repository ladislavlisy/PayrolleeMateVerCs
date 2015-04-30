using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public interface IHealthGuides
	{
		Int32 MandatoryBasis ();

		decimal MaximumAnnualBasis ();

		decimal EmployerFactor ();

		decimal EmployeeFactor ();

		decimal CompoundFactor ();
	}
}

