using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public interface IPeriodSocialGuides
	{
		Int32 PeriodMandatoryBasis (MonthPeriod period);

		decimal PeriodMaximumAnnualBasis (MonthPeriod period);

		decimal PeriodEmployeeFactor (MonthPeriod period, bool isPension2sScheme);

		decimal PeriodEmployeeFactor (MonthPeriod period);

		decimal PeriodEmployeePensionsFactor (MonthPeriod period, bool isPension2sScheme);

		decimal PeriodEmployeePensionsFactor (MonthPeriod period);

		decimal PeriodPensionsReduceFactor (MonthPeriod period);

		decimal PeriodEmployerFactor (MonthPeriod period);

		decimal PeriodEmployerElevatedFactor (MonthPeriod period);
	}
}

