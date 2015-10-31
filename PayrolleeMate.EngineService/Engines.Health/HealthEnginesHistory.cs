using System;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.History.HealthEngines;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public class HealthEnginesHistory : GeneralEnginesHistory<IHealthEngine>
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.History.HealthEngines";

		private const string CLASS_NAME_PREFIX = "HealthEngine";

		private const ushort DEFAULT_YEAR = 2015;

		private readonly ushort[] SPAN_HISTORY = new ushort[] {2011, 2012, 2013, 2014, DEFAULT_YEAR, DEFAULT_YEAR};

		private HealthEnginesHistory ()
		{
		}

		public static IEnginesHistory<IHealthEngine> CreateInstance()
		{
			return new HealthEnginesHistory();
		}

		public static IEnginesHistory<IHealthEngine> CreateEngines()
		{
			IEnginesHistory<IHealthEngine> engine = CreateInstance ();

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

