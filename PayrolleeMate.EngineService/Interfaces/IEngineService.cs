using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IEngineService
	{
		IEngineProfile BuildEngineProfile (MonthPeriod period);
	}

}

