using System;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.EngineService.Engines.Taxing
{
	public class TaxingOperations
	{
		public const int NUMBER_ONE_HUNDRED = 100;

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

		public static decimal DecRoundUpHundreds(decimal valueDec)
		{
			return DecRounding.NearRoundUp(valueDec, NUMBER_ONE_HUNDRED);
		}

		public static decimal DecFactorResult(decimal valueDec, decimal factor)
		{
			return DecOperation.Multiply(valueDec, factor);
		}
	}
}

