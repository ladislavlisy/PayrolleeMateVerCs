using System;
using PayrolleeMate.EngineService.Engines.Social;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2011 : SocialEnginePrototype
	{
		public SocialEngine2011 ()
			: base(SocialGuides.Guides2011())
		{
		}
	}
}

