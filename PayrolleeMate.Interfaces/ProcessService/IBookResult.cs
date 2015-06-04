using System;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookResult
	{
		IBookIndex Element ();

		IPayrollArticle Article ();
	}
}

