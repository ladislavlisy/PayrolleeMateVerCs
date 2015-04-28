using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Core
{
	public interface IEngines<T>
	{
		void InitEngines();

		void InitWithHistory (SpanOfYears[] setupHistory);

		T FindEngine (MonthPeriod period);
	}
}


