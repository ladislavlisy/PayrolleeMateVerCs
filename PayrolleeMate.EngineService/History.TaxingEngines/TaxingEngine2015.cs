using System;
using PayrolleeMate.EngineService.Engines.Taxing;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2015 : TaxingEnginePrototype
	{
		public TaxingEngine2015 ()
			: base(TaxingGuides.Guides2015())
		{
		}
	}
}

