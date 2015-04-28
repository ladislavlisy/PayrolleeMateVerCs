using System;
using PayrolleeMate.EngineService.Engines.Social;

namespace PayrolleeMate.EngineService.History.SocialEngines
{
	public class SocialEngine2012 : SocialEnginePrototype
	{
		public SocialEngine2012 ()
			: base(SocialGuides.Guides2012())
		{
		}
	}
}

