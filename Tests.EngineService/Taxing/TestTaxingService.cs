using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Taxing;
using PayrolleeMate.Common.Periods;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestTaxingService
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.Periods.TaxingEngines";

		private const string CLASS_NAME_PREFIX = "TaxingEngine";

		private const string SHORT_CLASS_NAME_2015 = "TaxingEngine2015";

		private const string FULL_CLASS_NAME_2015 = "PayrolleeMate.EngineService.Periods.TaxingEngines.TaxingEngine2015";

		private IEngines<ITaxingEngine> CreateEngine()
		{
			IEngines<ITaxingEngine> engine = TaxingEngines.CreateEngines ();

			engine.InitEngines ();

			return engine;
		}

		[Test ()]
		public void Should_return_TaxingEngine2015_for_ClassName_when_Year_2015()
		{          
			SpanOfYears span = SpanOfYears.Year(2015);

			string testClassName = EngineFactory<ITaxingEngine>.ClassNameFor(CLASS_NAME_PREFIX, span);

			Assert.AreEqual(SHORT_CLASS_NAME_2015, testClassName);
		}

		[Test ()]
		public void Should_return_TaxingEngine2015_for_DefaultEngine_when_Year_2015()
		{
			IEngines<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine2015 = engines.DefaultEngine ();

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2015.GetType ().ToString ());
		}

	}
}

