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
	}
}

