using System;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IPayrollConcept
	{
		SymbolName ConceptSymbol();

		uint ConceptCode();

		string ConceptName();

		string[] TargetValues();

		IPayrollArticle[] RelatedArticles();

		IPayrollArticle[] PendingArticles();

		IPayrollArticle[] SummaryArticles();

		ProcessCategory Category();

		void UpdateRelatedArticles(IPayrollArticle[] articles);

		IResultStream CallEvaluate (IProcessConfig config, IEngineProfile engine, IBookIndex element, IResultStream results);
	}
}

