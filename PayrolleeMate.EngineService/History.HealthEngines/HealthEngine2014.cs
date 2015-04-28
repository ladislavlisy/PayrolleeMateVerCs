using System;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2014 : HealthEnginePrototype
	{
		public HealthEngine2014 ()
			: base(HealthGuides.Guides2014())
		{
		}
	}
}

