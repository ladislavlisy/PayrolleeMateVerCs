using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Taxing
{
	public class TaxingEnginePrototype : ITaxingEngine
	{
		public TaxingEnginePrototype (TaxingGuides currentGuides)
		{
			__guides = currentGuides.Clone() as TaxingGuides;
		}

		#region ITaxingEngine implementation

		// AdvancesTax
		public Int32 AdvancesResult(MonthPeriod period, decimal taxableIncome, decimal generalBasis, decimal solidaryBasis)
		{
			Int32 taxStandard = AdvancesRegularyTax(period, generalBasis);

			if (PeriodSolidaryIncreaseEnabled (period))
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
			decimal solidaryLimit = PeriodMinimumIncomeToApplySolidaryIncrease (period);

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

			if (BasisShouldbeRoundedUpToHundreds(period, amountForCalc))
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
		public decimal AdvancesTaxableHealth(MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentHealth)
		{
			return 0m;
		}

		// AdvancesTaxableSocial
		public decimal AdvancesTaxableSocial(MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentSocial)
		{
			return 0m;
		}

		// AdvancesTaxableIncome
		public decimal AdvancesTaxableIncome(MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentIncome)
		{
			return 0m;
		}

		// PayerBasicAllowance
		public Int32 StatementPayerBasicAllowance(MonthPeriod period, bool isStatementSign, bool isResidentCzech)
		{
			if (isStatementSign) 
			{
				return PeriodPayerBasicAllowance (period);
			}
			return 0;
		}
		// ChildrenAllowance
		public Int32 StatementChildrenAllowance(MonthPeriod period, bool isStatementSign, byte inPerOrder, bool disabChildren)
		{
			if (isStatementSign) 
			{
				return PeriodChildrenAllowance (period, inPerOrder, disabChildren);
			}
			return 0;
		}
		// PayerDisabAllowance
		public Int32 StatementPayerDisabAllowance(MonthPeriod period, bool isStatementSign, byte inDegree)
		{
			if (isStatementSign) 
			{
				return PeriodPayerDisabilityAllowance (period, inDegree);
			}
			return 0;
		}
		// StatementPayerStudyAllowance
		public Int32 StatementPayerStudyAllowance(MonthPeriod period, bool isStatementSign)
		{
			if (isStatementSign) 
			{
				return PeriodStudyingAllowance (period);
			}
			return 0;
		}
		// StatementPayerTaxRebate
		public Int32 StatementPayerTaxRebate(MonthPeriod period, Int32 advancesTax, Int32 payerAllowance, Int32 disabAllowance, Int32 studyAllowance)
		{
			decimal rebateApply = 0m;

			decimal claimsValue = payerAllowance + disabAllowance + studyAllowance;

			Int32 rebateValue = TaxingOperations.RebateResult (advancesTax, rebateApply, claimsValue);

			return rebateValue;
		}
		// ChildrenRebate
		public Int32 StatementChildrenRebate(MonthPeriod period, Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance)
		{
			decimal claimsValue = childrenAllowance;

			Int32 rebateValue = TaxingOperations.RebateResult (advancesTax, payerRebate, claimsValue);

			return rebateValue;
		}
		// ChildrenBonus
		public Int32 StatementChildrenBonus(MonthPeriod period, Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance, Int32 childrenRebate)
		{
			decimal bonusMaxChild = PeriodMaximumValidAmountOfTaxBonus (period);

			decimal bonusMinChild = PeriodMinimumValidAmountOfTaxBonus (period);

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

		#region IPeriodTaxingGuides implementation

		public virtual Int32 PeriodPayerBasicAllowance(MonthPeriod period) 
		{
			return __guides.PayerBasicAllowance();
		}

		public virtual Int32 PeriodPayerDisabilityAllowance (MonthPeriod period, byte inDegree)
		{
			return __guides.PayerDisabilityAllowance(inDegree); 
		}

		public virtual Int32 PeriodDisabilityDgr1Allowance(MonthPeriod period) 
		{ 
			return __guides.DisabilityDgr1Allowance(); 
		}

		public virtual Int32 PeriodDisabilityDgr2Allowance(MonthPeriod period) 
		{ 
			return __guides.DisabilityDgr2Allowance(); 
		}

		public virtual Int32 PeriodDisabilityDgr3Allowance(MonthPeriod period) 
		{ 
			return __guides.DisabilityDgr3Allowance(); 
		}

		public virtual Int32 PeriodStudyingAllowance(MonthPeriod period) 
		{ 
			return __guides.StudyingAllowance(); 
		}

		public virtual Int32 PeriodChildrenAllowance (MonthPeriod period, byte rank, bool disability)
		{
			return __guides.ChildrenAllowance(rank, disability); 
		}

		public virtual Int32 PeriodChildrenRank1stAllowance(MonthPeriod period) 
		{ 
			return __guides.ChildrenRank1stAllowance(); 
		}

		public virtual Int32 PeriodChildrenRank2ndAllowance(MonthPeriod period) 
		{ 
			return __guides.ChildrenRank2ndAllowance(); 
		}

		public virtual Int32 PeriodChildrenRank3rdAllowance(MonthPeriod period) 
		{ 
			return __guides.ChildrenRank3rdAllowance(); 
		}

		public virtual decimal PeriodAdvancesFactor(MonthPeriod period) 
		{ 
			return __guides.AdvancesFactor(); 
		}

		public virtual decimal PeriodWithholdFactor(MonthPeriod period) 
		{ 
			return __guides.WithholdFactor(); 
		}

		public virtual decimal PeriodSolidaryFactor(MonthPeriod period) 
		{ 
			return __guides.SolidaryFactor(); 
		}

		public virtual Int32 PeriodMinimumValidAmountOfTaxBonus(MonthPeriod period) 
		{ 
			return __guides.MinimumValidAmountOfTaxBonus(); 
		}

		public virtual Int32 PeriodMaximumValidAmountOfTaxBonus(MonthPeriod period) 
		{ 
			return __guides.MaximumValidAmountOfTaxBonus(); 
		}

		public virtual Int32 PeriodMinimumIncomeRequiredForTaxBonus(MonthPeriod period) 
		{ 
			return __guides.MinimumIncomeRequiredForTaxBonus(); 
		}

		public virtual Int32 PeriodMaximumIncomeToApplyRoundingToSingles(MonthPeriod period) 
		{ 
			return __guides.MaximumIncomeToApplyRoundingToSingles(); 
		}

		public virtual Int32 PeriodMaximumIncomeToApplyWithholdTax(MonthPeriod period) 
		{ 
			return __guides.MaximumIncomeToApplyWithholdTax(); 
		}

		public virtual Int32 PeriodMinimumIncomeToApplySolidaryIncrease(MonthPeriod period) 
		{ 
			return __guides.MinimumIncomeToApplySolidaryIncrease(); 
		}

		public virtual bool PeriodSolidaryIncreaseEnabled(MonthPeriod period) 
		{ 
			return __guides.SolidaryIncreaseEnabled(); 
		}

		#endregion

		/// <summary>
		/// basis should be rounded up to hundreds
		/// </summary>
		/// <param name="income">
		/// taxable income
		/// </param>
		/// <returns>
		/// +bool+ basis is rounded to 100's == true
		/// </returns>
		private bool BasisShouldbeRoundedUpToHundreds(MonthPeriod period, decimal income)
		{
			return (income <= PeriodMaximumIncomeToApplyRoundingToSingles(period));
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

