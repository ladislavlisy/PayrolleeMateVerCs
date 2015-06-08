using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Items;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class TargetValueBuilder
	{
		private static readonly DateTime? NULL_DATE_FROM = null;
		private static readonly DateTime? NULL_DATE_ENDS = null;
		private const Int32 NULL_TIME_WEEKLY = 0;
		private const Int32 NULL_TIME_WORKED = 0;
		private const Int32 NULL_TIME_ABSENT = 0;
		private const decimal NULL_AMOUNT_MONTHLY = 0m;
		private const uint NULL_CODE_INTERESTS = 0;
		private const uint NULL_CODE_RESIDENCY = 0;
		private const uint NULL_CODE_MANDATORY = 0;
		private const uint NULL_CODE_STATEMENT = 0;
		private const uint NULL_CODE_HANDICAPS = 0;
		private const uint NULL_CODE_CARDINALS = 0;

		public static ITargetValues CreateContractEmplTermValues(DateTime? dateFrom, DateTime? dateEnds)
		{
			return new TargetValues (dateFrom, dateEnds, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreatePositionEmplTermValues(DateTime? dateFrom, DateTime? dateEnds) 
		{
			return new TargetValues (dateFrom, dateEnds, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateScheduleWorkValues(Int32 timeWeekly) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, timeWeekly, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTimehoursWorkingValues(Int32 timeWorked) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, timeWorked, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTimehoursAbsenceValues(Int32 timeMissed) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, timeMissed, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateSalaryBaseValues(decimal amountMonthly) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				amountMonthly,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateHealthIncomeSubjectValues(uint codeInterests, uint codeResidency, uint codeMandatory) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, codeResidency, codeMandatory, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateSocialIncomeSubjectValues(uint codeInterests, uint codeResidency) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, codeResidency, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateGarantIncomeSubjectValues(uint codeInterests) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingIncomeSubjectValues(uint codeInterests, uint codeResidency, uint codeStatement) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, codeResidency, NULL_CODE_MANDATORY, codeStatement, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingAllowancePayerValues(uint codeInterests) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingAllowanceChildValues(uint codeInterests, uint codeHandicaps, uint codeCardinals) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTaxingAllowanceDisabilityValues(uint codeInterests, uint codeHandicaps) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, codeHandicaps, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingAllowanceStudyingValues(uint codeInterests) 
		{
			return new TargetValues (NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}
	}
}

