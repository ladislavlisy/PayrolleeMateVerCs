using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface ITaxingEngine : IPeriodTaxingGuides
	{
		ITaxingGuides Guides();

		decimal SubjectTaxingSelector (MonthPeriod period, bool taxSubject, bool taxArticle, decimal valResult);

		decimal SubjectHealthSelector (MonthPeriod period, bool taxSubject, bool insSubject, bool taxArticle, bool insArticle, bool insParticip, decimal valResult);

		decimal SubjectSocialSelector (MonthPeriod period, bool taxSubject, bool insSubject, bool taxArticle, bool insArticle, bool insParticip, decimal valResult);

		decimal AdvancesTaxSelector (MonthPeriod period, bool advancesSubject, decimal valResult);

		decimal WithholdTaxSelector (MonthPeriod period, bool withholdSubject, decimal valResult);

		decimal AdvancesRoundedBasisWithPartial (MonthPeriod period, decimal taxableHealth, decimal taxableSocial, decimal taxableIncome);

		decimal AdvancesRoundedBasis (MonthPeriod period, decimal taxableIncome);

		decimal AdvancesSolidaryBasis (MonthPeriod period, decimal taxableIncome);

		Int32 AdvancesResultTax (MonthPeriod period, decimal taxableIncome, decimal generalBasis, decimal solidaryBasis);

		Int32 AdvancesRegularyTax (MonthPeriod period, decimal generalBasis);

		Int32 AdvancesSolidaryTax (MonthPeriod period, decimal solidaryBasis);

		decimal AdvancesTaxableHealth (MonthPeriod period, bool advancesSubject, decimal taxableHealthIncome);

		decimal AdvancesTaxableSocial (MonthPeriod period, bool advancesSubject, decimal taxableSocialIncome);

		bool AdvancesTaxableIncome (MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalTaxIncome);

		decimal WithholdRoundedBasis (MonthPeriod period, decimal taxableIncome);

		decimal WithholdTaxableHealth (MonthPeriod period, bool withholdSubject, decimal taxableHealthIncome);

		decimal WithholdTaxableSocial (MonthPeriod period, bool withholdSubject, decimal taxableSocialIncome);

		Int32 WithholdResultTax (MonthPeriod period, decimal generalBasis);

		bool WithholdTaxableIncome (MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalTaxIncome);

		Int32 StatementPayerBasicAllowance (MonthPeriod period, bool isStatementSign, bool isResidentCzech);

		Int32 StatementChildrenAllowance (MonthPeriod period, bool isStatementSign, byte inPerOrder, bool disabChildren);

		Int32 StatementPayerDisabAllowance (MonthPeriod period, bool isStatementSign, byte inDegree);

		Int32 StatementPayerStudyAllowance (MonthPeriod period, bool isStatementSign);

		Int32 StatementPayerTaxRebate (MonthPeriod period, Int32 advancesTax, Int32 payerAllowance, Int32 disabAllowance, Int32 studyAllowance);

		Int32 StatementChildrenRebate (MonthPeriod period, Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance);

		Int32 StatementChildrenBonus (MonthPeriod period, Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance, Int32 childrenRebate);
	}
}

