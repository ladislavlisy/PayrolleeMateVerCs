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

		[Test ()]
		public void Should_return_TRUE_for_Participation_when_WorkTerm_is_Employment_With_Small_Work_and_Income_is_2_500_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			WorkSocialTerms termOfSocial = WorkSocialTerms.SOCIAL_TERM_SMALL_EMPL;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 2500m;
			decimal testTotalTaxIncome = 2500m;

			bool resultValue = engine.ParticipateSocialIncome(testPeriod, 
				termOfWork, termOfSocial, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Participation_when_WorkTerm_is_AgreementTasks_and_Income_is_10_000_CZK()
		{ 
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_CONTRACTER_T;

			WorkSocialTerms termOfSocial = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 10000m;
			decimal testTotalTaxIncome = 10000m;

			bool resultValue = engine.ParticipateSocialIncome(testPeriod, 
				termOfWork, termOfSocial, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

	}
}

