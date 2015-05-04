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
	public class TestTaxHealthSelectors2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_1000_for_Health_Selector_when_Income_is_1000_and_Select_Value_is_True()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testTaxSubject = true;

			bool testTaxArticle = true;

			bool testInsSubject = true;

			bool testInsArticle = true;

			bool testInsParticip = true;

			decimal testIncome = 1000m;

			decimal resultValue = engine.SubjectHealthSelector(testPeriod, 
				testTaxSubject, testInsSubject, testTaxArticle, testInsArticle, testInsParticip, testIncome);

			Assert.AreEqual( 1000m, resultValue);
		}

		[Test ()]
		public void Should_return_Negative_1000_for_Health_Selector_when_Income_is_Negative_1000_and_Select_Value_is_True()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testTaxSubject = true;

			bool testTaxArticle = true;

			bool testInsSubject = true;

			bool testInsArticle = true;

			bool testInsParticip = true;

			decimal testIncome = -1000m;

			decimal resultValue = engine.SubjectHealthSelector(testPeriod, 
				testTaxSubject, testInsSubject, testTaxArticle, testInsArticle, testInsParticip, testIncome);

			Assert.AreEqual(-1000m, resultValue);
		}

		[Test ()]
		public void Should_return_Zero_for_Health_Selector_when_Income_is_1000_and_Select_Subject_is_False()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testTaxSubject = true;

			bool testTaxArticle = true;

			bool testInsSubject = false;

			bool testInsArticle = true;

			bool testInsParticip = true;

			decimal testIncome = 1000m;

			decimal resultValue = engine.SubjectHealthSelector(testPeriod, 
				testTaxSubject, testInsSubject, testTaxArticle, testInsArticle, testInsParticip, testIncome);

			Assert.AreEqual(  0, resultValue);
		}

		[Test ()]
		public void Should_return_Zero_for_Health_Selector_when_Income_is_1000_and_Select_Article_is_False()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testTaxSubject = true;

			bool testTaxArticle = true;

			bool testInsSubject = true;

			bool testInsArticle = false;

			bool testInsParticip = true;

			decimal testIncome = 1000m;

			decimal resultValue = engine.SubjectHealthSelector(testPeriod, 
				testTaxSubject, testInsSubject, testTaxArticle, testInsArticle, testInsParticip, testIncome);

			Assert.AreEqual(  0, resultValue);
		}

		[Test ()]
		public void Should_return_Zero_for_Health_Selector_when_Income_is_1000_and_Select_Particip_is_False()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testTaxSubject = true;

			bool testTaxArticle = true;

			bool testInsSubject = true;

			bool testInsArticle = true;

			bool testInsParticip = false;

			decimal testIncome = 1000m;

			decimal resultValue = engine.SubjectHealthSelector(testPeriod, 
				testTaxSubject, testInsSubject, testTaxArticle, testInsArticle, testInsParticip, testIncome);

			Assert.AreEqual(  0, resultValue);
		}
	}
}

