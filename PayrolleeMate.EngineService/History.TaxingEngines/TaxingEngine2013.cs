using System;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2013 : TaxingEnginePrototype
	{
		public TaxingEngine2013 ()
			: base(TaxingGuides.Guides2013())
		{
		}
	}
}

