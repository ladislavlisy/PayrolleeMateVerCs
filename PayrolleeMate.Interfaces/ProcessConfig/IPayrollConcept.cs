using System;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IPayrollConcept
	{
		uint ConceptCode();

		string ConceptName();

		string[] TargetValues();

		IPayrollArticle[] RelatedArticles();

		IPayrollArticle[] PendingArticles();

		IPayrollArticle[] SummaryArticles();

		ProcessCategory Category();

		void UpdateRelatedArticles(IPayrollArticle[] articles);

	}
}

