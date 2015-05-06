using System;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2013 : HealthEnginePrototype
	{
		public HealthEngine2013 ()
			: base(HealthGuides.Guides2013())
		{
		}

		#region implemented abstract members of HealthEnginePrototype

		public override Int32 PeriodMandatoryBasis (MonthPeriod period)
		{
			if (period.Year () == 2013 && period.Month () < 8)
			{
				return HealthProperties2013.BASIS_MANDATORY_FROM_01_TO_07;				
			}
			return Guides().MandatoryBasis ();
		}

		public override bool ParticipateHealthIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkHealthTerms healthTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			return true;
		}

		#endregion

	}
}

