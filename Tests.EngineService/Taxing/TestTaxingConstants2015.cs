using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestTaxingConstants2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		private IEnginesHistory<ITaxingEngine> CreateEngine()
		{
			IEnginesHistory<ITaxingEngine> engine = TaxingEnginesHistory.CreateEngines ();

			engine.InitEngines ();

			return engine;
		}

		[Test ()]
		public void Should_return_Allowance_Constants_for_Taxing_Engine_when_Year_2015()
		{          
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(2070, engine.PeriodPayerBasicAllowance(testPeriod));
			Assert.AreEqual( 210, engine.PeriodDisabilityDgr1Allowance(testPeriod));
			Assert.AreEqual( 420, engine.PeriodDisabilityDgr2Allowance(testPeriod));
			Assert.AreEqual(1345, engine.PeriodDisabilityDgr3Allowance(testPeriod));
			Assert.AreEqual( 335, engine.PeriodStudyingAllowance(testPeriod));
			Assert.AreEqual(1117, engine.PeriodChildrenRank1stAllowance(testPeriod));
			Assert.AreEqual(1317, engine.PeriodChildrenRank2ndAllowance(testPeriod));
			Assert.AreEqual(1417, engine.PeriodChildrenRank3rdAllowance(testPeriod));
			Assert.AreEqual(1117, engine.PeriodChildrenAllowance(testPeriod, TaxingGuides.ALLOWANCE_CHILDREN_RANK_1ST, false));
			Assert.AreEqual(2234, engine.PeriodChildrenAllowance(testPeriod, TaxingGuides.ALLOWANCE_CHILDREN_RANK_1ST, true));
			Assert.AreEqual(1317, engine.PeriodChildrenAllowance(testPeriod, TaxingGuides.ALLOWANCE_CHILDREN_RANK_2ND, false));
			Assert.AreEqual(2634, engine.PeriodChildrenAllowance(testPeriod, TaxingGuides.ALLOWANCE_CHILDREN_RANK_2ND, true));
			Assert.AreEqual(1417, engine.PeriodChildrenAllowance(testPeriod, TaxingGuides.ALLOWANCE_CHILDREN_RANK_3RD, false));
			Assert.AreEqual(2834, engine.PeriodChildrenAllowance(testPeriod, TaxingGuides.ALLOWANCE_CHILDREN_RANK_3RD, true));
		}

		[Test ()]
		public void Should_return_Factor_Constants_for_Taxing_Engine_when_Year_2015()
		{          
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(15.0m, engine.PeriodAdvancesFactor(testPeriod));
			Assert.AreEqual(15.0m, engine.PeriodWithholdFactor(testPeriod));
			Assert.AreEqual( 7.0m, engine.PeriodSolidaryFactor(testPeriod));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Taxing_Engine_when_Year_2015()
		{          
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(    50, engine.PeriodMinimumValidAmountOfTaxBonus(testPeriod));
			Assert.AreEqual(  9200, engine.PeriodMinimumIncomeRequiredForTaxBonus(testPeriod));
			Assert.AreEqual(106444, engine.PeriodMinimumIncomeToApplySolidaryIncrease(testPeriod));
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Taxing_Engine_when_Year_2015()
		{          
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual( 5025, engine.PeriodMaximumValidAmountOfTaxBonus(testPeriod));
			Assert.AreEqual(  100, engine.PeriodMaximumIncomeToApplyRoundingToSingles(testPeriod));
			Assert.AreEqual(10000, engine.PeriodMaximumIncomeToApplyWithholdTax(testPeriod));
		}
	}
}

