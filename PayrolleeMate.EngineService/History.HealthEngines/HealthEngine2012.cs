using System;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2012 : HealthEnginePrototype
	{
		public HealthEngine2012 ()
			: base(HealthGuides.Guides2012())
		{
		}

		#region implemented abstract members of HealthEnginePrototype

		public override bool ParticipateHealthIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkHealthTerms healthTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			return true;
		}

		#endregion

	}
}

