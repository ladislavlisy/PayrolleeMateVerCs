using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Items;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class TargetValueBuilder
	{
		private const WorkRelationTerms DEFAULT_CONTRACT_TYPE = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

		private const WorkHealthTerms DEFAULT_HEALTH_TYPE = WorkHealthTerms.HEALTH_TERM_EMPLOYMENT;

		private const WorkSocialTerms  DEFAULT_SOCIAL_TYPE = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;

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

		public static ITargetValues CreateContractEmplTermValues(WorkRelationTerms contract, 
			WorkHealthTerms healthType, WorkSocialTerms socialType,
			DateTime? dateFrom, DateTime? dateEnds)
		{
			return new TargetValues (contract, healthType, socialType,
				dateFrom, dateEnds, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreatePositionEmplTermValues(DateTime? dateFrom, DateTime? dateEnds) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				dateFrom, dateEnds, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateScheduleWorkValues(Int32 timeWeekly) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, timeWeekly, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTimehoursWorkingValues(Int32 timeWorked) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, timeWorked, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTimehoursAbsenceValues(Int32 timeAbsent) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, timeAbsent, 
				NULL_AMOUNT_MONTHLY,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateSalaryBaseValues(decimal amountMonthly) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				amountMonthly,
				NULL_CODE_INTERESTS, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateHealthIncomeSubjectValues(uint codeInterests, uint codeResidency, uint codeMandatory) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, codeResidency, codeMandatory, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateSocialIncomeSubjectValues(uint codeInterests, uint codeResidency) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, codeResidency, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateGarantIncomeSubjectValues(uint codeInterests) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingIncomeSubjectValues(uint codeInterests, uint codeResidency, uint codeStatement) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, codeResidency, NULL_CODE_MANDATORY, codeStatement, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingAllowancePayerValues(uint codeInterests) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingAllowanceChildValues(uint codeInterests, uint codeHandicaps, uint codeCardinals) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTaxingAllowanceDisabilityValues(uint codeInterests, uint codeHandicaps) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, codeHandicaps, NULL_CODE_CARDINALS);
		}

		public static ITargetValues CreateTaxingAllowanceStudyingValues(uint codeInterests) 
		{
			return new TargetValues (DEFAULT_CONTRACT_TYPE, DEFAULT_HEALTH_TYPE, DEFAULT_SOCIAL_TYPE,
				NULL_DATE_FROM, NULL_DATE_ENDS, NULL_TIME_WEEKLY, NULL_TIME_WORKED, NULL_TIME_ABSENT, 
				NULL_AMOUNT_MONTHLY,
				codeInterests, NULL_CODE_RESIDENCY, NULL_CODE_MANDATORY, NULL_CODE_STATEMENT, NULL_CODE_HANDICAPS, NULL_CODE_CARDINALS);
		}
	}
}

