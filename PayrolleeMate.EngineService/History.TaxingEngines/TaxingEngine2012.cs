using System;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2012 : TaxingEnginePrototype
	{
		public TaxingEngine2012 ()
			: base(TaxingGuides.Guides2012())
		{
		}

		#region implemented abstract members of TaxingEnginePrototype

		public override bool WithholdTaxableIncome (MonthPeriod period, bool isStatementSign, bool isResidentCzech, WorkRelationTerms workTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalTaxIncome)
		{
			return false;
		}

		#endregion
	}
}

