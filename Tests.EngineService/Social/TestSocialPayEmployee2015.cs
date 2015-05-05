using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;
using PayrolleeMate.EngineService.Constants;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestSocialPayEmployeeGeneral2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_ZERO_for_Payment_when_Basis_is_0_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeRegularContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_650_for_Payment_when_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 10000m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeRegularContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 650m, resultValue);
		}

		[Test ()]
		public void Should_return_391_for_Payment_when_Basis_is_6_003_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 6003m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeRegularContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 391m, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Payment_when_Basis_is_0_CZK_and_Garant_Scheme_is_ON()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeePensionContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_350_for_Payment_when_Basis_is_10_000_CZK_and_Garant_Scheme_is_ON()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 10000m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeePensionContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 350m, resultValue);
		}

		[Test ()]
		public void Should_return_211_for_Payment_when_Basis_is_6_003_CZK_and_Garant_Scheme_is_ON()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 6003m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeePensionContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 211m, resultValue);
		}

	}
}

