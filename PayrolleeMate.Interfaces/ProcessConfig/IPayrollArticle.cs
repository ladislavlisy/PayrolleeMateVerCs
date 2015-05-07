using System;
using Payrollee.Common;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IPayrollArticle
	{
		uint ArticleCode();

		string ArticleName();

		SymbolName ConceptSpec();

		uint ConceptCode();

		string ConceptName();

		bool HealthIncome();
		bool SocialIncome();
		bool TaxingIncome();

		bool IncomeGross();
		bool IncomeNetto();

		bool DeductionNetto();
	}
}

