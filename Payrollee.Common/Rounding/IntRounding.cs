using System;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.Common.Rounding
{
	public static class IntRounding
	{
		private static readonly decimal INT_ROUNDING_CONST = 0.5m;

		public static long RoundToInt(decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec) + INT_ROUNDING_CONST);

			return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
		}

		public static long RoundUp(decimal valueDec)
		{
			decimal roundRet = decimal.Ceiling (Math.Abs (valueDec));

			return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
		}

		public static long RoundDown(decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec));

			return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
		}

		public static long NearRoundUp(decimal valueDec, int nearest = 100)
		{
			decimal dividRet = DecOperation.Divide (valueDec, nearest);

			decimal multiRet = DecOperation.Multiply (RoundUp (dividRet), nearest);

			return RoundToInt(multiRet);
		}


		public static long NearRoundDown(decimal valueDec, int nearest = 100)
		{
			decimal dividRet = DecOperation.Divide (valueDec, nearest);

			decimal multiRet = DecOperation.Multiply (RoundDown (dividRet), nearest);

			return RoundToInt(multiRet);
		}
	}
}

