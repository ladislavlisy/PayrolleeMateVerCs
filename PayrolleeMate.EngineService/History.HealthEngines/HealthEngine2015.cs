using System;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2015 : HealthEnginePrototype
	{
		public HealthEngine2015 ()
			: base(HealthGuides.Guides2015())
		{
		}

		#region implemented abstract members of HealthEnginePrototype

		public override bool ParticipateHealthIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkHealthTerms healthTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			bool workTermAgreementTasks = (workTerm == WorkRelationTerms.WORKTERM_CONTRACTER_T);

			if (workTermAgreementTasks) 
			{
				return ParticipateAgreementTasks (period, contractIncome, workTermIncome, totalInsIncome);
			}
			else 
			{
				switch (healthTerm) {
				case WorkHealthTerms.HEALTH_TERM_EMPLOYMENT:
					return ParticipateEmployment (period, contractIncome, workTermIncome, totalInsIncome);

				case WorkHealthTerms.HEALTH_TERM_AGREE_WORK:
				case WorkHealthTerms.HEALTH_TERM_AGREE_TASK:
				case WorkHealthTerms.HEALTH_TERM_OUT_EMPLOY:
					return ParticipateOutOfEmployment (period, contractIncome, workTermIncome, totalInsIncome);

				default:
					return true;
				}
			}
		}
		#endregion

		private bool ParticipateAgreementTasks (MonthPeriod period, decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			decimal marginalIncome = PeriodMarginalIncomeAgreeTasks (period);

			if (workTermIncome < marginalIncome) 
			{
				return false;
			}
			return true;
		}

		private bool ParticipateEmployment (MonthPeriod period, decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			return true;
		}

		private bool ParticipateOutOfEmployment (MonthPeriod period, decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			decimal marginalIncome = PeriodMarginalIncomeEmployment (period);

			if (workTermIncome < marginalIncome) 
			{
				return false;
			}
			return true;
		}
	}
}

