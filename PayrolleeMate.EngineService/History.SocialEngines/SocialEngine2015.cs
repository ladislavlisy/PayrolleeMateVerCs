using System;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;
using PayrolleeMate.EngineService.Exceptions;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2015 : SocialEnginePrototype
	{
		public SocialEngine2015 ()
			: base(SocialGuides.Guides2015())
		{
		}

		#region implemented abstract members of SocialEnginePrototype

		public override bool ParticipateSocialIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkSocialTerms socialTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			bool workTermAgreementTasks = (workTerm == WorkRelationTerms.WORKTERM_CONTRACTER_T);

			if (workTermAgreementTasks) 
			{
				return ParticipateAgreementTasks (period, contractIncome, workTermIncome, totalInsIncome);
			}
			else 
			{
				switch (socialTerm) {
				case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT:
					return ParticipateEmployment (period, contractIncome, workTermIncome, totalInsIncome);

				case WorkSocialTerms.SOCIAL_TERM_SMALL_EMPL:
					return ParticipateSmallRange (period, contractIncome, workTermIncome, totalInsIncome);

				case WorkSocialTerms.SOCIAL_TERM_SHORT_MEET:
					return ParticipateShortWorkMeet (period, contractIncome, workTermIncome, totalInsIncome);

				case WorkSocialTerms.SOCIAL_TERM_SHORT_DENY:
					return ParticipateShortWorkDeny (period, contractIncome, workTermIncome, totalInsIncome);

				default:
					return true;
				}
			}
		}

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

		private bool ParticipateSmallRange (MonthPeriod period, decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			decimal marginalIncome = PeriodMarginalIncomeEmployment (period);

			if (workTermIncome < marginalIncome) 
			{
				return false;
			}
			return true;
		}

		private bool ParticipateShortWorkMeet (MonthPeriod period, decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			throw new EngineServicePeriodException ("short-term work is not applicable after january 2015", period);
		}

		private bool ParticipateShortWorkDeny (MonthPeriod period, decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			throw new EngineServicePeriodException ("short-term work is not applicable after january 2015", period);
		}
		#endregion
	}
}

