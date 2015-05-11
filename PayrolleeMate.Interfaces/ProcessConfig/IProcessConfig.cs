using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IProcessConfig
	{
		IPayrollArticle FindArticle(uint articleCode);

		IPayrollConcept FindConcept(uint conceptCode);

		void InitArticles();

		void InitConcepts();

		void InitModule();
	}
}

