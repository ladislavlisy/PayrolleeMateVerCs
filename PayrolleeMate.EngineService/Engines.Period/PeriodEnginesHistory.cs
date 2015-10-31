using System;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.EngineService.Engines.Period
{
	public class PeriodEnginesHistory : GeneralEnginesHistory<IPeriodEngine>
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.History.PeriodEngines";

		private const string CLASS_NAME_PREFIX = "PeriodEngine";

		private const ushort DEFAULT_YEAR = 2015;

		private readonly ushort[] SPAN_HISTORY = new ushort[] {DEFAULT_YEAR, DEFAULT_YEAR};

		private PeriodEnginesHistory ()
		{
		}

		public static IEnginesHistory<IPeriodEngine> CreateInstance()
		{
			return new PeriodEnginesHistory();
		}

		public static IEnginesHistory<IPeriodEngine> CreateEngines()
		{
			IEnginesHistory<IPeriodEngine> engine = CreateInstance ();

			engine.InitEngines ();

			return engine;
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
