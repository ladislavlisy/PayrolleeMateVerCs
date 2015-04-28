using System;
using PayrolleeMate.EngineService.Engines.Social;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2015 : SocialEnginePrototype
	{
		public SocialEngine2015 ()
			: base(SocialGuides.Guides2015())
		{
		}
	}
}

