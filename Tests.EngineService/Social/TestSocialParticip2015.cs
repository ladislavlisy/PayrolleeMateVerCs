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
	public class TestSocialParticip2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_1000_for_Selector_when_Income_is_1000_and_Participation_is_True()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			bool testInsParticip = true;

			decimal testIncome = 1000m;

			decimal resultValue = engine.ParticipSocialSelector(testPeriod, 
				testInsParticip, testIncome);

			Assert.AreEqual( 1000m, resultValue);
		}

		[Test ()]
		public void Should_return_Negative_1000_for_Selector_when_Income_is_Negative_1000_and_Participation_is_is_True()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			bool testInsParticip = true;

			decimal testIncome = -1000m;

			decimal resultValue = engine.ParticipSocialSelector(testPeriod, 
				testInsParticip, testIncome);

			Assert.AreEqual(-1000m, resultValue);
		}

		[Test ()]
		public void Should_return_Zero_for_Selector_when_Income_is_1000_and_Participation_is_False()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			bool testInsParticip = false;

			decimal testIncome = 1000m;

			decimal resultValue = engine.ParticipSocialSelector(testPeriod, 
				testInsParticip, testIncome);

			Assert.AreEqual(  0, resultValue);
		}
	}
}

