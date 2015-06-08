using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Items;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class BookResultBuilder
	{
		public static readonly IBookResult[] EMPTY_RESULT_LIST = { };

		public static readonly string[] EMPTY_VALUES_LIST = { };

		public static IBookResult CreateEmptyResult(IBookIndex element, IPayrollArticle article)
		{
			return new BookResult (element, article, null, EMPTY_VALUES_LIST, EMPTY_VALUES_LIST);
		}
	}
}

