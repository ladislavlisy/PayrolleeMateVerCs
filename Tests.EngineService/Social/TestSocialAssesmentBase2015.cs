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
	public class TestSocialAssesmentBase2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_Zero_for_Assesment_Base_when_Income_is_Negative_0_01()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			bool testNegativeValues = false;

			bool testPensionParticipation = false;

			decimal testIncome = -0.01m;

			decimal testAccumulatedIncome = 0m;

			decimal resultValue = engine.RegularCalculatedBasis(testPeriod, 
				testNegativeValues, testPensionParticipation, 
				testIncome, testAccumulatedIncome);

			Assert.AreEqual(  0, resultValue);
		}
	}
}

