using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService.Core;
using PayrolleeMate.EngineService.Taxing;

namespace PayrolleeMate.EngineService
{
	public class EngineService : IEngineService
	{
		public static IEngineService CreateEngine()
		{
			return new EngineService ();
		}

		private EngineService ()
		{
			HistoryOfTaxing = TaxingEnginesHistory.CreateEngines ();

			HistoryOfHealth = null;

			HistoryOfSocial = null;
		}

		public IEngineProfile BuildEngineProfile (MonthPeriod period)
		{
			ITaxingEngine taxingEngine = HistoryOfTaxing.FindEngine (period);
			IHealthEngine healthEngine = null;
			ISocialEngine socialEngine = null;

			return new EngineProfile(taxingEngine, healthEngine, socialEngine);
		}

		private IEnginesHistory<ITaxingEngine> HistoryOfTaxing { get; set; }

		private IEnginesHistory<IHealthEngine> HistoryOfHealth { get; set; }

		private IEnginesHistory<ISocialEngine> HistoryOfSocial { get; set; }

	}
}

