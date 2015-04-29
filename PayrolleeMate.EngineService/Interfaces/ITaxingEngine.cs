using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Taxing;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface ITaxingEngine
	{
		ITaxingGuides Guides();

		long AdvancesResult (MonthPeriod period, decimal taxableIncome, decimal generalBasis, decimal solidaryBasis);

		long AdvancesRegularyTax (MonthPeriod period, decimal generallBasis);

		long AdvancesSolidaryTax (MonthPeriod period, decimal solidaryBasis);

		decimal AdvancesSolidaryBasis (MonthPeriod period, decimal taxableIncome);

		decimal AdvancesRoundedBasisWithPartial (MonthPeriod period, decimal taxableHealth, decimal taxableSocial, decimal taxableIncome);

		decimal AdvancesRoundedBasis (MonthPeriod period, decimal taxableIncome);
	}

}

