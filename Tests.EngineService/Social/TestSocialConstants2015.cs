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
		private static readonly MonthPeriod period2015 = new MonthPeriod (2015, 1);

		private IEnginesHistory<ISocialEngine> CreateEngine()
		{
			IEnginesHistory<ISocialEngine> engine = SocialEnginesHistory.CreateEngines ();

			engine.InitEngines ();

			return engine;
		}

		[Test ()]
		public void Should_return_Factor_Constants_for_Social_Engine_when_Year_2015()
		{          
			IEnginesHistory<ISocialEngine> engines = CreateEngine ();

			ISocialEngine engine = engines.ResolveEngine (period2015);

			Assert.AreEqual(  6.5m, engine.Guides().EmployeeFactor());
			Assert.AreEqual(  5.0m, engine.Guides().EmployeePensionsFactor());
			Assert.AreEqual(  3.0m, engine.Guides().PensionsReduceFactor());
			Assert.AreEqual( 25.0m, engine.Guides().EmployerFactor());
			Assert.AreEqual( 25.0m, engine.Guides().EmployerElevatedFactor());
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Social_Engine_when_Year_2015()
		{          
			IEnginesHistory<ISocialEngine> engines = CreateEngine ();

			ISocialEngine engine = engines.ResolveEngine (period2015);

			Assert.AreEqual(     0, engine.Guides().MandatoryBasis());
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Social_Engine_when_Year_2015()
		{          
			IEnginesHistory<ISocialEngine> engines = CreateEngine ();

			ISocialEngine engine = engines.ResolveEngine (period2015);

			Assert.AreEqual(1277328m, engine.Guides().MaximumAnnualBasis());
		}
	}
}

