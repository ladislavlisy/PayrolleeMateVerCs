using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Patterns
{
	public class BookResultBase : IBookResult
	{
		public BookResultBase (IPayrollArticle article)
		{
			__article = article;
		}
		 
		private IPayrollArticle __article = null;

		#region IBookResult implementation

		public IPayrollArticle Article ()
		{
			return __article;
		}

		#endregion
	}
}

