using System;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.History.SocialEngines;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public class SocialEnginesHistory : GeneralEnginesHistory<ISocialEngine>
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.History.SocialEngines";

		private const string CLASS_NAME_PREFIX = "SocialEngine";

		private const ushort DEFAULT_YEAR = 2015;

		private readonly ushort[] SPAN_HISTORY = new ushort[] {2011, 2012, 2013, 2014, DEFAULT_YEAR, DEFAULT_YEAR};

		private SocialEnginesHistory ()
		{
		}

		public static IEnginesHistory<ISocialEngine> CreateInstance()
		{
			return new SocialEnginesHistory();
		}

		public static IEnginesHistory<ISocialEngine> CreateEngines()
		{
			IEnginesHistory<ISocialEngine> engine = CreateInstance ();

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

