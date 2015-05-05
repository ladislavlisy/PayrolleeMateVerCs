using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Taxing
{
	public class TaxingGuides : EngineGeneralGuides, ITaxingGuides
	{
		private const Int32 ALLOWANCE_DISABILITY_MULTIPLIER = 2;

		public const byte ALLOWANCE_CHILDREN_RANK_1ST = 1;
			
		public const byte ALLOWANCE_CHILDREN_RANK_2ND = 2;

		public const byte ALLOWANCE_CHILDREN_RANK_3RD = 3;

		public const byte ALLOWANCE_DISAB_DEGREE_1ST = 1;

		public const byte ALLOWANCE_DISAB_DEGREE_2ND = 2;

		public const byte ALLOWANCE_DISAB_DEGREE_3RD = 3;

		private readonly Int32 __PayerBasicAllowance;
		private readonly Int32 __DisabilityDgr1Allowance;
		private readonly Int32 __DisabilityDgr2Allowance;
		private readonly Int32 __DisabilityDgr3Allowance;
		private readonly Int32 __StudyingAllowance;
		private readonly Int32 __ChildrenRank1stAllowance;
		private readonly Int32 __ChildrenRank2ndAllowance;
		private readonly Int32 __ChildrenRank3rdAllowance;
		private readonly decimal __HealthIncreaseFactor;
		private readonly decimal __SocialIncreaseFactor;
		private readonly decimal __AdvancesFactor;
		private readonly decimal __WithholdFactor;
		private readonly decimal __SolidaryFactor;
		private readonly Int32 __MinimumValidAmountOfTaxBonus;
		private readonly Int32 __MaximumValidAmountOfTaxBonus;
		private readonly Int32 __MinimumIncomeRequiredForTaxBonus;
		private readonly Int32 __MaximumIncomeToApplyRoundingToSingles;
		private readonly Int32 __MaximumIncomeToApplyWithholdTax;
		private readonly Int32 __MinimumIncomeToApplySolidaryIncrease;

		public static TaxingGuides Guides2015()
		{
			return new TaxingGuides (TaxingProperties2015.YEAR_2015,
				TaxingProperties2015.ALLOWANCE_PAYER_BASIC,
				TaxingProperties2015.ALLOWANCE_PAYER_DIS_1ST,
				TaxingProperties2015.ALLOWANCE_PAYER_DIS_2ND,
				TaxingProperties2015.ALLOWANCE_PAYER_DIS_3RD,
				TaxingProperties2015.ALLOWANCE_PAYER_STUDYING,
				TaxingProperties2015.ALLOWANCE_CHILD_RANK_1ST,
				TaxingProperties2015.ALLOWANCE_CHILD_RANK_2ND,
				TaxingProperties2015.ALLOWANCE_CHILD_RANK_3RD,
				HealthProperties2015.FACTOR_COMPOUND,
				SocialProperties2015.FACTOR_EMPLOYER,
				TaxingProperties2015.FACTOR_ADVANCES,
				TaxingProperties2015.FACTOR_WITHHOLD,
				TaxingProperties2015.FACTOR_SOLIDARY,
				TaxingProperties2015.MIN_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2015.MAX_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2015.MIN_INCOME_REQUIRED_FOR_TAXBONUS,
				TaxingProperties2015.MAX_INCOME_APPLY_SINGELS_ROUNDING,
				TaxingProperties2015.MAX_INCOME_APPLY_WITHHOLD_TAX,
				TaxingProperties2015.MIN_INCOME_APPLY_SOLIDARY_INCREASE);
		}

		public static TaxingGuides Guides2014()
		{
			return new TaxingGuides (TaxingProperties2014.YEAR_2014,
				TaxingProperties2014.ALLOWANCE_PAYER_BASIC,
				TaxingProperties2014.ALLOWANCE_PAYER_DIS_1ST,
				TaxingProperties2014.ALLOWANCE_PAYER_DIS_2ND,
				TaxingProperties2014.ALLOWANCE_PAYER_DIS_3RD,
				TaxingProperties2014.ALLOWANCE_PAYER_STUDYING,
				TaxingProperties2014.ALLOWANCE_CHILD_RANK_1ST,
				TaxingProperties2014.ALLOWANCE_CHILD_RANK_2ND,
				TaxingProperties2014.ALLOWANCE_CHILD_RANK_3RD,
				HealthProperties2014.FACTOR_COMPOUND,
				SocialProperties2014.FACTOR_EMPLOYER,
				TaxingProperties2014.FACTOR_ADVANCES,
				TaxingProperties2014.FACTOR_WITHHOLD,
				TaxingProperties2014.FACTOR_SOLIDARY,
				TaxingProperties2014.MIN_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2014.MAX_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2014.MIN_INCOME_REQUIRED_FOR_TAXBONUS,
				TaxingProperties2014.MAX_INCOME_APPLY_SINGELS_ROUNDING,
				TaxingProperties2014.MAX_INCOME_APPLY_WITHHOLD_TAX,
				TaxingProperties2014.MIN_INCOME_APPLY_SOLIDARY_INCREASE);
		}

		public static TaxingGuides Guides2013()
		{
			return new TaxingGuides (TaxingProperties2013.YEAR_2013,
				TaxingProperties2013.ALLOWANCE_PAYER_BASIC,
				TaxingProperties2013.ALLOWANCE_PAYER_DIS_1ST,
				TaxingProperties2013.ALLOWANCE_PAYER_DIS_2ND,
				TaxingProperties2013.ALLOWANCE_PAYER_DIS_3RD,
				TaxingProperties2013.ALLOWANCE_PAYER_STUDYING,
				TaxingProperties2013.ALLOWANCE_CHILD_RANK_1ST,
				TaxingProperties2013.ALLOWANCE_CHILD_RANK_2ND,
				TaxingProperties2013.ALLOWANCE_CHILD_RANK_3RD,
				HealthProperties2013.FACTOR_COMPOUND,
				SocialProperties2013.FACTOR_EMPLOYER,
				TaxingProperties2013.FACTOR_ADVANCES,
				TaxingProperties2013.FACTOR_WITHHOLD,
				TaxingProperties2013.FACTOR_SOLIDARY,
				TaxingProperties2013.MIN_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2013.MAX_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2013.MIN_INCOME_REQUIRED_FOR_TAXBONUS,
				TaxingProperties2013.MAX_INCOME_APPLY_SINGELS_ROUNDING,
				TaxingProperties2013.MAX_INCOME_APPLY_WITHHOLD_TAX,
				TaxingProperties2013.MIN_INCOME_APPLY_SOLIDARY_INCREASE);
		}

		public static TaxingGuides Guides2012()
		{
			return new TaxingGuides (TaxingProperties2012.YEAR_2012,
				TaxingProperties2012.ALLOWANCE_PAYER_BASIC,
				TaxingProperties2012.ALLOWANCE_PAYER_DIS_1ST,
				TaxingProperties2012.ALLOWANCE_PAYER_DIS_2ND,
				TaxingProperties2012.ALLOWANCE_PAYER_DIS_3RD,
				TaxingProperties2012.ALLOWANCE_PAYER_STUDYING,
				TaxingProperties2012.ALLOWANCE_CHILD_RANK_1ST,
				TaxingProperties2012.ALLOWANCE_CHILD_RANK_2ND,
				TaxingProperties2012.ALLOWANCE_CHILD_RANK_3RD,
				HealthProperties2012.FACTOR_COMPOUND,
				SocialProperties2012.FACTOR_EMPLOYER,
				TaxingProperties2012.FACTOR_ADVANCES,
				TaxingProperties2012.FACTOR_WITHHOLD,
				TaxingProperties2012.FACTOR_SOLIDARY,
				TaxingProperties2012.MIN_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2012.MAX_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2012.MIN_INCOME_REQUIRED_FOR_TAXBONUS,
				TaxingProperties2012.MAX_INCOME_APPLY_SINGELS_ROUNDING,
				TaxingProperties2012.MAX_INCOME_APPLY_WITHHOLD_TAX,
				TaxingProperties2012.MIN_INCOME_APPLY_SOLIDARY_INCREASE);
		}

		public static TaxingGuides Guides2011()
		{
			return new TaxingGuides (TaxingProperties2011.YEAR_2011,
				TaxingProperties2011.ALLOWANCE_PAYER_BASIC,
				TaxingProperties2011.ALLOWANCE_PAYER_DIS_1ST,
				TaxingProperties2011.ALLOWANCE_PAYER_DIS_2ND,
				TaxingProperties2011.ALLOWANCE_PAYER_DIS_3RD,
				TaxingProperties2011.ALLOWANCE_PAYER_STUDYING,
				TaxingProperties2011.ALLOWANCE_CHILD_RANK_1ST,
				TaxingProperties2011.ALLOWANCE_CHILD_RANK_2ND,
				TaxingProperties2011.ALLOWANCE_CHILD_RANK_3RD,
				HealthProperties2011.FACTOR_COMPOUND,
				SocialProperties2011.FACTOR_EMPLOYER,
				TaxingProperties2011.FACTOR_ADVANCES,
				TaxingProperties2011.FACTOR_WITHHOLD,
				TaxingProperties2011.FACTOR_SOLIDARY,
				TaxingProperties2011.MIN_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2011.MAX_VALID_AMOUNT_OF_TAXBONUS,
				TaxingProperties2011.MIN_INCOME_REQUIRED_FOR_TAXBONUS,
				TaxingProperties2011.MAX_INCOME_APPLY_SINGELS_ROUNDING,
				TaxingProperties2011.MAX_INCOME_APPLY_WITHHOLD_TAX,
				TaxingProperties2011.MIN_INCOME_APPLY_SOLIDARY_INCREASE);
		}

		private TaxingGuides(
			uint validYear,
			Int32 payerBasic,
			Int32 payerDisab1,
			Int32 payerDisab2,
			Int32 payerDisab3, 
			Int32 payerStudy,
			Int32 childRank1,
			Int32 childRank2,
			Int32 childRank3,
			decimal factorHealth,
			decimal factorSocial,
			decimal factorAdvances,
			decimal factorWithhold,
			decimal factorSolidary, 
			Int32 minToValidBonus,
			Int32 maxToValidBonus,
			Int32 minToClaimBonus,
			Int32 maxToSingleRound,
			Int32 maxToWithholdTax,
			Int32 minToSolidaryInc) : base(validYear)
		{
			__PayerBasicAllowance = payerBasic;
			__DisabilityDgr1Allowance = payerDisab1;
			__DisabilityDgr2Allowance = payerDisab2;
			__DisabilityDgr3Allowance = payerDisab3;
			__StudyingAllowance = payerStudy;
			__ChildrenRank1stAllowance = childRank1;
			__ChildrenRank2ndAllowance = childRank2;
			__ChildrenRank3rdAllowance = childRank3;
			__HealthIncreaseFactor = factorHealth;
			__SocialIncreaseFactor = factorSocial;
			__AdvancesFactor = factorAdvances;
			__WithholdFactor = factorWithhold;
			__SolidaryFactor = factorSolidary;
			__MinimumValidAmountOfTaxBonus = minToValidBonus;
			__MaximumValidAmountOfTaxBonus = maxToValidBonus;
			__MinimumIncomeRequiredForTaxBonus = minToClaimBonus;
			__MaximumIncomeToApplyRoundingToSingles = maxToSingleRound;
			__MaximumIncomeToApplyWithholdTax = maxToWithholdTax;
			__MinimumIncomeToApplySolidaryIncrease = minToSolidaryInc;
		}

		public Int32 PayerBasicAllowance() 
		{
			return __PayerBasicAllowance;
		}
		public Int32 PayerDisabilityAllowance (byte inDegree)
		{
			switch (inDegree) 
			{
			case ALLOWANCE_DISAB_DEGREE_1ST:
				return DisabilityDgr1Allowance ();
			case ALLOWANCE_DISAB_DEGREE_2ND:
				return DisabilityDgr2Allowance ();
			case ALLOWANCE_DISAB_DEGREE_3RD:
				return DisabilityDgr3Allowance ();
			}
			return 0; 
		}
		public Int32 DisabilityDgr1Allowance() 
		{ 
			return __DisabilityDgr1Allowance; 
		}
		public Int32 DisabilityDgr2Allowance() 
		{ 
			return __DisabilityDgr2Allowance; 
		}
		public Int32 DisabilityDgr3Allowance() 
		{ 
			return __DisabilityDgr3Allowance; 
		}
		public Int32 StudyingAllowance() 
		{ 
			return __StudyingAllowance; 
		}
		public Int32 ChildrenAllowance(byte inPerOrder, bool disability) 
		{ 
			switch (inPerOrder) 
			{
			case ALLOWANCE_CHILDREN_RANK_1ST:
				return ChildrenAllowanceValue (__ChildrenRank1stAllowance, disability);
			case ALLOWANCE_CHILDREN_RANK_2ND:
				return ChildrenAllowanceValue (__ChildrenRank2ndAllowance, disability);
			case ALLOWANCE_CHILDREN_RANK_3RD:
				return ChildrenAllowanceValue (__ChildrenRank3rdAllowance, disability);
			}
			return 0; 
		}
		public Int32 ChildrenAllowanceValue(Int32 value, bool disability) 
		{ 
			if (disability) {
				return ALLOWANCE_DISABILITY_MULTIPLIER * value;
			} else {
				return value;
			}
		}
		public Int32 ChildrenRank1stAllowance() 
		{ 
			return __ChildrenRank1stAllowance; 
		}
		public Int32 ChildrenRank2ndAllowance() 
		{ 
			return __ChildrenRank2ndAllowance; 
		}
		public Int32 ChildrenRank3rdAllowance() 
		{ 
			return __ChildrenRank3rdAllowance; 
		}
		public decimal HealthIncreaseFactor() 
		{ 
			return __HealthIncreaseFactor; 
		}
		public decimal SocialIncreaseFactor() 
		{ 
			return __SocialIncreaseFactor; 
		}
		public decimal AdvancesFactor() 
		{ 
			return __AdvancesFactor; 
		}
		public decimal WithholdFactor() 
		{ 
			return __WithholdFactor; 
		}
		public decimal SolidaryFactor() 
		{ 
			return __SolidaryFactor; 
		}
		public Int32 MinimumValidAmountOfTaxBonus() 
		{ 
			return __MinimumValidAmountOfTaxBonus; 
		}
		public Int32 MaximumValidAmountOfTaxBonus() 
		{ 
			return __MaximumValidAmountOfTaxBonus; 
		}
		public Int32 MinimumIncomeRequiredForTaxBonus() 
		{ 
			return __MinimumIncomeRequiredForTaxBonus; 
		}
		public Int32 MaximumIncomeToApplyRoundingToSingles() 
		{ 
			return __MaximumIncomeToApplyRoundingToSingles; 
		}
		public Int32 MaximumIncomeToApplyWithholdTax() 
		{ 
			return __MaximumIncomeToApplyWithholdTax; 
		}
		public Int32 MinimumIncomeToApplySolidaryIncrease() 
		{ 
			return __MinimumIncomeToApplySolidaryIncrease; 
		}
		public bool SolidaryIncreaseEnabled() 
		{ 
			return (__MinimumIncomeToApplySolidaryIncrease > 0); 
		}

		public virtual object Clone()
		{
			TaxingGuides other = (TaxingGuides)this.MemberwiseClone();
			return other;
		}
	}
}

