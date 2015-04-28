using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.Common.Periods;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestTaxingService
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.History.TaxingEngines";

		private const string CLASS_NAME_PREFIX = "TaxingEngine";

		private const string SHORT_CLASS_NAME_2015 = "TaxingEngine2015";

		private const string FULL_CLASS_NAME_2015 = "PayrolleeMate.EngineService.History.TaxingEngines.TaxingEngine2015";

		private const string FULL_CLASS_NAME_2014 = "PayrolleeMate.EngineService.History.TaxingEngines.TaxingEngine2014";

		private const string FULL_CLASS_NAME_2013 = "PayrolleeMate.EngineService.History.TaxingEngines.TaxingEngine2013";

		private const string FULL_CLASS_NAME_2012 = "PayrolleeMate.EngineService.History.TaxingEngines.TaxingEngine2012";

		private const string FULL_CLASS_NAME_2011 = "PayrolleeMate.EngineService.History.TaxingEngines.TaxingEngine2011";

		private IEnginesHistory<ITaxingEngine> CreateEngine()
		{
			IEnginesHistory<ITaxingEngine> engine = TaxingEnginesHistory.CreateEngines ();

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
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			ITaxingEngine engine2015 = engines.DefaultEngine ();

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2015.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_TaxingEngine2015_for_ClassNameEngine_when_Year_2015()
		{
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			MonthPeriod period2015 = new MonthPeriod (2015, 1);

			ITaxingEngine engine2015 = engines.FindEngine (period2015);

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2015.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_TaxingEngine2014_for_ClassNameEngine_when_Year_2014()
		{
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			MonthPeriod period2014 = new MonthPeriod (2014, 1);

			ITaxingEngine engine2014 = engines.FindEngine (period2014);

			Assert.AreEqual (FULL_CLASS_NAME_2014, engine2014.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_TaxingEngine2013_for_ClassNameEngine_when_Year_2013()
		{
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			MonthPeriod period2013 = new MonthPeriod (2013, 1);

			ITaxingEngine engine2013 = engines.FindEngine (period2013);

			Assert.AreEqual (FULL_CLASS_NAME_2013, engine2013.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_TaxingEngine2012_for_ClassNameEngine_when_Year_2012()
		{
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			MonthPeriod period2012 = new MonthPeriod (2012, 1);

			ITaxingEngine engine2012 = engines.FindEngine (period2012);

			Assert.AreEqual (FULL_CLASS_NAME_2012, engine2012.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_TaxingEngine2011_for_ClassNameEngine_when_Year_2011()
		{
			IEnginesHistory<ITaxingEngine> engines = CreateEngine ();

			MonthPeriod period2011 = new MonthPeriod (2011, 1);

			ITaxingEngine engine2011 = engines.FindEngine (period2011);

			Assert.AreEqual (FULL_CLASS_NAME_2011, engine2011.GetType ().ToString ());
		}

	}
}

