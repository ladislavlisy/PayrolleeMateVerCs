using System;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;

namespace PayrolleeMate.EngineService.Engines.Taxing
{
	public class TaxingOperations
	{
		public const Int32 NUMBER_ONE_HUNDRED = 100;

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

		public static decimal DecRoundUpHundreds(decimal valueDec)
		{
			return DecRounding.NearRoundUp(valueDec, NUMBER_ONE_HUNDRED);
		}

		public static decimal DecFactorResult(decimal valueDec, decimal factor)
		{
			return DecOperations.Multiply(valueDec, factor);
		}

		public static Int32 RebateResult(decimal rebateBasis, decimal rebateApply, decimal rebateClaim)
		{
			decimal afterApply = decimal.Subtract(rebateBasis, rebateApply);

			decimal afterClaim = Math.Max(0m, decimal.Subtract(rebateClaim, afterApply));

			decimal rebateResult = decimal.Subtract(rebateClaim, afterClaim);

			return IntRounding.RoundToInt (rebateResult);
		}

		public static decimal LimitToMinMax (decimal valueToMinMax, decimal minLimitTo, decimal maxLimitTo)
		{
			if (minLimitTo > valueToMinMax) 
			{
				return 0m;
			}
			return DecOperations.MaxDecValue (valueToMinMax, maxLimitTo);
		}
	}
}

