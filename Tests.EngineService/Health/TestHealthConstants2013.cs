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
	public class TestHealthConstants2013
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2013, 1);

		[Test ()]
		public void Should_return_Factor_Constants_for_Health_Engine_when_Year_2013()
		{          
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(  4.5m, engine.PeriodEmployeeFactor(testPeriod));
			Assert.AreEqual(  9.0m, engine.PeriodEmployerFactor(testPeriod));
			Assert.AreEqual( 13.5m, engine.PeriodCompoundFactor(testPeriod));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Health_Engine_when_Year_2013()
		{          
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual( 8000, engine.PeriodMandatoryBasis(testPeriod));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Health_Engine_when_Month_07_2013()
		{          
			MonthPeriod testPeriod07 = new MonthPeriod (2013, 7);

			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod07);

			Assert.AreEqual( 8000, engine.PeriodMandatoryBasis(testPeriod07));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Health_Engine_when_Month_08_2013()
		{          
			MonthPeriod testPeriod08 = new MonthPeriod (2013, 8);

			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod08);

			Assert.AreEqual( 8500, engine.PeriodMandatoryBasis(testPeriod08));
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Health_Engine_when_Month_12_2013()
		{          
			MonthPeriod testPeriod12 = new MonthPeriod (2013, 12);

			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod12);

			Assert.AreEqual( 8500, engine.PeriodMandatoryBasis(testPeriod12));
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Health_Engine_when_Year_2013()
		{          
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			Assert.AreEqual(    0, engine.PeriodMaximumAnnualBasis(testPeriod));
		}
	}
}

