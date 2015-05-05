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

		[Test ()]
		public void Should_return_Zero_for_Advances_Basis_when_Income_is_Negaive_1000()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = -1000m;

			decimal resultValue = engine.AdvancesRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual(  0, resultValue);
		}

		[Test ()]
		public void Should_return_100_for_Advances_Basis_when_Income_is_99_01()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 99.01m;

			decimal resultValue = engine.AdvancesRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 100, resultValue);
		}

		[Test ()]
		public void Should_return_100_for_Advances_Basis_when_Income_is_99_99()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 99.99m;

			decimal resultValue = engine.AdvancesRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 100, resultValue);
		}

		[Test ()]
		public void Should_return_100_for_Advances_Basis_when_Income_is_100_00()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 100.00m;

			decimal resultValue = engine.AdvancesRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 100, resultValue);
		}

		[Test ()]
		public void Should_return_200_for_Advances_Basis_when_Income_is_100_01()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 100.01m;

			decimal resultValue = engine.AdvancesRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 200, resultValue);
		}

	}
}

