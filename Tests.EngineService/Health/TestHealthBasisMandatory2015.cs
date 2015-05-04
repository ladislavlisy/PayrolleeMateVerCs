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
	public class TestHealthBasisMandatory2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_ZERO_for_Mandatory_Basis_when_General_Basis_is_9200()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testMandatoryDuty = true;

			decimal testIncome = 9200m;

			decimal resultValue = engine.BasisMandatoryBalance(testPeriod, 
				testMandatoryDuty, testIncome);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_1_CZK_for_Mandatory_Basis_when_General_Basis_is_9199()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testMandatoryDuty = true;

			decimal testIncome = 9199m;

			decimal resultValue = engine.BasisMandatoryBalance(testPeriod, 
				testMandatoryDuty, testIncome);

			Assert.AreEqual( 1m, resultValue);
		}

		[Test ()]
		public void Should_return_8199_for_Mandatory_Basis_when_General_Basis_is_1001()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testMandatoryDuty = true;

			decimal testIncome = 1001m;

			decimal resultValue = engine.BasisMandatoryBalance(testPeriod, 
				testMandatoryDuty, testIncome);

			Assert.AreEqual( 8199m, resultValue);
		}

		[Test ()]
		public void Should_return_9200_for_Mandatory_Basis_when_General_Basis_is_0()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testMandatoryDuty = true;

			decimal testIncome = 0m;

			decimal resultValue = engine.BasisMandatoryBalance(testPeriod, 
				testMandatoryDuty, testIncome);

			Assert.AreEqual( 9200m, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Mandatory_Basis_when_General_Basis_is_1001_and_Mandatory_Duty_is_False()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testMandatoryDuty = false;

			decimal testIncome = 1001m;

			decimal resultValue = engine.BasisMandatoryBalance(testPeriod, 
				testMandatoryDuty, testIncome);

			Assert.AreEqual( 0, resultValue);
		}
	}
}

