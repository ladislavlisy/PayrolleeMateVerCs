using System;

namespace PayrolleeMate.Common.Operation
{
	public static class DecOperation
	{
		public static decimal Multiply(decimal op1, decimal op2)
		{
			return decimal.Multiply(op1, op2);
		}

		public static decimal Divide(decimal op1, decimal div)
		{
			if (div == 0m)
			{
				return 0m;
			}
			return decimal.Divide(op1, div);
		}

		public static decimal MultiplyAndDivide(decimal op1, decimal op2, decimal div)
		{
			if (div == 0m)
			{
				return 0m;
			}
			decimal multiRet = decimal.Multiply (op1, op2);

			decimal dividRet = decimal.Divide(multiRet, div);

			return dividRet;
		}

		public static decimal DecimalCast(int number)
		{
			return new decimal(number);
		}

		public static decimal MinMaxValue (decimal valueToMinMax, decimal accumulValue, decimal minLimitTo, decimal maxLimitTo)
		{
			decimal minBase = MinValue(valueToMinMax, minLimitTo);

			decimal maxBase = MaxValue(minBase, accumulValue, maxLimitTo);

			return maxBase;
		}

		public static decimal MinValue(decimal valueToMin, decimal limitTo)
		{
			if (limitTo > 0m)
			{
				if (limitTo > valueToMin)
				{
					return limitTo;
				}
			}
			return valueToMin;
		}

		private static decimal MaxValue(decimal valueToMax, decimal valueAccum, decimal limitTo)
		{
			if (limitTo.Equals(0m))
			{
				return valueToMax;
			}
			decimal valueToReduce = Math.Min(decimal.Add(valueToMax, valueAccum), limitTo);

			return Math.Max(0, decimal.Subtract(valueToReduce, valueAccum));
		}
	}
}

