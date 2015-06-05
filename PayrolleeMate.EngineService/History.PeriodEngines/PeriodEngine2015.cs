using System;
using PayrolleeMate.EngineService.Engines.Period;

namespace PayrolleeMate.EngineService.History.PeriodEngines
{
	public class PeriodEngine2015 : PeriodEnginePrototype
	{
		public PeriodEngine2015 ()
			: base(PeriodGuides.Guides2015())
		{
		}

		#region implemented abstract members of SocialEnginePrototype

		#endregion
	}
}

