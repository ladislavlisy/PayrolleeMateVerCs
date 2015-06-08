using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessConfig.Items
{
	public class BookResult : IBookResult
	{
		public BookResult (IBookIndex element, IPayrollArticle article, IResultValues values, string[] targetValues, string[] resultValues)
		{
			__element = element;

			__article = article;

			__values = values;

			__targetValues = targetValues;

			__resultValues = resultValues;
		}
		 
		private IBookIndex __element = null;

		private IPayrollArticle __article = null;

		private IResultValues __values = null;

		private string[] __targetValues = null;

		private string[] __resultValues = null;

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

		public string[] TargetValues()
		{
			return __targetValues;
		}

		public string[] ResultValues()
		{
			return __resultValues;
		}

		#endregion
	}
}

