using System;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IBookResult
	{
		IBookIndex Element ();

		IPayrollArticle Article ();

		IResultValues Values ();

		string[] TargetValues();

		string[] ResultValues();

	}
}

