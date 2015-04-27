using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Periods;

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
		}

		public IEngineProfile BuildEngineProfile (MonthPeriod period)
		{
			throw new NotImplementedException ();
		}
	}
}

