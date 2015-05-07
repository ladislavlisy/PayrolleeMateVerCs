using System;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2014 : TaxingEnginePrototype
	{
		public TaxingEngine2014 ()
			: base(TaxingGuides.Guides2014())
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

