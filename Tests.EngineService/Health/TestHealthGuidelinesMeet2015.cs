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
	public class TestHealthGuidelinesMeet2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_TRUE_for_Participation_when_WorkTerm_is_Employment()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			WorkHealthTerms termOfHealth = WorkHealthTerms.HEALTH_TERM_EMPLOYMENT;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 0m;
			decimal testTotalTaxIncome = 0m;

			bool resultValue = engine.ParticipateHealthIncome(testPeriod, 
				termOfWork, termOfHealth, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Participation_when_WorkTerm_is_AgreementWorks_and_Income_is_2_500_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			WorkHealthTerms termOfHealth = WorkHealthTerms.HEALTH_TERM_AGREE_WORK;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 2500m;
			decimal testTotalTaxIncome = 2500m;

			bool resultValue = engine.ParticipateHealthIncome(testPeriod, 
				termOfWork, termOfHealth, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Participation_when_WorkTerm_is_AgreementTasks_and_Income_is_10_000_CZK()
		{ 
			IEnginesHistory<IHealthEngine> engines = HealthEnginesHistory.CreateEngines ();

			IHealthEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfWork = WorkRelationTerms.WORKTERM_CONTRACTER_T;

			WorkHealthTerms termOfHealth = WorkHealthTerms.HEALTH_TERM_AGREE_TASK;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 10000m;
			decimal testTotalTaxIncome = 10000m;

			bool resultValue = engine.ParticipateHealthIncome(testPeriod, 
				termOfWork, termOfHealth, testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}
	}
}

