using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Taxing
{
	public class TaxingEnginePrototype : ITaxingEngine, ITaxingGuides
	{
		public TaxingEnginePrototype (TaxingGuides currentGuides)
		{
			__guides = currentGuides.Clone() as TaxingGuides;
		}

		#region ITaxingGuides implementation

		// AdvancesTax
		public Int32 AdvancesResult(MonthPeriod period, decimal taxableIncome, decimal generalBasis, decimal solidaryBasis)
		{
			Int32 taxStandard = AdvancesRegularyTax(period, generalBasis);

			if (SolidaryIncreaseEnabled())
			{
				Int32 taxSolidary = AdvancesSolidaryTax(period, solidaryBasis);

				return (taxStandard + taxSolidary);
			}

			return taxStandard;
		}

		// AdvancesRegularyTax
		public Int32 AdvancesRegularyTax(MonthPeriod period, decimal generallBasis)
		{
			decimal advancesFactor = PeriodAdvancesFactor (period);

			decimal advancesResult = TaxingOperations.DecFactorResult(generallBasis, advancesFactor);

			Int32 taxRegulary = TaxingOperations.IntRoundUp(advancesResult);

			return taxRegulary;
		}

		// AdvancesSolidaryTax
		public Int32 AdvancesSolidaryTax(MonthPeriod period, decimal solidaryBasis)
		{
			decimal solidaryFactor = PeriodSolidaryFactor (period);

			decimal solidaryResult = TaxingOperations.DecFactorResult(solidaryBasis, solidaryFactor);

			Int32 taxSolidary = TaxingOperations.IntRoundUp(solidaryResult);

			return taxSolidary;
		}

		// AdvancesSolidaryBasis
		public decimal AdvancesSolidaryBasis(MonthPeriod period, decimal taxableIncome)
		{
			decimal solidaryLimit = MinimumIncomeToApplySolidaryIncrease();

			decimal solidaryBasis = Math.Max(0, taxableIncome - solidaryLimit);

			return solidaryBasis;
		}

		// AdvancesRoundedBasis
		public decimal AdvancesRoundedBasisWithPartial(MonthPeriod period, decimal taxableHealth, decimal taxableSocial, decimal taxableIncome)
		{
			decimal taxableSuper = taxableIncome + taxableHealth + taxableSocial;

			return AdvancesRoundedBasis(period, taxableSuper);
		}

		public decimal AdvancesRoundedBasis(MonthPeriod period, decimal taxableIncome)
		{
			decimal amountForCalc = taxableIncome;

			if (BasisOfIncomeShouldBeEqualToZero(taxableIncome))
			{
				amountForCalc = 0;
			}

			decimal advanceBase = 0m;

			if (BasisShouldbeRoundedUpToHundreds(amountForCalc))
			{
				advanceBase = TaxingOperations.DecRoundUpHundreds(amountForCalc);
			}
			else
			{
				advanceBase = TaxingOperations.DecRoundUp(amountForCalc);
			}
			return advanceBase;
		}

		// AdvancesTaxableHealth
		public decimal AdvancesTaxableHealth(MonthPeriod period, bool isStatementSign, bool isResidencyCz, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentHealth)
		{
			return 0m;
		}

		// AdvancesTaxableSocial
		public decimal AdvancesTaxableSocial(MonthPeriod period, bool isStatementSign, bool isResidencyCz, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentSocial)
		{
			return 0m;
		}

		// AdvancesTaxableIncome
		public decimal AdvancesTaxableIncome(MonthPeriod period, bool isStatementSign, bool isResidencyCz, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentIncome)
		{
			return 0m;
		}

		// PayerBasicAllowance
		public Int32 StatementPayerBasicAllowance(bool isStatementSign, bool isResidencyCz)
		{
			if (isStatementSign) 
			{
				return __guides.PayerBasicAllowance ();
			}
			return 0;
		}
		// ChildrenAllowance
		public Int32 StatementChildrenAllowance(bool isStatementSign, byte inPerOrder, bool disabChildren)
		{
			if (isStatementSign) 
			{
				return __guides.ChildrenAllowance (inPerOrder, disabChildren);
			}
			return 0;
		}
		// PayerDisabAllowance
		public Int32 StatementPayerDisabAllowance(bool isStatementSign, byte inDegree)
		{
			if (isStatementSign) 
			{
				return __guides.PayerDisabilityAllowance (inDegree);
			}
			return 0;
		}
		// StatementPayerStudyAllowance
		public Int32 StatementPayerStudyAllowance(bool isStatementSign)
		{
			if (isStatementSign) 
			{
				return __guides.StudyingAllowance ();
			}
			return 0;
		}
		// StatementPayerTaxRebate
		public Int32 StatementPayerTaxRebate(Int32 advancesTax, Int32 payerAllowance, Int32 disabAllowance, Int32 studyAllowance)
		{
			decimal rebateApply = 0m;

			decimal claimsValue = payerAllowance + disabAllowance + studyAllowance;

			Int32 rebateValue = TaxingOperations.RebateResult (advancesTax, rebateApply, claimsValue);

			return rebateValue;
		}
		// ChildrenRebate
		public Int32 StatementChildrenRebate(Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance)
		{
			decimal claimsValue = childrenAllowance;

			Int32 rebateValue = TaxingOperations.RebateResult (advancesTax, payerRebate, claimsValue);

			return rebateValue;
		}
		// ChildrenBonus
		public Int32 StatementChildrenBonus(Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance, Int32 childrenRebate)
		{
			decimal bonusMaxChild = MaximumValidAmountOfTaxBonus ();

			decimal bonusMinChild = MinimumValidAmountOfTaxBonus ();

			decimal bonusForChild = decimal.Negate(Math.Min(0, childrenRebate - childrenAllowance));

			decimal bonusResult = TaxingOperations.LimitToMinMax (bonusForChild, bonusMinChild, bonusMaxChild);

			return IntRounding.RoundToInt( bonusResult );
		}

		// WithholdTax
		// WithholdRoundedBasis
		// WithholdTaxableHealth
		// WithholdTaxableSocial
		// WithholdTaxableIncome

		public ITaxingGuides Guides ()
		{
			return __guides;
		}

		#endregion

		private ITaxingGuides __guides;

		#region ITaxingGuides implementation

		public Int32 PayerBasicAllowance() 
		{
			return __guides.PayerBasicAllowance();
		}
		public Int32 PayerDisabilityAllowance (byte inDegree)
		{
			return __guides.PayerDisabilityAllowance(inDegree); 
		}
		public Int32 DisabilityDgr1Allowance() 
		{ 
			return __guides.DisabilityDgr1Allowance(); 
		}
		public Int32 DisabilityDgr2Allowance() 
		{ 
			return __guides.DisabilityDgr2Allowance(); 
		}
		public Int32 DisabilityDgr3Allowance() 
		{ 
			return __guides.DisabilityDgr3Allowance(); 
		}
		public Int32 StudyingAllowance() 
		{ 
			return __guides.StudyingAllowance(); 
		}
		public Int32 ChildrenAllowance (byte rank, bool disability)
		{
			return __guides.ChildrenAllowance(rank, disability); 
		}
		public Int32 ChildrenRank1stAllowance() 
		{ 
			return __guides.ChildrenRank1stAllowance(); 
		}
		public Int32 ChildrenRank2ndAllowance() 
		{ 
			return __guides.ChildrenRank2ndAllowance(); 
		}
		public Int32 ChildrenRank3rdAllowance() 
		{ 
			return __guides.ChildrenRank3rdAllowance(); 
		}
		public decimal AdvancesFactor() 
		{ 
			return __guides.AdvancesFactor(); 
		}
		public decimal WithholdFactor() 
		{ 
			return __guides.WithholdFactor(); 
		}
		public decimal SolidaryFactor() 
		{ 
			return __guides.SolidaryFactor(); 
		}
		public Int32 MinimumValidAmountOfTaxBonus() 
		{ 
			return __guides.MinimumValidAmountOfTaxBonus(); 
		}
		public Int32 MaximumValidAmountOfTaxBonus() 
		{ 
			return __guides.MaximumValidAmountOfTaxBonus(); 
		}
		public Int32 MinimumIncomeRequiredForTaxBonus() 
		{ 
			return __guides.MinimumIncomeRequiredForTaxBonus(); 
		}
		public Int32 MaximumIncomeToApplyRoundingToSingles() 
		{ 
			return __guides.MaximumIncomeToApplyRoundingToSingles(); 
		}
		public Int32 MaximumIncomeToApplyWithholdTax() 
		{ 
			return __guides.MaximumIncomeToApplyWithholdTax(); 
		}
		public Int32 MinimumIncomeToApplySolidaryIncrease() 
		{ 
			return __guides.MinimumIncomeToApplySolidaryIncrease(); 
		}
		public bool SolidaryIncreaseEnabled() 
		{ 
			return __guides.SolidaryIncreaseEnabled(); 
		}

		#endregion

		private decimal PeriodAdvancesFactor(MonthPeriod period) 
		{ 
			return __guides.AdvancesFactor(); 
		}

		private decimal PeriodSolidaryFactor(MonthPeriod period) 
		{ 
			return __guides.SolidaryFactor(); 
		}

		/// <summary>
		/// basis should be rounded up to hundreds
		/// </summary>
		/// <param name="income">
		/// taxable income
		/// </param>
		/// <returns>
		/// +bool+ basis is rounded to 100's == true
		/// </returns>
		private bool BasisShouldbeRoundedUpToHundreds(decimal income)
		{
			return (income <= MaximumIncomeToApplyRoundingToSingles());
		}

		/// <summary>
		/// basis of income should be equal to zero
		/// </summary>
		/// <param name="income">
		/// taxable income
		/// </param>
		/// <returns>
		/// +bool+ tax basis is zero == true
		/// </returns>
		private bool BasisOfIncomeShouldBeEqualToZero(decimal income)
		{
			return (income <= 0);
		}

	}
}

