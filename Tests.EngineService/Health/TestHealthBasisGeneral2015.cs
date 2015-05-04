using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;
using PayrolleeMate.EngineService.Constants;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestHealthBasisGeneral2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_1001_for_Basis_when_Income_is_1000_01()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testNegativeSuppress = true;

			decimal testIncome = 1000.01m;

			decimal resultValue = engine.BasisGeneralAdapted(testPeriod, 
				testNegativeSuppress, testIncome);

			Assert.AreEqual( 1000.01m, resultValue);
		}

		[Test ()]
		public void Should_return_Negative_1001_for_Basis_when_Income_is_Negative_1000_01()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testNegativeSuppress = false;

			decimal testIncome = -1000.01m;

			decimal resultValue = engine.BasisGeneralAdapted(testPeriod, 
				testNegativeSuppress, testIncome);

			Assert.AreEqual(-1000.01m, resultValue);
		}

		[Test ()]
		public void Should_return_Zero_for_Basis_when_Income_is_Negative_1000_01_and_Negative_Payments_is_False()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testNegativeSuppress = true;

			decimal testIncome = -1000.01m;

			decimal resultValue = engine.BasisGeneralAdapted(testPeriod, 
				testNegativeSuppress, testIncome);

			Assert.AreEqual(  0, resultValue);
		}
	}
}

