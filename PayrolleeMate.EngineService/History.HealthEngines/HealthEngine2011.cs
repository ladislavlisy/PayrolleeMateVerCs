using System;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.History.HealthEngines
{
	public class HealthEngine2011 : HealthEnginePrototype
	{
		public HealthEngine2011 ()
			: base(HealthGuides.Guides2011())
		{
		}
	}
}

