using System;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService.Patterns
{
	public class EmptyBookResult : BookResultBase
	{
		public EmptyBookResult (IPayrollArticle article) : base(article)
		{
		}
	}
}

