using System;
using Payrollee.Common;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IProcessConfig
	{
		IPayrollArticle FindArticle(uint articleCode);

		IPayrollConcept ArticleConceptFromModels(IPayrollArticle article);

		IPayrollConcept ConceptFromModels(SymbolName conceptSymbol, ArticleCode articleCode);

		IPayrollConcept FindConcept(uint conceptCode);

		void InitArticles();

		void InitConcepts();

		void InitArticlesAndConcepts();
	}
}

