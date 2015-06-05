using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.EngineService.Engines.Period;

namespace PayrolleeMate.EngineService
{
	public class EngineServiceModule : IEngineService
	{
		public static IEngineService CreateModule()
		{
			IEngineService module = new EngineServiceModule ();

			return module;
		}

		private EngineServiceModule ()
		{
			HistoryOfPeriod = PeriodEnginesHistory.CreateEngines ();

			HistoryOfTaxing = TaxingEnginesHistory.CreateEngines ();

			HistoryOfHealth = HealthEnginesHistory.CreateEngines ();

			HistoryOfSocial = SocialEnginesHistory.CreateEngines ();
		}

		public IEngineProfile BuildEngineProfile (MonthPeriod period)
		{
			IPeriodEngine periodEngine = HistoryOfPeriod.ResolveEngine (period);
			ITaxingEngine taxingEngine = HistoryOfTaxing.ResolveEngine (period);
			IHealthEngine healthEngine = HistoryOfHealth.ResolveEngine (period);
			ISocialEngine socialEngine = HistoryOfSocial.ResolveEngine (period);

			return new EngineProfile(periodEngine, taxingEngine, healthEngine, socialEngine);
		}

		private IEnginesHistory<IPeriodEngine> HistoryOfPeriod { get; set; }

		private IEnginesHistory<ITaxingEngine> HistoryOfTaxing { get; set; }

		private IEnginesHistory<IHealthEngine> HistoryOfHealth { get; set; }

		private IEnginesHistory<ISocialEngine> HistoryOfSocial { get; set; }

	}
}

