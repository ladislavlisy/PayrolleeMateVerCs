using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Taxing
{
	public interface ITaxingGuides
	{
		bool ValidatePeriod (MonthPeriod period);

		Int32 PayerBasicAllowance ();

		Int32 PayerDisabilityAllowance (byte inDegree);

		Int32 DisabilityDgr1Allowance ();

		Int32 DisabilityDgr2Allowance ();

		Int32 DisabilityDgr3Allowance ();

		Int32 StudyingAllowance ();

		Int32 ChildrenAllowance (byte inPerOrder, bool disability);

		Int32 ChildrenRank1stAllowance (); 

		Int32 ChildrenRank2ndAllowance ();

		Int32 ChildrenRank3rdAllowance ();

		decimal AdvancesFactor ();

		decimal WithholdFactor ();

		decimal SolidaryFactor ();

		Int32 MinimumValidAmountOfTaxBonus ();

		Int32 MaximumValidAmountOfTaxBonus ();

		Int32 MinimumIncomeRequiredForTaxBonus ();

		Int32 MaximumIncomeToApplyRoundingToSingles ();

		Int32 MaximumIncomeToApplyWithholdTax ();

		Int32 MinimumIncomeToApplySolidaryIncrease (); 

		bool SolidaryIncreaseEnabled (); 
	}
}

