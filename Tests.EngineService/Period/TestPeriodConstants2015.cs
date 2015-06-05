using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Period;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestPeriodConstants2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_Daily_Seconds_Constants_for_Period_Engine_when_Year_2015()
		{          
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			IPeriodEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual( 28800, engine.PeriodDailyWorkingSeconds(testPeriod));
		}

		[Test ()]
		public void Should_return_Weekly_Seconds_Constants_for_Period_Engine_when_Year_2015()
		{          
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			IPeriodEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual( 144000, engine.PeriodWeeklyWorkingSeconds(testPeriod));
		}
	}
}

