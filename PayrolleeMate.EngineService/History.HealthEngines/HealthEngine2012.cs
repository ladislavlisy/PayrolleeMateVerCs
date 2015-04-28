using System;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2012 : HealthEnginePrototype
	{
		public HealthEngine2012 ()
			: base(HealthGuides.Guides2012())
		{
		}
	}
}

