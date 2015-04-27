using System;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.Common.Rounding
{
	public static class DecRounding
	{
		public static decimal RoundUp(decimal valueDec)
		{
			return (valueDec < 0m ? decimal.Negate(decimal.Ceiling(Math.Abs(valueDec))) : decimal.Ceiling(Math.Abs(valueDec)));
		}

		public static decimal RoundDown(decimal valueDec)
		{
			return (valueDec < 0m ? decimal.Negate(decimal.Floor(Math.Abs(valueDec))) : decimal.Floor(Math.Abs(valueDec)));
		}

		public static decimal NearRoundUp(decimal valueDec, int nearest = 100)
		{
			decimal dividRet = DecOperation.Divide (valueDec, nearest);

			decimal multiRet = DecOperation.Multiply (RoundUp (dividRet), nearest);

			return multiRet;
		}


		public static decimal NearRoundDown(decimal valueDec, int nearest = 100)
		{
			decimal dividRet = DecOperation.Divide (valueDec, nearest);

			decimal multiRet = DecOperation.Multiply (RoundDown (dividRet), nearest);

			return multiRet;
		}
	}
}

