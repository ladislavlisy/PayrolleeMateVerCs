using System;
using PayrolleeMate.EngineService.Engines.Taxing;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2011 : TaxingEnginePrototype
	{
		public TaxingEngine2011 ()
			: base(TaxingGuides.Guides2011())
		{
		}
	}
}

