using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService;
using PayrolleeMate.EngineService.Constants;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestTaxingAdvances2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_Zero_for_Advances_Basis_when_Income_is_Negative_0_01()
		{          
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			decimal testIncome = -0.01m;

			bool testStatementSign = true;

			bool testResidentCzech = true;

			WorkRelationTerms testWorkTerm = WorkRelationTerms.WORKTERM_EMPLOYMENT_1; 

			decimal testResult = engine.AdvancesTaxableIncome (testPeriod, 
				testStatementSign, testResidentCzech, testWorkTerm, 
				testIncome, testIncome);

			Assert.AreEqual (  0m, testResult);
		}
	}
}

