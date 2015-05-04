using System;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;

namespace PayrolleeMate.EngineService
{
	public class HealthOperations
	{
		public static decimal DecRoundUp(decimal valueDec)
		{
			return DecRounding.RoundUp(valueDec);
		}

		public static Int32 IntRoundUp(decimal valueDec)
		{
			return IntRounding.RoundUp(valueDec);
		}

		public static decimal DecRoundDown(decimal valueDec)
		{
			return DecRounding.RoundDown(valueDec);
		}

		public static Int32 IntRoundDown(decimal valueDec)
		{
			return IntRounding.RoundDown(valueDec);
		}

		public static decimal MinValueAlign (decimal valueToMin, decimal minLimitTo)
		{
			return DecOperations.MinIncValue(valueToMin, minLimitTo);
		}

		public static decimal MinMaxValue (decimal valueToMinMax, decimal accumulValue, decimal minLimitTo, decimal maxLimitTo)
		{
			return DecOperations.MinIncMaxDecValue(valueToMinMax, accumulValue, minLimitTo, maxLimitTo);
		}

		public static decimal DecSuppressNegative (bool suppress, decimal valueDec)
		{
			if (suppress && valueDec < decimal.Zero) 
			{
				return decimal.Zero;
			}
			return valueDec;
		}
	}
}

