using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Period;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IPeriodEngine : IFactualPeriodGuides
	{
		IPeriodGuides Guides ();

		uint DayFromOrdinal (MonthPeriod period, DateTime? dateFrom);

		uint DayEndsOrdinal (MonthPeriod period, DateTime? dateEnds);
	}
}

