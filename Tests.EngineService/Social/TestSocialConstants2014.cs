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
	public class TestSocialConstants2014
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2014, 1);

		private IEnginesHistory<ISocialEngine> CreateEngine()
		{
			IEnginesHistory<ISocialEngine> engine = SocialEnginesHistory.CreateEngines ();

			engine.InitEngines ();

			return engine;
		}

		[Test ()]
		public void Should_return_Factor_Constants_for_Social_Engine_when_Year_2014()
		{          
			IEnginesHistory<ISocialEngine> engines = CreateEngine ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(  6.5m, engine.PeriodEmployeeFactor(testPeriod));
			Assert.AreEqual(  5.0m, engine.PeriodEmployeePensionsFactor(testPeriod));
			Assert.AreEqual(  3.0m, engine.PeriodPensionsReduceFactor(testPeriod));
			Assert.AreEqual( 25.0m, engine.PeriodEmployerFactor(testPeriod));
			Assert.AreEqual( 26.0m, engine.PeriodEmployerElevatedFactor(testPeriod));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Social_Engine_when_Year_2014()
		{          
			IEnginesHistory<ISocialEngine> engines = CreateEngine ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(     0, engine.PeriodMandatoryBasis(testPeriod));
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Social_Engine_when_Year_2014()
		{          
			IEnginesHistory<ISocialEngine> engines = CreateEngine ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(1245216m, engine.PeriodMaximumAnnualBasis(testPeriod));
		}
	}
}

