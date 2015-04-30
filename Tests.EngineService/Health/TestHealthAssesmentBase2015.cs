using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;
using PayrolleeMate.EngineService.Constants;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestHealthAssesmentBase2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_Zero_for_Assesment_Base_when_Income_is_Negative_0_01()
		{          
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			bool testNegativeValues = false;

			bool testMandatoryParticipation = false;

			decimal testIncome = -0.01m;

			decimal testAccumulatedIncome = 0m;

			decimal resultValue = engine.CalculatedBasis(testPeriod, 
				testNegativeValues, testMandatoryParticipation, 
				testIncome, testAccumulatedIncome);

			Assert.AreEqual(  0, resultValue);
		}
	}
}

