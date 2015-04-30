using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Taxing;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface ITaxingEngine : IPeriodTaxingGuides
	{
		ITaxingGuides Guides();

		Int32 AdvancesResult (MonthPeriod period, decimal taxableIncome, decimal generalBasis, decimal solidaryBasis);

		Int32 AdvancesRegularyTax (MonthPeriod period, decimal generallBasis);

		Int32 AdvancesSolidaryTax (MonthPeriod period, decimal solidaryBasis);

		decimal AdvancesSolidaryBasis (MonthPeriod period, decimal taxableIncome);

		decimal AdvancesRoundedBasisWithPartial (MonthPeriod period, decimal taxableHealth, decimal taxableSocial, decimal taxableIncome);

		decimal AdvancesRoundedBasis (MonthPeriod period, decimal taxableIncome);
	}

}

