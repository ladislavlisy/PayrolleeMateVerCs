﻿using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Constants;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.ProcessConfig.Items
{
	public class ResultValues : IResultValues
	{
		public const uint NULL_DAY_ORDINAL = 0;

		public static readonly Int32[] NULL_TIME_TABLE = { };

		public const Int32 NULL_TIME_COUNTS = 0;

		public const decimal NULL_AMOUNT = 0m;

		public const decimal NULL_INCOME = 0m;

		public static IResultValues GetEmpty()
		{
			return new ResultValues (null, NULL_DAY_ORDINAL, NULL_DAY_ORDINAL, 
				NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, NULL_TIME_TABLE, 
				NULL_TIME_COUNTS, NULL_TIME_COUNTS, NULL_TIME_COUNTS, 
				NULL_TIME_COUNTS, NULL_AMOUNT, NULL_INCOME, NULL_INCOME, NULL_AMOUNT, NULL_AMOUNT);
		}

		public ResultValues (ITargetValues targetValues,
			uint dayFromOrdinal, uint dayEndsOrdinal,
			Int32[] shiftTable, Int32[] workTable, Int32[] overTable, Int32[] absenceTable,
			Int32 workCount, Int32 overCount, Int32 absenceCount, 
			Int32 recordTime, decimal recordAmount, decimal recordIncome, 
			decimal income, decimal payments, decimal deducted)
		{
			CopyTargetsToResults (targetValues);

			__periodDayFromOrdinal = dayFromOrdinal;

			__periodDayEndsOrdinal  = dayEndsOrdinal;

			__shiftTimetable = shiftTable;

			__workTimetable = workTable;

			__overTimetable = overTable;

			__absenceTimetable = absenceTable;

			__worktimeCount = workCount;

			__overtimeCount = overCount;

			__absenceCount = absenceCount;

			__recordTime = recordTime;

			__recordAmount = recordAmount;

			__recordIncome = recordIncome;

			__amountIncome = income;

			__amountPayments = payments;

			__amountDeducted = deducted;
		}

		// TARGET VALUES

		protected WorkRelationTerms __contractType = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

		protected WorkHealthTerms __healthWorkType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENT;

		protected WorkSocialTerms __socialWorkType = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;

		protected DateTime? __dateFrom = null;

		protected DateTime? __dateEnds = null;

		protected Int32 __timesheetWeekly = 0;

		protected Int32 __workdaysWeekly = 0;

		protected Int32 __timesheetWorked = 0;

		protected Int32 __timesheetAbsent = 0;

		protected decimal __amountMonthly = 0m;

		protected uint __codeInterests = 0;

		protected uint __codeResidency = 0;

		protected uint __codeMandatory = 0;

		protected uint __codeStatement = 0;

		protected uint __codeHandicaps = 0;

		protected uint __codeCardinals = 0;

		// RESULTS VALUES

		protected uint __periodDayFromOrdinal = MonthPeriod.TERM_BEG_FINISHED;

		protected uint __periodDayEndsOrdinal = MonthPeriod.TERM_END_FINISHED;

		protected Int32[] __shiftTimetable = { };

		protected Int32[] __workTimetable = { };

		protected Int32[] __overTimetable = { };

		protected Int32[] __absenceTimetable = { };

		protected Int32 __worktimeCount = 0;

		protected Int32 __overtimeCount = 0;

		protected Int32 __absenceCount = 0;


		protected Int32 __recordTime = 0;

		protected decimal __recordAmount = 0m;

		protected decimal __recordIncome = 0m;


		protected decimal __amountIncome = 0m;

		protected decimal __amountPayments = 0m;

		protected decimal __amountDeducted = 0m;

		#region IResultValues implementation

		public uint PeriodDayFromOrdinal ()
		{
			return __periodDayFromOrdinal;
		}

		public uint PeriodDayEndsOrdinal ()
		{
			return __periodDayEndsOrdinal;
		}

		public Int32[] ShiftTimetable ()
		{
			return __shiftTimetable;
		}

		public Int32[] WorkTimetable ()
		{
			return __workTimetable;
		}

		public Int32[] OverTimetable ()
		{
			return __overTimetable;
		}

		public Int32[] AbsenceTimetable ()
		{
			return __absenceTimetable;
		}

		public Int32 WorktimeCount ()
		{
			return __worktimeCount;
		}

		public Int32 OvertimeCount ()
		{
			return __overtimeCount;
		}

		public Int32 AbsenceCount ()
		{
			return __absenceCount;
		}

		public Int32 RecordTime ()
		{
			return __recordTime;
		}

		public decimal RecordAmount ()
		{
			return __recordAmount;
		}

		public decimal RecordIncome ()
		{
			return __recordIncome;
		}

		public decimal AmountIncome ()
		{
			return __amountIncome;
		}

		public decimal AmountPayments ()
		{
			return __amountPayments;
		}

		public decimal AmountDeducted ()
		{
			return __amountDeducted;
		}
			
		#endregion

		#region ITargetValues implementation

		public WorkRelationTerms ContractType ()
		{
			return __contractType;
		}

		public WorkHealthTerms HealthWorkType ()
		{
			return __healthWorkType;
		}

		public WorkSocialTerms SocialWorkType ()
		{
			return __socialWorkType;
		}

		public DateTime? DateFrom ()
		{
			return __dateFrom;
		}

		public DateTime? DateEnds ()
		{
			return __dateEnds;
		}

		public Int32 TimesheetWeekly ()
		{
			return __timesheetWeekly;
		}

		public Int32 WorkdaysWeekly ()
		{
			return __workdaysWeekly;
		}

		public Int32 TimesheetWorked ()
		{
			return __timesheetWorked;
		}

		public Int32 TimesheetAbsent ()
		{
			return __timesheetAbsent;
		}

		public decimal AmountMonthly ()
		{
			return __amountMonthly;
		}

		public uint CodeInterests ()
		{
			return __codeInterests;
		}

		public uint CodeResidency ()
		{
			return __codeResidency;
		}

		public uint CodeMandatory ()
		{
			return __codeMandatory;
		}

		public uint CodeStatement ()
		{
			return __codeStatement;
		}

		public uint CodeHandicaps ()
		{
			return __codeHandicaps;
		}

		public uint CodeCardinals ()
		{
			return __codeCardinals;
		}

		#endregion

		private void CopyTargetsToResults(ITargetValues targetValues)
		{
			if (targetValues == null) 
			{
				return;
			}

			__contractType = targetValues.ContractType ();

			__healthWorkType = targetValues.HealthWorkType ();

			__socialWorkType = targetValues.SocialWorkType ();

			__dateFrom = targetValues.DateFrom ();

			__dateEnds = targetValues.DateEnds ();

			__timesheetWeekly = targetValues.TimesheetWeekly ();

			__workdaysWeekly = targetValues.WorkdaysWeekly ();

			__timesheetWorked = targetValues.TimesheetWorked ();

			__timesheetAbsent = targetValues.TimesheetAbsent ();

			__amountMonthly = targetValues.AmountMonthly ();

			__codeInterests = targetValues.CodeInterests ();

			__codeResidency = targetValues.CodeResidency ();

			__codeMandatory = targetValues.CodeMandatory ();

			__codeStatement = targetValues.CodeStatement ();

			__codeHandicaps = targetValues.CodeHandicaps ();

			__codeCardinals = targetValues.CodeCardinals ();
		}
	}
}

