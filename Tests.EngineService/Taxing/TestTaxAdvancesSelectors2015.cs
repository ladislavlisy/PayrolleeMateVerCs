﻿using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;
using PayrolleeMate.EngineService.Constants;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestTaxAdvancesSelectors2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_1000_for_Advances_Selector_when_Income_is_1000_and_Advances_Taxing_is_True()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testAdvancesTaxing = true;

			decimal testIncome = 1000m;

			decimal resultValue = engine.AdvancesTaxSelector(testPeriod, 
				testAdvancesTaxing, testIncome);

			Assert.AreEqual( 1000m, resultValue);
		}

		[Test ()]
		public void Should_return_Zero_for_Advances_Selector_when_Income_is_1000_and_Advances_Taxing_is_False()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testAdvancesTaxing = false;

			decimal testIncome = 1000m;

			decimal resultValue = engine.AdvancesTaxSelector(testPeriod, 
				testAdvancesTaxing, testIncome);

			Assert.AreEqual(  0, resultValue);
		}

	}
}

