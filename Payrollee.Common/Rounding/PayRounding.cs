using System;
using PayrolleeMate.Common.Operations;

namespace PayrolleeMate.Common.Rounding
{
	public class PayRounding
	{
		public static decimal MonthlyAmountWithWorkingHours(decimal amountMonthly, decimal scheduleFactor, int timesheetHours, int workingHours, int absenceHours)
		{
			decimal amountFactor = FactorizeAmount(amountMonthly, scheduleFactor);

			decimal paymentValue = PaymentFromAmount(amountFactor, timesheetHours, workingHours, absenceHours);
			return paymentValue;
		}

		public static decimal FactorizeAmount(decimal amount, decimal factor)
		{
			decimal result = DecOperations.Multiply (amount, factor);

			return result;
		}

		public static decimal PaymentFromAmount(decimal amountMonthly, int timesheetHours, int workingHours, int absenceHours)
		{
			int totalHours = Math.Max(0, workingHours - absenceHours);

			decimal payment = DecOperations.MultiplyAndDivide(totalHours, amountMonthly, timesheetHours);

			return payment;
		}

	}
}

