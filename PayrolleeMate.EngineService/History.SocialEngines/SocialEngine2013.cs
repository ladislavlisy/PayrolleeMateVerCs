using System;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2013 : SocialEnginePrototype
	{
		public SocialEngine2013 ()
			: base(SocialGuides.Guides2013())
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

