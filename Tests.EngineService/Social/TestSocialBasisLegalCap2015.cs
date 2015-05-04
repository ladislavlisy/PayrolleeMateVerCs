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
	public class TestSocialBasisLegalCap2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_ZERO_for_Cap_when_Basis_is_10_000_and_Accumulated_Basis_is_ZERO()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testAktualMonthBasis = 10000m;

			decimal testAccumulatedBasis = 0m;

			decimal resultValue = engine.BasisLegalCapBalance(testPeriod, 
				testAccumulatedBasis, testAktualMonthBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Cap_when_Basis_is_0_CZK_and_Accumulated_Basis_is_1_277_428()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testAktualMonthBasis = 0m;

			decimal testAccumulatedBasis = 1277428m;

			decimal resultValue = engine.BasisLegalCapBalance(testPeriod, 
				testAccumulatedBasis, testAktualMonthBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_10_000_for_Cap_when_Basis_is_10_000_and_Accumulated_Basis_is_1_277_328()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testAktualMonthBasis = 10000m;

			decimal testAccumulatedBasis = 1277328m;

			decimal resultValue = engine.BasisLegalCapBalance(testPeriod, 
				testAccumulatedBasis, testAktualMonthBasis);

			Assert.AreEqual( 10000m, resultValue);
		}

		[Test ()]
		public void Should_return_10_000_for_Cap_when_Basis_is_10_000_and_Accumulated_Basis_is_1_277_428()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testAktualMonthBasis = 10000m;

			decimal testAccumulatedBasis = 1277428m;

			decimal resultValue = engine.BasisLegalCapBalance(testPeriod, 
				testAccumulatedBasis, testAktualMonthBasis);

			Assert.AreEqual( 10000m, resultValue);
		}

		[Test ()]
		public void Should_return_10_000_for_Cap_when_Basis_is_10_100_and_Accumulated_Basis_is_1_277_228()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testAktualMonthBasis = 10100m;

			decimal testAccumulatedBasis = 1277228m;

			decimal resultValue = engine.BasisLegalCapBalance(testPeriod, 
				testAccumulatedBasis, testAktualMonthBasis);

			Assert.AreEqual( 10000m, resultValue);
		}
	}
}

