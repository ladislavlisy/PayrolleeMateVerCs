using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public class EngineProfile : IEngineProfile
	{
		public EngineProfile (MonthPeriod payrunPeriod, IPeriodEngine period, ITaxingEngine taxing, IHealthEngine health, ISocialEngine social)
		{
			__payrunPeriod = payrunPeriod;

			__periodEngine = period;

			__taxingEngine = taxing;

			__healthEngine = health;

			__socialEngine = social;
		}

		private MonthPeriod __payrunPeriod;

		private IPeriodEngine __periodEngine;

		private ITaxingEngine __taxingEngine;

		private IHealthEngine __healthEngine;

		private ISocialEngine __socialEngine;


		#region IEngineProfile implementation

		public MonthPeriod PayrunPeriod ()
		{
			return __payrunPeriod;
		}

		public IPeriodEngine Period ()
		{
			return __periodEngine;
		}

		public ITaxingEngine Taxing ()
		{
			return __taxingEngine;
		}

		public IHealthEngine Health ()
		{
			return __healthEngine;
		}

		public ISocialEngine Social ()
		{
			return __socialEngine;
		}

		#endregion
	}
}

