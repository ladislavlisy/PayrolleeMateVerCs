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
	public class TestHealthGuidelinesDeny2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_FALSE_for_Participation_when_WorkTerm_is_AgreementWorks_and_Income_is_2_499_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			WorkHealthTerms termOfHealth = WorkHealthTerms.HEALTH_TERM_AGREE_WORK;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 2499m;
			decimal testTotalTaxIncome = 2499m;

			bool resultValue = engine.ParticipateHealthIncome(testPeriod, 
				termOfWork, termOfHealth, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( false, resultValue);
		}

		[Test ()]
		public void Should_return_FALSE_for_Participation_when_WorkTerm_is_AgreementTasks_and_Income_is_9_999_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_CONTRACTER_T;

			WorkHealthTerms termOfHealth = WorkHealthTerms.HEALTH_TERM_AGREE_TASK;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 9999m;
			decimal testTotalTaxIncome = 9999m;

			bool resultValue = engine.ParticipateHealthIncome(testPeriod, 
				termOfWork, termOfHealth, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( false, resultValue);
		}
	}
}

