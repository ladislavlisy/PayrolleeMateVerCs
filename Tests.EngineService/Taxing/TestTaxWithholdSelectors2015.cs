using NUnit.Framework;
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
	public class TestTaxWithholdSelectors2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_1000_for_Withhold_Selector_when_Income_is_1000_and_Withhold_Taxing_is_True()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testWithholdTaxing = true;

			decimal testIncome = 1000m;

			decimal resultValue = engine.WithholdTaxSelector(testPeriod, 
				testWithholdTaxing, testIncome);

			Assert.AreEqual( 1000m, resultValue);
		}

		[Test ()]
		public void Should_return_Zero_for_Withhold_Selector_when_Income_is_1000_and_Withhold_Taxing_is_False()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testWithholdTaxing = false;

			decimal testIncome = 1000m;

			decimal resultValue = engine.WithholdTaxSelector(testPeriod, 
				testWithholdTaxing, testIncome);

			Assert.AreEqual(  0, resultValue);
		}

	}
}

