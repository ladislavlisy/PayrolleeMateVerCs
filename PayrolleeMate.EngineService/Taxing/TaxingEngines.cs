using System;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Periods.TaxingEngines;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Taxing
{
	public class TaxingEngines : GeneralEngines<ITaxingEngine>
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.Periods.TaxingEngines";

		private const string CLASS_NAME_PREFIX = "TaxingEngine";

		private const ushort DEFAULT_YEAR = 2015;

		private readonly ushort[] SPAN_HISTORY = new ushort[] {DEFAULT_YEAR};

		private TaxingEngines ()
		{
		}

		public static IEngines<ITaxingEngine> CreateEngines()
		{
			return new TaxingEngines();
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

