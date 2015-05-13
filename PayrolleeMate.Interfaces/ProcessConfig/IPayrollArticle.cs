using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IPayrollArticle
	{
		SymbolName ArticleSymbol();

		uint ArticleCode();

		string ArticleName();

		SymbolName ConceptSymbol();

		uint ConceptCode();

		string ConceptName();

		bool HealthIncome();
		bool SocialIncome();
		bool TaxingIncome();

		bool SummaryGross();
		bool SummaryNetto();

		bool DeductsNetto();
	}
}

