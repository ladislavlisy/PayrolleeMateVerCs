using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Taxing
{
	public interface ITaxingService
	{
		ITaxingService FindService(MonthPeriod period);
	}

}

