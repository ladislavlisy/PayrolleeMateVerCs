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
	public class TestGarantPayEmployeeGeneral2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		public const bool GARANT_SCHEME_YES = true;

		public const bool GARANT_SCHEME_NON = false;

		[Test ()]
		public void Should_return_ZERO_for_Regular_Basis_when_Basis_is_10_000_CZK_and_Garant_Scheme_is_ON()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 10000m;

			decimal resultValue = engine.RegularCalculatedBasis(testPeriod, 
				GARANT_SCHEME_YES, testEmployeeBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_10_000_for_Regular_Basis_when_Basis_is_10_000_CZK_and_Garant_Scheme_is_OFF()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 10000m;

			decimal resultValue = engine.RegularCalculatedBasis(testPeriod, 
				GARANT_SCHEME_NON, testEmployeeBasis);

			Assert.AreEqual( 10000m, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Garant_Basis_when_Basis_is_10_000_CZK_and_Garant_Scheme_is_OFF()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 10000m;

			decimal resultValue = engine.PensionCalculatedBasis(testPeriod, 
				GARANT_SCHEME_NON, testEmployeeBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_10_000_for_Garant_Basis_when_Basis_is_10_000_CZK_and_Garant_Scheme_is_ON()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 10000m;

			decimal resultValue = engine.PensionCalculatedBasis(testPeriod, 
				GARANT_SCHEME_YES, testEmployeeBasis);

			Assert.AreEqual( 10000m, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Payment_when_Basis_is_0_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 0m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeGarantContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 0m, resultValue);
		}

		[Test ()]
		public void Should_return_500_for_Payment_when_Basis_is_10_000_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 10000m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeGarantContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 500m, resultValue);
		}

		[Test ()]
		public void Should_return_301_for_Payment_when_Basis_is_6_003_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			decimal testEmployeeBasis = 6003m;

			bool testNegativeSuppress = true;

			decimal resultValue = engine.EmployeeGarantContribution(testPeriod, 
				testNegativeSuppress, testEmployeeBasis);

			Assert.AreEqual( 301m, resultValue);
		}

	}
}

