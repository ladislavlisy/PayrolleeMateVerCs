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
	public class TestSocialPayEmployerGeneral2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_ZERO_for_Payment_when_Basis_is_0_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployerBasis = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerContribution(testPeriod, 
				testNegativeSuppress, testEmployerBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_650_for_Payment_when_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployerBasis = 10000m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerContribution(testPeriod, 
				testNegativeSuppress, testEmployerBasis);

			Assert.AreEqual( 2500m, resultValue);
		}

		[Test ()]
		public void Should_return_1501_for_Payment_when_Basis_is_6_003_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployerBasis = 6003m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployerContribution(testPeriod, 
				testNegativeSuppress, testEmployerBasis);

			Assert.AreEqual( 1501m, resultValue);
		}

	}
}

