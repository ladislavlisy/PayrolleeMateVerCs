using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService
{
	public class EngineGeneralGuides
	{
		public EngineGeneralGuides (uint year)
		{
			ValidFrom = new MonthPeriod (year, 1);
			ValidUpto = new MonthPeriod (year, 12);
		}

		public MonthPeriod ValidFrom { get; private set; }

		public MonthPeriod ValidUpto { get; private set; }

		public bool ValidatePeriod(MonthPeriod period)
		{
			return (period >= ValidFrom && period <= ValidUpto);
		}
	}
}

