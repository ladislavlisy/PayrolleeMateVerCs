using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface ITaxingEngine : IPeriodTaxingGuides
	{
		ITaxingGuides Guides();

		Int32 AdvancesResult (MonthPeriod period, decimal taxableIncome, decimal generalBasis, decimal solidaryBasis);

		Int32 AdvancesRegularyTax (MonthPeriod period, decimal generallBasis);

		Int32 AdvancesSolidaryTax (MonthPeriod period, decimal solidaryBasis);

		decimal AdvancesSolidaryBasis (MonthPeriod period, decimal taxableIncome);

		decimal AdvancesRoundedBasisWithPartial (MonthPeriod period, decimal taxableHealth, decimal taxableSocial, decimal taxableIncome);

		decimal AdvancesRoundedBasis (MonthPeriod period, decimal taxableIncome);

		decimal AdvancesTaxableHealth (MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentHealth);

		decimal AdvancesTaxableSocial (MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentSocial);

		decimal AdvancesTaxableIncome (MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, decimal taxableIncome, decimal employmentIncome);

		Int32 StatementPayerBasicAllowance (MonthPeriod period, bool isStatementSign, bool isResidentCzech);

		Int32 StatementChildrenAllowance (MonthPeriod period, bool isStatementSign, byte inPerOrder, bool disabChildren);

		Int32 StatementPayerDisabAllowance (MonthPeriod period, bool isStatementSign, byte inDegree);

		Int32 StatementPayerStudyAllowance (MonthPeriod period, bool isStatementSign);

		Int32 StatementPayerTaxRebate (MonthPeriod period, Int32 advancesTax, Int32 payerAllowance, Int32 disabAllowance, Int32 studyAllowance);

		Int32 StatementChildrenRebate (MonthPeriod period, Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance);

		Int32 StatementChildrenBonus (MonthPeriod period, Int32 advancesTax, Int32 payerRebate, Int32 childrenAllowance, Int32 childrenRebate);
	}
}

