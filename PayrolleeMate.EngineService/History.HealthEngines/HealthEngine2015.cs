using System;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2015 : HealthEnginePrototype
	{
		public HealthEngine2015 ()
			: base(HealthGuides.Guides2015())
		{
		}
	}
}

