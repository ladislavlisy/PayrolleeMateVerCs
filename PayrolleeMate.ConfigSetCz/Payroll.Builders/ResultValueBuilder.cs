using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Items;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class ResultValueBuilder
	{
		private const uint NULL_DAY_ORDINAL = ResultValues.NULL_DAY_ORDINAL;

		private static readonly Int32[] NULL_TIME_TABLE = ResultValues.NULL_TIME_TABLE;

		private const Int32 NULL_TIME_COUNTS = ResultValues.NULL_TIME_COUNTS;

		private const decimal NULL_AMOUNT = ResultValues.NULL_AMOUNT;

		private const decimal NULL_INCOME = ResultValues.NULL_INCOME;

		public static IResultValues BuildEmptyResult ()
		{
			return ResultValues.GetEmpty();
		}

		public static IResultValues BuildTargetResult (ITargetValues targetValues)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildContractEmplTermResult (ITargetValues targetValues, uint dayFromOrdinal, uint dayEndsOrdinal)
		{
			return new ResultValues (targetValues, dayFromOrdinal, dayEndsOrdinal, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildPositionEmplTermResult (ITargetValues targetValues, uint dayFromOrdinal, uint dayEndsOrdinal)
		{
			return new ResultValues (targetValues, dayFromOrdinal, dayEndsOrdinal, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildScheduleWorkResult (ITargetValues targetValues, Int32[] timeTable)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				timeTable, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildTimesheetScheduleResult (ITargetValues targetValues, Int32[] timeTable)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				timeTable, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildWorkTimetableResult (ITargetValues targetValues, Int32[] timeTable)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, timeTable, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildOverTimetableResult (ITargetValues targetValues, Int32[] timeTable)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, timeTable, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildAbsenceTimetableResult (ITargetValues targetValues, Int32[] timeTable)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, timeTable,  
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildWorktimeCountResult (ITargetValues targetValues, Int32 timeValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				timeValue, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildOvertimeCountResult (ITargetValues targetValues, Int32 timeValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, timeValue, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildAbsenceCountResult (ITargetValues targetValues, Int32 timeValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, timeValue, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}


		public static IResultValues BuildRecordTimeResult (ITargetValues targetValues, Int32 timeValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				timeValue, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildRecordAmountResult (ITargetValues targetValues, decimal amountValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, amountValue, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildRecordIncomeResult (ITargetValues targetValues, decimal incomeValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, incomeValue, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}


		public static IResultValues BuildAmountIncomeResult (ITargetValues targetValues, decimal amountValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, amountValue, NULL_AMOUNT, NULL_AMOUNT);
		}

		public static IResultValues BuildAmountPaymentsResult (ITargetValues targetValues, decimal amountValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, amountValue, NULL_AMOUNT);
		}

		public static IResultValues BuildMonthlyAmountPaymentsResult (ITargetValues targetValues, decimal factorValue, decimal amountValue, Int32 recordHours)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				recordHours, factorValue, NULL_INCOME, NULL_INCOME, amountValue, NULL_AMOUNT);
		}

		public static IResultValues BuildAmountDeductedResult (ITargetValues targetValues, decimal amountValue)
		{
			return new ResultValues (targetValues, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, amountValue);
		}

	}
}

