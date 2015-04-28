using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Core
{
	public interface IEnginesHistory<T>
	{
		void InitEngines();

		void InitWithHistory (SpanOfYears[] setupHistory);

		T FindEngine (MonthPeriod period);

		T DefaultEngine ();
	}
}


