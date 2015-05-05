using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestSocialConstants2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		public const bool PENSION_SCHEME_YES = true;

		public const bool PENSION_SCHEME_NON = false;

		[Test ()]
		public void Should_return_Factor_Constants_for_Social_Engine_when_Year_2015()
		{          
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(  6.5m, engine.PeriodEmployeeFactor(testPeriod, PENSION_SCHEME_NON));
			Assert.AreEqual(  3.5m, engine.PeriodEmployeeFactor(testPeriod, PENSION_SCHEME_YES));
			Assert.AreEqual(  5.0m, engine.PeriodEmployeeGarantFactor(testPeriod));
			Assert.AreEqual(  3.0m, engine.PeriodPensionsReduceFactor(testPeriod));
			Assert.AreEqual( 25.0m, engine.PeriodEmployerFactor(testPeriod));
			Assert.AreEqual( 25.0m, engine.PeriodEmployerElevatedFactor(testPeriod));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Social_Engine_when_Year_2015()
		{          
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(     0, engine.PeriodMandatoryBasis(testPeriod));
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Social_Engine_when_Year_2015()
		{          
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(1277328m, engine.PeriodMaximumAnnualBasis(testPeriod));
		}
	}
}

