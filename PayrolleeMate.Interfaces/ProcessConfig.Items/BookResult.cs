using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessConfig.Items
{
	public class BookResult : IBookResult
	{
		public BookResult (IBookIndex element, IPayrollArticle article, IResultValues values)
		{
			__element = element;

			__article = article;

			__values = values;
		}
		 
		private IBookIndex __element = null;

		private IPayrollArticle __article = null;

		private IResultValues __values = null;

		#region IBookResult implementation

		public IBookIndex Element ()
		{
			return __element;
		}

		public IPayrollArticle Article ()
		{
			return __article;
		}
			
		public IResultValues Values ()
		{
			return __values;
		}

		#endregion
	}
}

