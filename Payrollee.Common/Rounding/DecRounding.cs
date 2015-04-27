using System;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.Common.Rounding
{
	public static class DecRounding
	{
		public static decimal RoundUp(decimal valueDec)
		{
			decimal roundRet = decimal.Ceiling (Math.Abs (valueDec));

			return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
		}

		public static decimal RoundDown(decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec));

			return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
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

