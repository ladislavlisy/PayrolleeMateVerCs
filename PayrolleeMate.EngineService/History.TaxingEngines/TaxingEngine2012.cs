﻿using System;
using PayrolleeMate.EngineService.Engines.Taxing;

namespace PayrolleeMate.EngineService.History.TaxingEngines
{
	public class TaxingEngine2012 : TaxingEnginePrototype
	{
		public TaxingEngine2012 ()
			: base(TaxingGuides.Guides2012())
		{
		}
	}
}

