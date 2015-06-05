using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Patterns
{
	public class EmptyBookResult : BookResultBase
	{
		public EmptyBookResult (IBookIndex element, IPayrollArticle article) : base(element, article)
		{
		}

		#region implemented abstract members of BookResultBase

		public override IResultValues Values ()
		{
			return null;
		}

		#endregion
	}
}

