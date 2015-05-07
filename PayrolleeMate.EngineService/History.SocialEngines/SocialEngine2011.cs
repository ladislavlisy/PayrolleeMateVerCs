using System;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2011 : SocialEnginePrototype
	{
		public SocialEngine2011 ()
			: base(SocialGuides.Guides2011())
		{
		}

		#region implemented abstract members of SocialEnginePrototype

		public override bool ParticipateSocialIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkSocialTerms socialTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalInsIncome)
		{
			return false;
		}

		#endregion
	}
}

