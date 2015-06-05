using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public interface IFactualHealthGuides
	{
		Int32 PeriodMandatoryBasis (MonthPeriod period, bool isMinBaseRequired);

		Int32 PeriodMandatoryBasis (MonthPeriod period);

		decimal PeriodMaximumAnnualBasis (MonthPeriod period);

		decimal PeriodCompoundFactor (MonthPeriod period);

		decimal PeriodMarginalIncomeEmployment (MonthPeriod period);

		decimal PeriodMarginalIncomeAgreeTasks (MonthPeriod period);
	}
}

