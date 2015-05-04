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
	public class TestHealthPayEmployeeGeneral2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_ZERO_for_Payment_when_Basis_is_0_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeGeneralContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_450_for_Payment_when_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 10000m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeGeneralContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis);

			Assert.AreEqual( 450m, resultValue);
		}

		[Test ()]
		public void Should_return_271_for_Payment_when_Basis_is_6_003_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 6003m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeGeneralContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis);

			Assert.AreEqual( 271m, resultValue);
		}

		[Test ()]
		public void Should_return_270_for_Mandatory_Payment_when_Basis_is_6_003_CZK_and_Mandatory_Basis_is_2_003_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 6003m;

			decimal testMandatoryBasis = 2001m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeMandatoryContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis, testMandatoryBasis);

			Assert.AreEqual( 270m, resultValue);
		}

	}
}

