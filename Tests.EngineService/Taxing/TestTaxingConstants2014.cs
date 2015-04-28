﻿using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestTaxingConstants2014
	{
		private static readonly MonthPeriod period2014 = new MonthPeriod (2014, 1);

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

			ITaxingEngine engine = engines.FindEngine (period2014);

			Assert.AreEqual(2070, engine.Guides().PayerBasicAllowance());
			Assert.AreEqual( 210, engine.Guides().DisabilityDgr1Allowance());
			Assert.AreEqual( 420, engine.Guides().DisabilityDgr2Allowance());
			Assert.AreEqual(1345, engine.Guides().DisabilityDgr3Allowance());
			Assert.AreEqual( 335, engine.Guides().StudyingAllowance());
			Assert.AreEqual(1117, engine.Guides().ChildrenRank1stAllowance());
			Assert.AreEqual(1117, engine.Guides().ChildrenRank2ndAllowance());
			Assert.AreEqual(1117, engine.Guides().ChildrenRank3rdAllowance());
			Assert.AreEqual(1117, engine.Guides().ChildrenAllowance(TaxingGuides.ALLOWANCE_CHILDREN_RANK_1ST, false));
			Assert.AreEqual(2234, engine.Guides().ChildrenAllowance(TaxingGuides.ALLOWANCE_CHILDREN_RANK_1ST, true));
			Assert.AreEqual(1117, engine.Guides().ChildrenAllowance(TaxingGuides.ALLOWANCE_CHILDREN_RANK_2ND, false));
			Assert.AreEqual(2234, engine.Guides().ChildrenAllowance(TaxingGuides.ALLOWANCE_CHILDREN_RANK_2ND, true));
			Assert.AreEqual(1117, engine.Guides().ChildrenAllowance(TaxingGuides.ALLOWANCE_CHILDREN_RANK_3RD, false));
			Assert.AreEqual(2234, engine.Guides().ChildrenAllowance(TaxingGuides.ALLOWANCE_CHILDREN_RANK_3RD, true));
		}

		[Test ()]
		public void Should_return_Factor_Constants_for_Taxing_Engine_when_Year_2015()
		{          
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine = engines.FindEngine (period2014);

			Assert.AreEqual(15.0m, engine.Guides().AdvancesFactor());
			Assert.AreEqual(15.0m, engine.Guides().WithholdFactor());
			Assert.AreEqual( 7.0m, engine.Guides().SolidaryFactor());
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Taxing_Engine_when_Year_2015()
		{          
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine = engines.FindEngine (period2014);

			Assert.AreEqual(    50, engine.Guides().MinimumValidAmountOfTaxBonus());
			Assert.AreEqual(  8500, engine.Guides().MinimumIncomeRequiredForTaxBonus());
			Assert.AreEqual(103768, engine.Guides().MinimumIncomeToApplySolidaryIncrease());
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Taxing_Engine_when_Year_2015()
		{          
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine = engines.FindEngine (period2014);

			Assert.AreEqual( 5025, engine.Guides().MaximumValidAmountOfTaxBonus());
			Assert.AreEqual(  100, engine.Guides().MaximumIncomeToApplyRoundingToSingles());
			Assert.AreEqual(10000, engine.Guides().MaximumIncomeToApplyWithholdTax());
		}
	}
}

