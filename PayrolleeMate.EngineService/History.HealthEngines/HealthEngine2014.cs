using System;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2014 : HealthEnginePrototype
	{
		public HealthEngine2014 ()
			: base(HealthGuides.Guides2014())
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

