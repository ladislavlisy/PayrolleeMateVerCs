using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Core
{
	public interface IEnginesHistory<T>
	{
		void InitEngines();

		void InitWithHistory (SpanOfYears[] setupHistory);

		T ResolveEngine (MonthPeriod period);

		T DefaultEngine ();
	}
}


