using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Patterns
{
	public class BookResult : BookResultBase
	{
		private BookResult (IBookIndex element, IPayrollArticle article, IResultValues values) : base(element, article)
		{
			__values = values;
		}

		public static IBookResult CreateEmptyResult(IBookIndex element, IPayrollArticle article)
		{
			return new BookResult (element, article, null);
		}

		private IResultValues __values = null;

		#region implemented abstract members of BookResultBase

		public override IResultValues Values ()
		{
			return __values;
		}

		#endregion
	}
}

