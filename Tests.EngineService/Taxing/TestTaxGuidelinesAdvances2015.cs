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
	public class TestTaxGuidelinesAdvances2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		const bool TAX_RESIDENT_CZECH = true;

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Advances_when_Signed_Declaration_and_WorkTerm_is_Employment()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			bool testStatementSigned = true;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 0m;
			decimal testTotalTaxIncome = 0m;

			bool resultValue = engine.AdvancesTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_CZECH, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Advances_when_Signed_Declaration_and_WorkTerm_is_AgreementTasks()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_CONTRACTER_T;

			bool testStatementSigned = true;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 0m;
			decimal testTotalTaxIncome = 0m;

			bool resultValue = engine.AdvancesTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_CZECH, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Advances_when_Non_Signed_Declaration_and_WorkTerm_is_Employment()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			bool testStatementSigned = true;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 0m;
			decimal testTotalTaxIncome = 0m;

			bool resultValue = engine.AdvancesTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_CZECH, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Advances_when_Non_Signed_Declaration_and_WorkTerm_is_AgreementTasks_and_Income_is_10_000_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_CONTRACTER_T;

			bool testStatementSigned = false;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 10000m;
			decimal testTotalTaxIncome = 10000m;

			bool resultValue = engine.AdvancesTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_CZECH, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Advances_when_Non_Signed_Declaration_and_WorkTerm_is_AgreementTasks_and_Income_is_10_001_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_CONTRACTER_T;

			bool testStatementSigned = false;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 10001m;
			decimal testTotalTaxIncome = 10001m;

			bool resultValue = engine.AdvancesTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_CZECH, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

		[Test ()]
		public void Should_return_TRUE_for_Taxing_Advances_when_Non_Signed_Declaration_and_WorkTerm_is_StatutoryTerm()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			WorkRelationTerms termOfIncome = WorkRelationTerms.WORKTERM_STATUTORY__Q;

			bool testStatementSigned = false;

			decimal testContractIncome = 0m;
			decimal testWorkTermIncome = 0m;
			decimal testTotalTaxIncome = 0m;

			bool resultValue = engine.AdvancesTaxableIncome(testPeriod, 
				testStatementSigned, TAX_RESIDENT_CZECH, termOfIncome, 
				testContractIncome, testWorkTermIncome, testTotalTaxIncome);

			Assert.AreEqual( true, resultValue);
		}

	}
}

