using System;
using PayrolleeMate.EngineService.Engines.Taxing;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2014 : TaxingEnginePrototype
	{
		public TaxingEngine2014 ()
			: base(TaxingGuides.Guides2014())
		{
		}
	}
}

