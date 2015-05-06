using System;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2011 : HealthEnginePrototype
	{
		public HealthEngine2011 ()
			: base(HealthGuides.Guides2011())
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

