using System;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.EngineService
{
	public class HealthOperations
	{
		public static decimal DecRoundUp(decimal valueDec)
		{
			return DecRounding.RoundUp(valueDec);
		}

		public static long IntRoundUp(decimal valueDec)
		{
			return IntRounding.RoundUp(valueDec);
		}

		public static decimal DecRoundDown(decimal valueDec)
		{
			return DecRounding.RoundDown(valueDec);
		}

		public static long IntRoundDown(decimal valueDec)
		{
			return IntRounding.RoundDown(valueDec);
		}

		public static decimal MinMaxValue (decimal valueToMinMax, decimal accumulValue, decimal minLimitTo, decimal maxLimitTo)
		{
			return DecOperation.MinMaxValue(valueToMinMax, accumulValue, minLimitTo, maxLimitTo);
		}
	}
}

