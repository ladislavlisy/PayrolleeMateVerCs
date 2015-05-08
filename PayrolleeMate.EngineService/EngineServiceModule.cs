using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Engines.Taxing;
using PayrolleeMate.EngineService.Engines.Health;
using PayrolleeMate.EngineService.Engines.Social;

namespace PayrolleeMate.EngineService
{
	public class EngineServiceModule : IEngineService
	{
		public static IEngineService CreateEngine()
		{
			return new EngineServiceModule ();
		}

		private EngineServiceModule ()
		{
			HistoryOfTaxing = TaxingEnginesHistory.CreateEngines ();

			HistoryOfHealth = HealthEnginesHistory.CreateEngines ();

			HistoryOfSocial = SocialEnginesHistory.CreateEngines ();
		}

		public IEngineProfile BuildEngineProfile (MonthPeriod period)
		{
			ITaxingEngine taxingEngine = HistoryOfTaxing.ResolveEngine (period);
			IHealthEngine healthEngine = HistoryOfHealth.ResolveEngine (period);
			ISocialEngine socialEngine = HistoryOfSocial.ResolveEngine (period);

			return new EngineProfile(taxingEngine, healthEngine, socialEngine);
		}

		private IEnginesHistory<ITaxingEngine> HistoryOfTaxing { get; set; }

		private IEnginesHistory<IHealthEngine> HistoryOfHealth { get; set; }

		private IEnginesHistory<ISocialEngine> HistoryOfSocial { get; set; }

	}
}

