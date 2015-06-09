using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.ProcessConfig.Items
{
	public class TargetValues : ITargetValues
	{
		public TargetValues ()
		{
			__contractType = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			__healthWorkType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENT;

			__socialWorkType = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;

			__dateFrom = null;

			__dateEnds = null;

			__timesheetWeekly = 0;

			__workdaysWeekly = 0;

			__timesheetWorked = 0;

			__timesheetAbsent = 0;

			__amountMonthly = 0m;

			__codeInterests = 0;

			__codeResidency = 0;

			__codeMandatory = 0;

			__codeStatement = 0;

			__codeHandicaps = 0;

			__codeCardinals = 0;
		}

		public TargetValues (WorkRelationTerms contract, WorkHealthTerms healthType, WorkSocialTerms socialType,
			DateTime? dateFrom, DateTime? dateEnds, Int32 timeWeekly, Int32 daysWeekly, Int32 timeWorked, Int32 timeAbsent,
			decimal amountMonthly, uint interests, uint residency, uint mandatory, uint statement, uint handicaps, uint cardinals)
		{
			__contractType = contract;

			__healthWorkType = healthType;

			__socialWorkType = socialType;

			__dateFrom = dateFrom;

			__dateEnds = dateEnds;

			__timesheetWeekly = timeWeekly;

			__workdaysWeekly = daysWeekly;

			__timesheetWorked = timeWorked;

			__timesheetAbsent = timeAbsent;

			__amountMonthly = amountMonthly;

			__codeInterests = interests;

			__codeResidency = residency;

			__codeMandatory = mandatory;

			__codeStatement = statement;

			__codeHandicaps = handicaps;

			__codeCardinals = cardinals;
		}

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
	}
}

