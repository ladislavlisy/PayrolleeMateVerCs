using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public interface IPeriodHealthGuides
	{
		Int32 PeriodMandatoryBasis (MonthPeriod period, bool isMinBaseRequired);

		Int32 PeriodMandatoryBasis (MonthPeriod period);

		decimal PeriodMaximumAnnualBasis (MonthPeriod period);

		decimal PeriodCompoundFactor (MonthPeriod period);
	}
}

