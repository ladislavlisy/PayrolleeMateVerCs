﻿using System;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.History.TaxingEngines;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Taxing
{
	public class TaxingEnginesHistory : GeneralEnginesHistory<ITaxingEngine>
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.History.TaxingEngines";

		private const string CLASS_NAME_PREFIX = "TaxingEngine";

		private const ushort DEFAULT_YEAR = 2015;

		private readonly ushort[] SPAN_HISTORY = new ushort[] {2011, 2012, 2013, 2014, DEFAULT_YEAR};

		private TaxingEnginesHistory ()
		{
		}

		public static IEnginesHistory<ITaxingEngine> CreateEngines()
		{
			return new TaxingEnginesHistory();
		}

		#region implemented abstract members of GeneralEngines

		protected override ushort DefaultYear ()
		{
			return DEFAULT_YEAR;
		}

		protected override ushort[] History ()
		{
			return SPAN_HISTORY;
		}

		protected override string NamespacePrefix ()
		{
			return NAME_SPACE_PREFIX;
		}

		protected override string ClassnamePrefix ()
		{
			return CLASS_NAME_PREFIX;
		}

		#endregion
	}
}

