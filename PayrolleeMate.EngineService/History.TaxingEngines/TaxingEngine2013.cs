using System;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2013 : TaxingEnginePrototype
	{
		public TaxingEngine2013 ()
			: base(TaxingGuides.Guides2013())
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

