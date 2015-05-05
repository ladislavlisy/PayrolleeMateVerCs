using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public interface IPeriodTaxingGuides
	{
		Int32 PeriodPayerBasicAllowance (MonthPeriod period); 

		Int32 PeriodPayerDisabilityAllowance (MonthPeriod period, byte inDegree);

		Int32 PeriodDisabilityDgr1Allowance (MonthPeriod period); 

		Int32 PeriodDisabilityDgr2Allowance (MonthPeriod period); 

		Int32 PeriodDisabilityDgr3Allowance (MonthPeriod period); 

		Int32 PeriodStudyingAllowance (MonthPeriod period); 

		Int32 PeriodChildrenAllowance (MonthPeriod period, byte rank, bool disability);

		Int32 PeriodChildrenRank1stAllowance (MonthPeriod period); 

		Int32 PeriodChildrenRank2ndAllowance (MonthPeriod period); 

		Int32 PeriodChildrenRank3rdAllowance (MonthPeriod period); 

		decimal PeriodAdvancesFactor (MonthPeriod period); 
	
		decimal PeriodHealthIncreaseFactor (MonthPeriod period);

		decimal PeriodSocialIncreaseFactor (MonthPeriod period);

		decimal PeriodWithholdFactor (MonthPeriod period); 

		decimal PeriodSolidaryFactor (MonthPeriod period); 

		Int32 PeriodMinimumValidAmountOfTaxBonus (MonthPeriod period); 

		Int32 PeriodMaximumValidAmountOfTaxBonus (MonthPeriod period); 

		Int32 PeriodMinimumIncomeRequiredForTaxBonus (MonthPeriod period); 

		Int32 PeriodMaximumIncomeToApplyRoundingToSingles (MonthPeriod period); 

		Int32 PeriodMaximumIncomeToApplyWithholdTax (MonthPeriod period); 

		Int32 PeriodMinimumIncomeToApplySolidaryIncrease (MonthPeriod period); 

		bool PeriodSolidaryIncreaseEnabled (MonthPeriod period); 
	}
}

