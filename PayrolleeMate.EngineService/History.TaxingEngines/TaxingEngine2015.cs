using System;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2015 : TaxingEnginePrototype
	{
		public TaxingEngine2015 ()
			: base(TaxingGuides.Guides2015())
		{
		}

		#region implemented abstract members of TaxingEnginePrototype

		public override bool WithholdTaxableIncome (MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalTaxIncome)
		{
			bool notSignedStatement = (!isStatementSign);

			if (notSignedStatement) 
			{
				bool agreementTasksTerm = (workTerm == WorkRelationTerms.WORKTERM_CONTRACTER_T);

				bool agreementIncomeMax = (workTermIncome < PeriodMaximumIncomeToApplyWithholdTax (period));

				if (agreementTasksTerm && agreementIncomeMax) 
				{
					return true;
				}

				bool statutoryTasksTerm = (workTerm == WorkRelationTerms.WORKTERM_STATUTORY__Q);

				bool foreignTaxResident = (!isResidentCzech);

				if (statutoryTasksTerm && foreignTaxResident) 
				{
					return true;
				}
			}
			return false;
		}

		#endregion
	}
}

