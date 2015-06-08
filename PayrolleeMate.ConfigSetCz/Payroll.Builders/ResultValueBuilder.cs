using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Items;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class ResultValueBuilder
	{
		private const uint NULL_DAY_ORDINAL = 0;

		private static readonly Int32[] NULL_TIME_TABLE = { };

		private const Int32 NULL_TIME_COUNTS = 0;

		private const decimal NULL_AMOUNT = 0m;

		private const decimal NULL_INCOME = 0m;

		public static IResultValues BuildEmptyResult ()
		{
			return new ResultValues (null, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
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
	}
}

