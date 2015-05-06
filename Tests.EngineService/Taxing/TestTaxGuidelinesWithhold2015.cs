using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;
using PayrolleeMate.EngineService.Constants;
using PayrolleeMate.Constants;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestTaxGuidelinesWithhold2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		const bool TAX_RESIDENT_CZECH = true;

		const bool TAX_RESIDENT_NO_CZ = false;

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Withhold_when_Non_Signed_Declaration_and_WorkTerm_is_AgreementTasks_and_Income_is_9_999_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_CONTRACTER_T;

			bool testStatementSigned = false;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 9999m;
			decimal testTotalTaxIncome = 9999m;

			bool resultValue = engine.WithholdTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_CZECH, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Withhold_when_Non_Signed_Declaration_and_WorkTerm_is_StatutoryTerm_and_Resident_Foreign()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_STATUTORY__Q;

			bool testStatementSigned = false;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 0m;
			decimal testTotalTaxIncome = 0m;

			bool resultValue = engine.WithholdTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_NO_CZ, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

	}
}

