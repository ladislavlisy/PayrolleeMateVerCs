using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.EngineService
{
	public class TaxingEnginePrototype : ITaxingEngine, ITaxingGuides
	{
		private static readonly int NUMBER_ONE_HUNDRED = 100;

		public TaxingEnginePrototype (TaxingGuides currentGuides)
		{
			__guides = currentGuides.Clone() as TaxingGuides;
		}

		private ITaxingGuides __guides;

		#region ITaxingEngine implementation

		public ITaxingGuides Guides ()
		{
			return __guides;
		}

		public decimal AdvancesBasisRoundedWithPartial(decimal taxableHealth, decimal taxableSocial, decimal taxableIncome)
		{
			decimal taxableSuper = taxableIncome + taxableHealth + taxableSocial;

			return AdvancesBasisRounded(taxableSuper);
		}

		public decimal AdvancesBasisRounded(decimal taxableIncome)
		{
			decimal amountForCalc = taxableIncome;

			if (BasisOfIncomeShouldBeEqualToZero(taxableIncome))
			{
				amountForCalc = 0;
			}

			decimal advanceBase = 0m;

			if (BasisShouldbeRoundedUpToHundreds(amountForCalc))
			{
				advanceBase = DecTaxRoundUpHundreds(amountForCalc);
			}
			else
			{
				advanceBase = DecTaxRoundUp(amountForCalc);
			}
			return advanceBase;
		}

		public decimal SolidaryBasis(decimal income)
		{
			decimal solidaryLimit = MinimumIncomeToApplySolidaryIncrease();

			decimal solidaryBasis = Math.Max(0, income - solidaryLimit);

			return solidaryBasis;
		}

		public long AdvancesPartResult(decimal generallBasis)
		{
			decimal factorResult = DecTaxFactorResult(generallBasis, AdvancesFactor());

			long taxStandard = IntTaxRoundUp(factorResult);

			return taxStandard;
		}

		public long SolidaryPartResult(decimal solidaryBasis)
		{
			decimal factorResult = DecTaxFactorResult(solidaryBasis, SolidaryFactor());

			long taxSolidary = IntTaxRoundUp(factorResult);

			return taxSolidary;
		}

		public long AdvancesResult(decimal taxableIncome, decimal generallBasis, decimal solidaryBasis)
		{
			long taxStandard = AdvancesPartResult(generallBasis);

			if (SolidaryIncreaseEnabled())
			{
				long taxSolidary = SolidaryPartResult(solidaryBasis);

				return (taxStandard + taxSolidary);
			}

			return taxStandard;
		}

		#endregion

		#region ITaxingGuides implementation

		public Int32 PayerBasicAllowance() 
		{
			return __guides.PayerBasicAllowance();
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

		public static decimal DecTaxRoundUp(decimal valueDec)
		{
			return DecRounding.RoundUp(valueDec);
		}

		public static int IntTaxRoundUp(decimal valueDec)
		{
			return IntRounding.RoundUp(valueDec);
		}

		public static decimal DecTaxRoundDown(decimal valueDec)
		{
			return DecRounding.RoundDown(valueDec);
		}

		public static int IntTaxRoundDown(decimal valueDec)
		{
			return IntRounding.RoundDown(valueDec);
		}

		public static decimal DecTaxRoundUpHundreds(decimal valueDec)
		{
			return DecRounding.NearRoundUp(valueDec, NUMBER_ONE_HUNDRED);
		}

		public static decimal DecTaxFactorResult(decimal valueDec, decimal factor)
		{
			return DecOperation.Multiply(valueDec, factor);
		}
		}
}

