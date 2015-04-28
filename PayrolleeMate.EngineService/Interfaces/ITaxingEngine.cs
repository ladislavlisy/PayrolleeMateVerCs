using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Taxing;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface ITaxingEngine
	{
		ITaxingGuides Guides();

		decimal AdvancesBasisRoundedWithPartial(decimal taxableHealth, decimal taxableSocial, decimal taxableIncome);

		decimal AdvancesBasisRounded(decimal taxableIncome);

		decimal SolidaryBasis(decimal income);

		long AdvancesPartResult(decimal generallBasis);

		long SolidaryPartResult(decimal solidaryBasis);

		long AdvancesResult(decimal taxableIncome, decimal generallBasis, decimal solidaryBasis);
	}

}

