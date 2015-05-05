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
	public class TestHealthPayEmployerGeneral2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_ZERO_for_Payment_when_Basis_is_0_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 0m;

			decimal testMandatoryEmpee = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerGeneralContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis, testMandatoryEmpee);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_900_for_Payment_when_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 10000m;

			decimal testMandatoryEmpee = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerGeneralContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis, testMandatoryEmpee);

			Assert.AreEqual( 900m, resultValue);
		}

		[Test ()]
		public void Should_return_540_for_Payment_when_Basis_is_6_003_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 6003m;

			decimal testMandatoryEmpee = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerGeneralContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis, testMandatoryEmpee);

			Assert.AreEqual( 540m, resultValue);
		}

		[Test ()]
		public void Should_return_810_for_Employer_Payment_when_Basis_is_6_003_CZK_and_Mandatory_Basis_is_2_001_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 6003m;

			decimal testMandatoryEmpee = 0m;

			decimal testMandatoryBasis = 2001m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis, testMandatoryEmpee, testMandatoryBasis);

			Assert.AreEqual( 810m, resultValue);
		}

		[Test ()]
		public void Should_return_270_for_Mandatory_Payment_when_Basis_is_6_003_CZK_and_Mandatory_Basis_is_2_001_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			decimal testGeneralBasis = 6003m;

			decimal testMandatoryEmpee = 0m;

			decimal testMandatoryBasis = 2001m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerMandatoryContribution(testPeriod, 
				testNegativeSuppress, testGeneralBasis, testMandatoryEmpee, testMandatoryBasis);

			Assert.AreEqual( 270m, resultValue);
		}

	}
}

