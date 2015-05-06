using System;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.Engine.Exceptions
{
	public class EngineServicePeriodException : Exception
	{
		public EngineServicePeriodException(string message, MonthPeriod period) : base(message)
		{
			this.Period = period;
		}

		public MonthPeriod Period { get; private set; }
	}

}

