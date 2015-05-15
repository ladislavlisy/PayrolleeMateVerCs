using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;

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

		ProcessCategory Category();

		SymbolName[] PendingArticleNames();

		SymbolName[] SummaryArticleNames();

		IPayrollArticle[] RelatedArticles();

		void UpdateRelatedArticles(IPayrollArticle[] articles);
	}
}

