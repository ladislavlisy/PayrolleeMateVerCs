using System;

namespace PayrolleeMate.Common.Operations
{
	public static class DecOperations
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

		public static decimal DecimalCast(Int32 number)
		{
			return new decimal(number);
		}

		public static decimal MinIncMaxDecValue (decimal valueToMinMax, decimal accumulValue, decimal minLimitTo, decimal maxLimitTo)
		{
			decimal minBase = MinIncValue(valueToMinMax, minLimitTo);

			decimal maxBase = MaxDecAccumValue(minBase, accumulValue, maxLimitTo);

			return maxBase;
		}

		public static decimal MinIncValue(decimal valueToMin, decimal minLimitTo)
		{
			if (minLimitTo > 0m)
			{
				if (minLimitTo > valueToMin)
				{
					return minLimitTo;
				}
			}
			return valueToMin;
		}

		private static decimal MaxDecAccumValue(decimal valueToMax, decimal valueAccum, decimal maxLimitTo)
		{
			if (maxLimitTo > 0m)
			{
				decimal valueToReduce = Math.Min(decimal.Add(valueToMax, valueAccum), maxLimitTo);

				return Math.Max(0, decimal.Subtract(valueToReduce, valueAccum));
			}
			return valueToMax;
		}

		public static decimal MaxDecValue (decimal valueToMax, decimal maxLimitTo)
		{
			if (maxLimitTo > 0m)
			{
				return Math.Min(valueToMax, maxLimitTo);
			}
			return valueToMax;
		}
	}
}

