using System;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2014 : SocialEnginePrototype
	{
		public SocialEngine2014 ()
			: base(SocialGuides.Guides2014())
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

