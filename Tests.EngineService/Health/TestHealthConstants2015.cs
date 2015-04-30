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
	public class TestHealthConstants2015
	{
		private static readonly MonthPeriod period2015 = new MonthPeriod (2015, 1);

		private IEnginesHistory<IHealthEngine> CreateEngine()
		{
			IEnginesHistory<IHealthEngine> engine = HealthEnginesHistory.CreateEngines ();

			engine.InitEngines ();

			return engine;
		}

		[Test ()]
		public void Should_return_Factor_Constants_for_Health_Engine_when_Year_2015()
		{          
			IEnginesHistory<IHealthEngine> engines = CreateEngine ();

			IHealthEngine engine = engines.ResolveEngine (period2015);

			Assert.AreEqual(  4.5m, engine.Guides().EmployeeFactor());
			Assert.AreEqual(  9.0m, engine.Guides().EmployerFactor());
			Assert.AreEqual( 13.5m, engine.Guides().CompoundFactor());
		}

		[Test ()]
		public void Should_return_Minimum_Constants_for_Health_Engine_when_Year_2015()
		{          
			IEnginesHistory<IHealthEngine> engines = CreateEngine ();

			IHealthEngine engine = engines.ResolveEngine (period2015);

			Assert.AreEqual( 9200, engine.Guides().MandatoryBasis());
		}

		[Test ()]
		public void Should_return_Maximum_Constants_for_Health_Engine_when_Year_2015()
		{          
			IEnginesHistory<IHealthEngine> engines = CreateEngine ();

			IHealthEngine engine = engines.ResolveEngine (period2015);

			Assert.AreEqual(    0, engine.Guides().MaximumAnnualBasis());
		}
	}
}

