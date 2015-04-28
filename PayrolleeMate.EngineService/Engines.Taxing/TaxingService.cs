using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Taxing
{
	public class TaxingService : ITaxingService
	{
		private readonly string CLASS_NAME_PREFIX = "PayrolleeMate.EngineService.Periods.TaxingEngines";

		public static ITaxingService CreateService()
		{
			return new TaxingService();
		}

		private TaxingService()
		{
			this.defaultProfile = new TaxingEngine2015();
		}

		private readonly ITaxingEngine defaultProfile = null;

		#region ITaxingService implementation

		public ITaxingService FindService (MonthPeriod period)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

