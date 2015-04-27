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

	}
}

