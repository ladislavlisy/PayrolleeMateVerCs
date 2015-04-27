using System;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.EngineService
{
	public class EngineProfile : IEngineProfile
	{
		public EngineProfile (ITaxingEngine taxing, IHealthEngine health, ISocialEngine social)
		{
			__taxingEngine = taxing;

			__healthEngine = health;

			__socialEngine = social;
		}

		private ITaxingEngine __taxingEngine;

		private IHealthEngine __healthEngine;

		private ISocialEngine __socialEngine;


		#region IEngineProfile implementation

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

