using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IPayrollArticle
	{
		uint ArticleCode();

		string ArticleName();

		SymbolName ConceptSymbol();

		uint ConceptCode();

		string ConceptName();

		bool HealthIncome();
		bool SocialIncome();
		bool TaxingIncome();

		bool IncomeGross();
		bool IncomeNetto();

		bool DeductNetto();
	}
}

