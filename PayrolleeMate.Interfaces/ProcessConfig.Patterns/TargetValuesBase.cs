using System;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessConfig.Patterns
{
	public class TargetValuesBase : ITargetValues
	{
		public TargetValuesBase ()
		{
			__dateFrom = null;

			__dateEnds = null;

			__timesheetWeekly = 0;

			__timesheetWorked = 0;

			__timesheetMissed = 0;

			__amountMonthly = 0m;

			__codeInterests = 0;

			__codeResidency = 0;

			__codeMandatory = 0;

			__codeStatement = 0;

			__codeHandicaps = 0;

			__codeCardinals = 0;
		}

		public TargetValuesBase (DateTime? dateFrom, DateTime? dateEnds, Int32 timeWeekly, Int32 timeWorked, Int32 timeMissed,
			decimal amountMonthly, uint interests, uint residency, uint mandatory, uint statement, uint handicaps, uint cardinals)
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

		protected DateTime? __dateFrom = null;

		protected DateTime? __dateEnds = null;

		protected Int32 __timesheetWeekly = 0;

		protected Int32 __timesheetWorked = 0;

		protected Int32 __timesheetMissed = 0;

		protected decimal __amountMonthly = 0m;

		protected uint __codeInterests = 0;

		protected uint __codeResidency = 0;

		protected uint __codeMandatory = 0;

		protected uint __codeStatement = 0;

		protected uint __codeHandicaps = 0;

		protected uint __codeCardinals = 0;

		#region ITargetValues implementation

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

		public Int32 TimesheetWorked ()
		{
			return __timesheetWorked;
		}

		public Int32 TimesheetMissed ()
		{
			return __timesheetMissed;
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
	}
}

