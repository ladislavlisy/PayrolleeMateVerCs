using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Items;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class BookResultBuilder
	{
		public static readonly string[] EMPTY_VALUES_LIST = { };

		public static IBookResult CreateEmptyResult(IBookIndex element, IPayrollArticle article)
		{
			IResultValues results = ResultValueBuilder.BuildEmptyResult ();

			return new BookResult (element, article, results, EMPTY_VALUES_LIST, EMPTY_VALUES_LIST);
		}

		public static IBookResult CreateCloneResult(IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets)
		{
			IResultValues results = ResultValueBuilder.BuildTargetResult (targets);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateContractEmplTermResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, uint dayFromOrdinal, uint dayEndsOrdinal)
		{
			IResultValues results = ResultValueBuilder.BuildContractEmplTermResult (targets, dayFromOrdinal, dayEndsOrdinal);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreatePositionEmplTermResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, uint dayFromOrdinal, uint dayEndsOrdinal)
		{
			IResultValues results = ResultValueBuilder.BuildPositionEmplTermResult (targets, dayFromOrdinal, dayEndsOrdinal);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateScheduleWorkResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32[] timeTable)
		{
			IResultValues results = ResultValueBuilder.BuildScheduleWorkResult (targets, timeTable);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateTimesheetScheduleResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32[] timeTable)
		{
			IResultValues results = ResultValueBuilder.BuildTimesheetScheduleResult (targets, timeTable);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateWorkTimetableResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32[] timeTable)
		{
			IResultValues results = ResultValueBuilder.BuildWorkTimetableResult (targets, timeTable);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateOverTimetableResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32[] timeTable)
		{
			IResultValues results = ResultValueBuilder.BuildOverTimetableResult (targets, timeTable);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateAbsenceTimetableResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32[] timeTable)
		{
			IResultValues results = ResultValueBuilder.BuildAbsenceTimetableResult (targets, timeTable);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateWorktimeCountResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32 timeValue)
		{
			IResultValues results = ResultValueBuilder.BuildWorktimeCountResult (targets, timeValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateOvertimeCountResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32 timeValue)
		{
			IResultValues results = ResultValueBuilder.BuildOvertimeCountResult (targets, timeValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateAbsenceCountResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32 timeValue)
		{
			IResultValues results = ResultValueBuilder.BuildAbsenceCountResult (targets, timeValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}


		public static IBookResult CreateRecordTimeResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, Int32 timeValue)
		{
			IResultValues results = ResultValueBuilder.BuildRecordTimeResult (targets, timeValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateRecordAmountResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, decimal amountValue)
		{
			IResultValues results = ResultValueBuilder.BuildRecordAmountResult (targets, amountValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateRecordIncomeResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, decimal incomeValue)
		{
			IResultValues results = ResultValueBuilder.BuildRecordIncomeResult (targets, incomeValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}


		public static IBookResult CreateAmountIncomeResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, decimal amountValue)
		{
			IResultValues results = ResultValueBuilder.BuildAmountIncomeResult (targets, amountValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateAmountPaymentsResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, decimal amountValue)
		{
			IResultValues results = ResultValueBuilder.BuildAmountPaymentsResult (targets, amountValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateMonthlyAmountPaymentsResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, 
			decimal factorValue, decimal amountValue, Int32 recordHours)
		{
			IResultValues results = ResultValueBuilder.BuildMonthlyAmountPaymentsResult (targets, factorValue, amountValue, recordHours);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}

		public static IBookResult CreateAmountDeductedResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, decimal amountValue)
		{
			IResultValues results = ResultValueBuilder.BuildAmountDeductedResult (targets, amountValue);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}
	}
}

