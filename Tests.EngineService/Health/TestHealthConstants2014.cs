using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestHealthConstants2014
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2014, 1);

		[Test ()]
		public void Should_return_Factor_Constants_for_Health_Engine_when_Year_2014()
		{          
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(  4.5m, engine.PeriodEmployeeFactor(testPeriod));
			Assert.AreEqual(  9.0m, engine.PeriodEmployerFactor(testPeriod));
			Assert.AreEqual( 13.5m, engine.PeriodCompoundFactor(testPeriod));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Health_Engine_when_Year_2014()
		{          
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual( 8500, engine.PeriodMandatoryBasis(testPeriod));
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Health_Engine_when_Year_2014()
		{          
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(    0, engine.PeriodMaximumAnnualBasis(testPeriod));
		}
	}
}

