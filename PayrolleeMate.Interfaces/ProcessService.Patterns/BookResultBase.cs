using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Patterns
{
	public abstract class BookResultBase : IBookResult
	{
		public static readonly IBookResult[] EMPTY_RESULT_LIST = { };

		public BookResultBase (IBookIndex element, IPayrollArticle article)
		{
			__element = element;

			__article = article;
		}
		 
		private IBookIndex __element = null;

		private IPayrollArticle __article = null;

		#region IBookResult implementation

		public IBookIndex Element ()
		{
			return __element;
		}

		public IPayrollArticle Article ()
		{
			return __article;
		}
			
		public abstract IResultValues Values ();

		#endregion
	}
}

