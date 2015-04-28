using System;

namespace PayrolleeMate.EngineService.Periods.TaxingEngines
{
	public class TaxingEngine2015 : TaxingEnginePrototype
	{
		public TaxingEngine2015 ()
			: base(TaxingGuides.Guides2015())
		{
		}
	}
}

