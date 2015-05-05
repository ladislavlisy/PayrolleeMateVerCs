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
	public class TestTaxAllowances2015
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		[Test ()]
		public void Should_return_ZERO_for_Basic_Allowance_when_Not_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = false;

			bool testResidentIsCZECH = true;

			Int32 resultValue = engine.StatementPayerBasicAllowance(testPeriod, 
				testStatementSigned, testResidentIsCZECH);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_2070_for_Basic_Allowance_when_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = true;

			bool testResidentIsCZECH = true;

			Int32 resultValue = engine.StatementPayerBasicAllowance(testPeriod, 
				testStatementSigned, testResidentIsCZECH);

			Assert.AreEqual( 2070, resultValue);
		}

		[Test ()]
		public void Should_return_2070_for_Basic_Allowance_when_Signed_Declaration_and_Residet_FOREIGN()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = true;

			bool testResidentFOREIGN = false;

			Int32 resultValue = engine.StatementPayerBasicAllowance(testPeriod, 
				testStatementSigned, testResidentFOREIGN);

			Assert.AreEqual( 2070, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Disablement_Allowance_when_Not_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = false;

			byte testDisablementDegree = TaxingGuides.ALLOWANCE_DISAB_DEGREE_1ST;

			Int32 resultValue = engine.StatementPayerDisabAllowance(testPeriod, 
				testStatementSigned, testDisablementDegree);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_210_for_Disablement_Allowance_when_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = true;

			byte testDisablementDegree = TaxingGuides.ALLOWANCE_DISAB_DEGREE_1ST;

			Int32 resultValue = engine.StatementPayerDisabAllowance(testPeriod, 
				testStatementSigned, testDisablementDegree);

			Assert.AreEqual( 210, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Study_Allowance_when_Not_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = false;

			Int32 resultValue = engine.StatementPayerStudyAllowance(testPeriod, 
				testStatementSigned);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_335_for_Study_Allowance_when_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = true;

			Int32 resultValue = engine.StatementPayerStudyAllowance(testPeriod, 
				testStatementSigned);

			Assert.AreEqual( 335, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Children_Allowance_when_Not_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = false;

			bool testDisablement = false;

			byte testAllowanceRank = TaxingGuides.ALLOWANCE_CHILDREN_RANK_1ST;

			Int32 resultValue = engine.StatementChildrenAllowance(testPeriod, 
				testStatementSigned, testAllowanceRank, testDisablement);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_335_for_Children_Allowance_when_Signed_Declaration_and_Residet_CZECH()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			bool testStatementSigned = true;

			bool testDisablement = false;

			byte testAllowanceRank = TaxingGuides.ALLOWANCE_CHILDREN_RANK_1ST;

			Int32 resultValue = engine.StatementChildrenAllowance(testPeriod, 
				testStatementSigned, testAllowanceRank, testDisablement);

			Assert.AreEqual( 1117, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Tax_Rebate_when_Advances_Tax_is_0_CZK_and_Allowances_Value_is_2070_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 0;

			Int32 testAllowancePayer = 2070;

			Int32 testAllowanceZeros = 0;

			Int32 resultValue = engine.StatementPayerTaxRebate(testPeriod, 
				testAdvancesTax, testAllowancePayer, testAllowanceZeros, testAllowanceZeros);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_2069_for_Tax_Rebate_when_Advances_Tax_is_2069_and_Allowances_Value_is_2070_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 2069;

			Int32 testAllowancePayer = 2070;

			Int32 testAllowanceZeros = 0;

			Int32 resultValue = engine.StatementPayerTaxRebate(testPeriod, 
				testAdvancesTax, testAllowancePayer, testAllowanceZeros, testAllowanceZeros);

			Assert.AreEqual( 2069, resultValue);
		}

		[Test ()]
		public void Should_return_2070_for_Tax_Rebate_when_Advances_Tax_is_2070_and_Allowances_Value_is_2070_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 2070;

			Int32 testAllowancePayer = 2070;

			Int32 testAllowanceZeros = 0;

			Int32 resultValue = engine.StatementPayerTaxRebate(testPeriod, 
				testAdvancesTax, testAllowancePayer, testAllowanceZeros, testAllowanceZeros);

			Assert.AreEqual( 2070, resultValue);
		}

		[Test ()]
		public void Should_return_2070_for_Tax_Rebate_when_Advances_Tax_is_2071_and_Allowances_Value_is_2070_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 2071;

			Int32 testAllowancePayer = 2070;

			Int32 testAllowanceZeros = 0;

			Int32 resultValue = engine.StatementPayerTaxRebate(testPeriod, 
				testAdvancesTax, testAllowancePayer, testAllowanceZeros, testAllowanceZeros);

			Assert.AreEqual( 2070, resultValue);
		}

		[Test ()]
		public void Should_return_2614_for_Tax_Rebate_when_Advances_Tax_is_2614_and_Allowances_Value_is_2070_210_335_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 2614;

			Int32 testAllowancePayer = 2070;

			Int32 testAllowanceDisab = 210;

			Int32 testAllowanceStudy = 335;

			Int32 resultValue = engine.StatementPayerTaxRebate(testPeriod, 
				testAdvancesTax, testAllowancePayer, testAllowanceDisab, testAllowanceStudy);

			Assert.AreEqual( 2614, resultValue);
		}

		[Test ()]
		public void Should_return_2615_for_Tax_Rebate_when_Advances_Tax_is_2615_and_Allowances_Value_is_2070_210_335_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 2615;

			Int32 testAllowancePayer = 2070;

			Int32 testAllowanceDisab = 210;

			Int32 testAllowanceStudy = 335;

			Int32 resultValue = engine.StatementPayerTaxRebate(testPeriod, 
				testAdvancesTax, testAllowancePayer, testAllowanceDisab, testAllowanceStudy);

			Assert.AreEqual( 2615, resultValue);
		}

		[Test ()]
		public void Should_return_2615_for_Tax_Rebate_when_Advances_Tax_is_2616_and_Allowances_Value_is_2070_210_335_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 2616;

			Int32 testAllowancePayer = 2070;

			Int32 testAllowanceDisab = 210;

			Int32 testAllowanceStudy = 335;

			Int32 resultValue = engine.StatementPayerTaxRebate(testPeriod, 
				testAdvancesTax, testAllowancePayer, testAllowanceDisab, testAllowanceStudy);

			Assert.AreEqual( 2615, resultValue);
		}

		[Test ()]
		public void Should_return_1116_for_Tax_Rebate_when_Advances_Tax_is_3186_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3186;

			Int32 testRebatePayer = 2070;

			Int32 testAllowanceChild = 1117;

			Int32 resultValue = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Assert.AreEqual( 1116, resultValue);
		}

		[Test ()]
		public void Should_return_1117_for_Tax_Rebate_when_Advances_Tax_is_3187_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3187;

			Int32 testRebatePayer = 2070;

			Int32 testAllowanceChild = 1117;

			Int32 resultValue = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Assert.AreEqual( 1117, resultValue);
		}

		[Test ()]
		public void Should_return_1117_for_Tax_Rebate_when_Advances_Tax_is_3188_and_Allowances_Value_is_2070_210_335_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3188;

			Int32 testRebatePayer = 2070;

			Int32 testAllowanceChild = 1117;

			Int32 resultValue = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Assert.AreEqual( 1117, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Tax_Bonus_when_Advances_Tax_is_3186_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3186;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1116;

			Int32 testAllowanceChild = 1117;

			Int32 resultValue = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Tax_Bonus_when_Advances_Tax_is_3187_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3187;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1117;

			Int32 testAllowanceChild = 1117;

			Int32 resultValue = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Tax_Bonus_when_Advances_Tax_is_3188_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3188;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1117;

			Int32 testAllowanceChild = 1117;

			Int32 resultValue = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 0, resultValue);
		}

		[Test ()]
		public void Should_return_ZERO_for_Tax_Bonus_when_Advances_Tax_is_3138_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3138;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1068;

			Int32 testAllowanceChild = 1117;

			Int32 resultRebate = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Int32 resultBonus = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 1068, resultRebate);

			Assert.AreEqual(    0, resultBonus);
		}

		[Test ()]
		public void Should_return_50_for_Tax_Bonus_when_Advances_Tax_is_3137_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3137;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1067;

			Int32 testAllowanceChild = 1117;

			Int32 resultRebate = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Int32 resultBonus = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 1067, resultRebate);

			Assert.AreEqual( 50, resultBonus);
		}

		[Test ()]
		public void Should_return_51_for_Tax_Bonus_when_Advances_Tax_is_3136_and_Rebate_is_2070_and_Allowances_Value_is_1117_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3136;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1066;

			Int32 testAllowanceChild = 1117;

			Int32 resultRebate = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Int32 resultBonus = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 1066, resultRebate);

			Assert.AreEqual( 51, resultBonus);
		}

		[Test ()]
		public void Should_return_5024_for_Tax_Bonus_when_Advances_Tax_is_3138_and_Rebate_is_2070_and_Allowances_Value_is_6092_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3138;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1068;

			Int32 testAllowanceChild = 6092;

			Int32 resultRebate = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Int32 resultBonus = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 1068, resultRebate);

			Assert.AreEqual( 5024, resultBonus);
		}

		[Test ()]
		public void Should_return_5025_for_Tax_Bonus_when_Advances_Tax_is_3137_and_Rebate_is_2070_and_Allowances_Value_is_6092_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3137;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1067;

			Int32 testAllowanceChild = 6092;

			Int32 resultRebate = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Int32 resultBonus = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 1067, resultRebate);

			Assert.AreEqual( 5025, resultBonus);
		}

		[Test ()]
		public void Should_return_5025_for_Tax_Bonus_when_Advances_Tax_is_3136_and_Rebate_is_2070_and_Allowances_Value_is_6092_CZK()
		{ 
			IEnginesHistory<ITaxingEngine> engines = TaxingEnginesHistory.CreateEngines ();

			ITaxingEngine engine = engines.ResolveEngine (testPeriod);

			Int32 testAdvancesTax = 3136;

			Int32 testRebatePayer = 2070;

			Int32 testRebateChild = 1066;

			Int32 testAllowanceChild = 6092;

			Int32 resultRebate = engine.StatementChildrenRebate(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild);

			Int32 resultBonus = engine.StatementChildrenBonus(testPeriod, 
				testAdvancesTax, testRebatePayer, testAllowanceChild, testRebateChild);

			Assert.AreEqual( 1066, resultRebate);

			Assert.AreEqual( 5025, resultBonus);
		}
	}
}

