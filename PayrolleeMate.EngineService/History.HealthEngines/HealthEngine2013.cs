using System;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2013 : HealthEnginePrototype
	{
		public HealthEngine2013 ()
			: base(HealthGuides.Guides2013())
		{
		}
	}
}

