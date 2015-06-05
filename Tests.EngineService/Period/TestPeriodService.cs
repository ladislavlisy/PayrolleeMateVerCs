using NUnit.Framework;
using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Period;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestPeriodService
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.History.PeriodEngines";

		private const string CLASS_NAME_PREFIX = "PeriodEngine";

		private const string SHORT_CLASS_NAME_2015 = CLASS_NAME_PREFIX + "2015";

		private const string FULL_CLASS_NAME_2015 = NAME_SPACE_PREFIX + "." + CLASS_NAME_PREFIX + "2015";

		[Test ()]
		public void Should_return_PeriodEngine2015_for_ClassName_when_Year_2015()
		{          
			SpanOfYears span = SpanOfYears.Year(2015);

			string testClassName = EngineFactory<IPeriodEngine>.ClassNameFor(CLASS_NAME_PREFIX, span);

			Assert.AreEqual(SHORT_CLASS_NAME_2015, testClassName);
		}

		[Test ()]
		public void Should_return_PeriodEngine2015_for_DefaultEngine_when_Year_2015()
		{
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			IPeriodEngine engine2015 = engines.DefaultEngine ();

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2015.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_PeriodEngine2015_for_ClassNameEngine_when_Year_2015()
		{
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			MonthPeriod period2015 = new MonthPeriod (2015, 1);

			IPeriodEngine engine2015 = engines.ResolveEngine (period2015);

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2015.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_PeriodEngine2015_for_ClassNameEngine_when_Year_2014()
		{
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			MonthPeriod period2014 = new MonthPeriod (2014, 1);

			IPeriodEngine engine2014 = engines.ResolveEngine (period2014);

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2014.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_PeriodEngine2015_for_ClassNameEngine_when_Year_2013()
		{
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			MonthPeriod period2013 = new MonthPeriod (2013, 1);

			IPeriodEngine engine2013 = engines.ResolveEngine (period2013);

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2013.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_PeriodEngine2015_for_ClassNameEngine_when_Year_2012()
		{
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			MonthPeriod period2012 = new MonthPeriod (2012, 1);

			IPeriodEngine engine2012 = engines.ResolveEngine (period2012);

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2012.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_PeriodEngine2015_for_ClassNameEngine_when_Year_2011()
		{
			IEnginesHistory<IPeriodEngine> engines = PeriodEnginesHistory.CreateEngines ();

			MonthPeriod period2011 = new MonthPeriod (2011, 1);

			IPeriodEngine engine2011 = engines.ResolveEngine (period2011);

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2011.GetType ().ToString ());
		}

	}
}

