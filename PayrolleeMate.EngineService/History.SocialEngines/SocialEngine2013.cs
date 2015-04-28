using System;
using PayrolleeMate.EngineService.Engines.Social;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2013 : SocialEnginePrototype
	{
		public SocialEngine2013 ()
			: base(SocialGuides.Guides2013())
		{
		}
	}
}

