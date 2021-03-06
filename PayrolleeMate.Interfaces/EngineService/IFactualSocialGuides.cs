﻿using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public interface IFactualSocialGuides
	{
		Int32 PeriodMandatoryBasis (MonthPeriod period);

		decimal PeriodMaximumAnnualBasis (MonthPeriod period);

		decimal PeriodEmployeeFactor (MonthPeriod period, bool isPension2sScheme);

		decimal PeriodEmployeeFactor (MonthPeriod period);

		decimal PeriodEmployeeGarantFactor (MonthPeriod period, bool isPension2sScheme);

		decimal PeriodEmployeeGarantFactor (MonthPeriod period);

		decimal PeriodPensionsReduceFactor (MonthPeriod period);

		decimal PeriodEmployerFactor (MonthPeriod period);

		decimal PeriodEmployerElevatedFactor (MonthPeriod period);

		decimal PeriodMarginalIncomeEmployment (MonthPeriod period);

		decimal PeriodMarginalIncomeAgreeTasks (MonthPeriod period);
	}
}

