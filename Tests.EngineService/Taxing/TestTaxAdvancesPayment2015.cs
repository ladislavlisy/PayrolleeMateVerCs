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
	public class TestTaxAdvancesPayment2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

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

		[Test ()]
		public void Should_return_0_for_Solidary_Basis_when_Income_is_106_443_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 106443m;

			decimal resultValue = engine.AdvancesSolidaryBasis(testPeriod, testIncome);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_0_for_Solidary_Basis_when_Income_is_106_444_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 106444m;

			decimal resultValue = engine.AdvancesSolidaryBasis(testPeriod, testIncome);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_1_for_Solidary_Basis_when_Income_is_106_445_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 106445m;

			decimal resultValue = engine.AdvancesSolidaryBasis(testPeriod, testIncome);

			Assert.AreEqual( 1m, resultValue);
		}

		[Test ()]
		public void Should_return_100_for_Solidary_Basis_when_Income_is_106_544_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 106544m;

			decimal resultValue = engine.AdvancesSolidaryBasis(testPeriod, testIncome);

			Assert.AreEqual( 100m, resultValue);
		}

		[Test ()]
		public void Should_return_900_for_Health_Increase_when_Income_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testAdvancesTaxing = true;

			decimal testIncome = 10000m;

			decimal resultValue = engine.AdvancesTaxableHealth(testPeriod, testAdvancesTaxing, testIncome);

			Assert.AreEqual( 900m, resultValue);
		}

		[Test ()]
		public void Should_return_540_for_Health_Increase_when_Income_is_6_003_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testAdvancesTaxing = true;

			decimal testIncome = 6003m;

			decimal resultValue = engine.AdvancesTaxableHealth(testPeriod, testAdvancesTaxing, testIncome);

			Assert.AreEqual( 540m, resultValue);
		}

		[Test ()]
		public void Should_return_2500_for_Social_Increase_when_Income_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testAdvancesTaxing = true;

			decimal testIncome = 10000m;

			decimal resultValue = engine.AdvancesTaxableSocial(testPeriod, testAdvancesTaxing, testIncome);

			Assert.AreEqual( 2500m, resultValue);
		}

		[Test ()]
		public void Should_return_1501_for_Social_Increase_when_Income_is_6_003_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testAdvancesTaxing = true;

			decimal testIncome = 6003m;

			decimal resultValue = engine.AdvancesTaxableSocial(testPeriod, testAdvancesTaxing, testIncome);

			Assert.AreEqual( 1501m, resultValue);
		}

		[Test ()]
		public void Should_return_1500_for_Regulary_Tax_when_Regulary_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 10000m;

			decimal resultValue = engine.AdvancesRegularyTax(testPeriod, testIncome);

			Assert.AreEqual( 1500m, resultValue);
		}

		[Test ()]
		public void Should_return_700_for_Solidary_Tax_when_Solidary_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 10000m;

			decimal resultValue = engine.AdvancesSolidaryTax(testPeriod, testIncome);

			Assert.AreEqual( 700m, resultValue);
		}

		[Test ()]
		public void Should_return_116_500_for_Advances_Basis_when_Income_is_116_444_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 116444m;

			decimal resultValue = engine.AdvancesRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 116500m, resultValue);
		}

		[Test ()]
		public void Should_return_10_000_for_Solidary_Basis_when_Income_is_116_444_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 116444m;

			decimal resultValue = engine.AdvancesSolidaryBasis(testPeriod, testIncome);

			Assert.AreEqual( 10000m, resultValue);
		}

		[Test ()]
		public void Should_return_18_175_for_Regulary_Tax_when_Income_is_116_444_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 116444m;

			decimal testRegulary = 116500m;

			decimal testSolidary = 10000m;

			decimal resultValue = engine.AdvancesResultTax(testPeriod, testIncome, testRegulary, testSolidary);

			Assert.AreEqual( 18175m, resultValue);
		}

	}
}

