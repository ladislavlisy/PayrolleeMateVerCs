using NUnit.Framework;
using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;

namespace Tests.EngineService
{
	[TestFixture ()]
	public class TestSocialService
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.EngineService.History.SocialEngines";

		private const string CLASS_NAME_PREFIX = "SocialEngine";

		private const string SHORT_CLASS_NAME_2015 = CLASS_NAME_PREFIX + "2015";

		private const string FULL_CLASS_NAME_2015 = NAME_SPACE_PREFIX + "." + CLASS_NAME_PREFIX + "2015";

		private const string FULL_CLASS_NAME_2014 = NAME_SPACE_PREFIX + "." + CLASS_NAME_PREFIX + "2014";

		private const string FULL_CLASS_NAME_2013 = NAME_SPACE_PREFIX + "." + CLASS_NAME_PREFIX + "2013";

		private const string FULL_CLASS_NAME_2012 = NAME_SPACE_PREFIX + "." + CLASS_NAME_PREFIX + "2012";

		private const string FULL_CLASS_NAME_2011 = NAME_SPACE_PREFIX + "." + CLASS_NAME_PREFIX + "2011";

		[Test ()]
		public void Should_return_SocialEngine2015_for_ClassName_when_Year_2015()
		{          
			SpanOfYears span = SpanOfYears.Year(2015);

			string testClassName = EngineFactory<ISocialEngine>.ClassNameFor(CLASS_NAME_PREFIX, span);

			Assert.AreEqual(SHORT_CLASS_NAME_2015, testClassName);
		}

		[Test ()]
		public void Should_return_SocialEngine2015_for_DefaultEngine_when_Year_2015()
		{
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			ISocialEngine engine2015 = engines.DefaultEngine ();

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2015.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_SocialEngine2015_for_ClassNameEngine_when_Year_2015()
		{
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			MonthPeriod period2015 = new MonthPeriod (2015, 1);

			ISocialEngine engine2015 = engines.ResolveEngine (period2015);

			Assert.AreEqual (FULL_CLASS_NAME_2015, engine2015.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_SocialEngine2014_for_ClassNameEngine_when_Year_2014()
		{
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			MonthPeriod period2014 = new MonthPeriod (2014, 1);

			ISocialEngine engine2014 = engines.ResolveEngine (period2014);

			Assert.AreEqual (FULL_CLASS_NAME_2014, engine2014.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_SocialEngine2013_for_ClassNameEngine_when_Year_2013()
		{
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			MonthPeriod period2013 = new MonthPeriod (2013, 1);

			ISocialEngine engine2013 = engines.ResolveEngine (period2013);

			Assert.AreEqual (FULL_CLASS_NAME_2013, engine2013.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_SocialEngine2012_for_ClassNameEngine_when_Year_2012()
		{
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			MonthPeriod period2012 = new MonthPeriod (2012, 1);

			ISocialEngine engine2012 = engines.ResolveEngine (period2012);

			Assert.AreEqual (FULL_CLASS_NAME_2012, engine2012.GetType ().ToString ());
		}

		[Test ()]
		public void Should_return_SocialEngine2011_for_ClassNameEngine_when_Year_2011()
		{
			IEnginesHistory<ISocialEngine> engines = SocialEnginesHistory.CreateEngines ();

			MonthPeriod period2011 = new MonthPeriod (2011, 1);

			ISocialEngine engine2011 = engines.ResolveEngine (period2011);

			Assert.AreEqual (FULL_CLASS_NAME_2011, engine2011.GetType ().ToString ());
		}

	}
}

