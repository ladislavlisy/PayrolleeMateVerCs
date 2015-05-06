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
	public class TestSocialGuidelinesDeny2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_FALSE_for_Participation_when_WorkTerm_is_AgreementTasks_and_Income_is_9_999_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			WorkSocialTerms termOfSocial = WorkSocialTerms.SOCIAL_TERM_SMALL_EMPL;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 2499m;
			decimal testTotalTaxIncome = 2499m;

			bool resultValue = engine.ParticipateSocialIncome(testPeriod, 
				termOfWork, termOfSocial, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( false, resultValue);
		}

	}
}

