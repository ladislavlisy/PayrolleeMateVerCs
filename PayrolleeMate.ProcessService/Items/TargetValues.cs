using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Patterns;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessService.Patterns;

namespace PayrolleeMate.ProcessService.Items
{
	public class TargetValues : TargetValuesBase
	{
		public TargetValues (DateTime? dateFrom, DateTime? dateEnds, Int32 timeWeekly, Int32 timeWorked, Int32 timeMissed,
			decimal amountMonthly, uint interests, uint residency, uint mandatory, uint statement, uint handicaps, uint cardinals) : base()
		{
			__dateFrom = dateFrom;

			__dateEnds = dateEnds;

			__timesheetWeekly = timeWeekly;

			__timesheetWorked = timeWorked;

			__timesheetMissed = timeMissed;

			__amountMonthly = amountMonthly;

			__codeInterests = interests;

			__codeResidency = residency;

			__codeMandatory = mandatory;

			__codeStatement = statement;

			__codeHandicaps = handicaps;

			__codeCardinals = cardinals;
		}

		public static ITargetValues CreateContractEmplTermValues(DateTime? dateFrom, DateTime? dateEnds)
		{
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeInterests = 0;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreatePositionEmplTermValues(DateTime? dateFrom, DateTime? dateEnds) 
		{
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeInterests = 0;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateScheduleWorkValues(Int32 timeWeekly) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeInterests = 0;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTimehoursWorkingValues(Int32 timeWorked) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeInterests = 0;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTimehoursAbsenceValues(Int32 timeMissed) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			decimal amountMonthly = 0m;
			uint codeInterests = 0;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateSalaryBaseValues(decimal amountMonthly) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			uint codeInterests = 0;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateHealthIncomeSubjectValues(uint codeInterests, uint codeResidency, uint codeMandatory) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateSocialIncomeSubjectValues(uint codeInterests, uint codeResidency) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateGarantIncomeSubjectValues(uint codeInterests) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTaxingIncomeSubjectValues(uint codeInterests, uint codeResidency, uint codeStatement) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeMandatory = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTaxingAllowancePayerValues(uint codeInterests) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTaxingAllowanceChildValues(uint codeInterests, uint codeHandicaps, uint codeCardinals) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTaxingAllowanceDisabilityValues(uint codeInterests, uint codeHandicaps) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}

		public static ITargetValues CreateTaxingAllowanceStudyingValues(uint codeInterests) 
		{
			DateTime? dateFrom = null;
			DateTime? dateEnds = null;
			Int32 timeWeekly = 0;
			Int32 timeWorked = 0;
			Int32 timeMissed = 0;
			decimal amountMonthly = 0m;
			uint codeResidency = 0;
			uint codeMandatory = 0;
			uint codeStatement = 0;
			uint codeHandicaps = 0;
			uint codeCardinals = 0;

			return new TargetValues (dateFrom, dateEnds, timeWeekly, timeWorked, timeMissed, amountMonthly,
				codeInterests, codeResidency, codeMandatory, codeStatement, codeHandicaps, codeCardinals);
		}
	}
}

