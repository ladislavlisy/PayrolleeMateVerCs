using System;
using PayrolleeMate.EngineService.Engines.Social;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2014 : SocialEnginePrototype
	{
		public SocialEngine2014 ()
			: base(SocialGuides.Guides2014())
		{
		}
	}
}

