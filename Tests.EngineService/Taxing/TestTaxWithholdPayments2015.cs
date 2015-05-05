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
	public class TestTaxWithholdPayment2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_Zero_for_Withhold_Basis_when_Income_is_Negaive_1000()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = -1000m;

			decimal resultValue = engine.WithholdRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual(  0, resultValue);
		}

		[Test ()]
		public void Should_return_100_for_Withhold_Basis_when_Income_is_99_01()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 99.01m;

			decimal resultValue = engine.WithholdRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 100, resultValue);
		}

		[Test ()]
		public void Should_return_100_for_Withhold_Basis_when_Income_is_99_99()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 99.99m;

			decimal resultValue = engine.WithholdRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 100, resultValue);
		}

		[Test ()]
		public void Should_return_100_for_Withhold_Basis_when_Income_is_100_00()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 100.00m;

			decimal resultValue = engine.WithholdRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 100, resultValue);
		}

		[Test ()]
		public void Should_return_200_for_Withhold_Basis_when_Income_is_100_01()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 100.01m;

			decimal resultValue = engine.WithholdRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 101, resultValue);
		}

		[Test ()]
		public void Should_return_900_for_Health_Increase_when_Income_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testWithholdTaxing = true;

			decimal testIncome = 10000m;

			decimal resultValue = engine.WithholdTaxableHealth(testPeriod, testWithholdTaxing, testIncome);

			Assert.AreEqual( 900m, resultValue);
		}

		[Test ()]
		public void Should_return_540_for_Health_Increase_when_Income_is_6_003_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testWithholdTaxing = true;

			decimal testIncome = 6003m;

			decimal resultValue = engine.WithholdTaxableHealth(testPeriod, testWithholdTaxing, testIncome);

			Assert.AreEqual( 540m, resultValue);
		}

		[Test ()]
		public void Should_return_2500_for_Social_Increase_when_Income_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testWithholdTaxing = true;

			decimal testIncome = 10000m;

			decimal resultValue = engine.WithholdTaxableSocial(testPeriod, testWithholdTaxing, testIncome);

			Assert.AreEqual( 2500m, resultValue);
		}

		[Test ()]
		public void Should_return_1501_for_Social_Increase_when_Income_is_6_003_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testWithholdTaxing = true;

			decimal testIncome = 6003m;

			decimal resultValue = engine.WithholdTaxableSocial(testPeriod, testWithholdTaxing, testIncome);

			Assert.AreEqual( 1501m, resultValue);
		}

		[Test ()]
		public void Should_return_1500_for_Regulary_Tax_when_Regulary_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 10000m;

			decimal resultValue = engine.WithholdResultTax(testPeriod, testIncome);

			Assert.AreEqual( 1500m, resultValue);
		}

		[Test ()]
		public void Should_return_116_444_for_Withhold_Basis_when_Income_is_116_444_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 116444m;

			decimal resultValue = engine.WithholdRoundedBasis(testPeriod, testIncome);

			Assert.AreEqual( 116444m, resultValue);
		}

		[Test ()]
		public void Should_return_17_467_for_Regulary_Tax_when_Income_is_116_444_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = 116444m;

			decimal resultValue = engine.WithholdResultTax(testPeriod, testIncome);

			Assert.AreEqual( 17467m, resultValue);
		}

	}
}

