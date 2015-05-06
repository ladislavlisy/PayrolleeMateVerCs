using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;
using PayrolleeMate.EngineService.Constants;
using PayrolleeMate.Constants;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestSocialGuidelinesMeet2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_TRUE_for_Participation_when_WorkTerm_is_Employment()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			WorkSocialTerms termOfSocial = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 0m;
			decimal testTotalTaxIncome = 0m;

			bool resultValue = engine.ParticipateSocialIncome(testPeriod, 
				termOfWork, termOfSocial, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}
	}
}

