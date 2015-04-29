using System;
using PayrolleeMate.Common.Operations;

namespace PayrolleeMate.Common.Rounding
{
	public static class IntRounding
	{
		private static readonly decimal INT_ROUNDING_CONST = 0.5m;

		public static Int32 RoundToInt(decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec) + INT_ROUNDING_CONST);

			return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
		}

		public static Int32 RoundUp(decimal valueDec)
		{
			decimal roundRet = decimal.Ceiling (Math.Abs (valueDec));

			return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
		}

		public static Int32 RoundDown(decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec));

			return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
		}

		public static Int32 NearRoundUp(decimal valueDec, Int32 nearest = 100)
		{
			decimal dividRet = DecOperations.Divide (valueDec, nearest);

			decimal multiRet = DecOperations.Multiply (RoundUp (dividRet), nearest);

			return RoundToInt(multiRet);
		}


		public static Int32 NearRoundDown(decimal valueDec, Int32 nearest = 100)
		{
			decimal dividRet = DecOperations.Divide (valueDec, nearest);

			decimal multiRet = DecOperations.Multiply (RoundDown (dividRet), nearest);

			return RoundToInt(multiRet);
		}
	}
}

