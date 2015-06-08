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

		public static IBookResult CreateContractEmplTermResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets, uint dayFromOrdinal, uint dayEndsOrdinal)
		{
			IResultValues results = ResultValueBuilder.BuildContractEmplTermResult (targets, dayFromOrdinal, dayEndsOrdinal);

			return new BookResult (element, article, results, concept.TargetValues(), concept.ResultValues());
		}
	}
}

