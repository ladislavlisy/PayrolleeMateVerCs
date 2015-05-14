using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Linq;

namespace PayrolleeMate.ProcessConfig.Comparers
{
	public static class ConceptDependencyComparer
	{
		public static int CompareDependency(
			Tuple<IPayrollConcept, IPayrollArticle, IPayrollArticle[]> entryOne, 
			Tuple<IPayrollConcept, IPayrollArticle, IPayrollArticle[]> entryTwo)
		{
			IPayrollArticle articleOne = entryOne.Item2;

			IPayrollConcept conceptOne = entryOne.Item1;

			IPayrollArticle[] relatedOne = entryOne.Item3;

			IPayrollArticle articleTwo = entryTwo.Item2;

			IPayrollConcept conceptTwo = entryTwo.Item1;

			IPayrollArticle[] relatedTwo = entryTwo.Item3;

			return CompareConcepts (articleOne, conceptOne, relatedOne, articleTwo, conceptTwo, relatedTwo);
		}

		private static int CompareConcepts(
			IPayrollArticle articleOne, IPayrollConcept conceptOne, IPayrollArticle[] relatedOne,
			IPayrollArticle articleTwo, IPayrollConcept conceptTwo, IPayrollArticle[] relatedTwo)
		{
			IPayrollArticle[] summaryOne = conceptOne.SummaryArticles ();

			IPayrollArticle[] summaryTwo = conceptTwo.SummaryArticles ();

			if (conceptOne.Category() != conceptTwo.Category())
			{
				int compareResult = conceptOne.Category().CompareTo(conceptTwo.Category());

				return compareResult;
			}
			else if (RelatedArticlesForCode(relatedOne, articleTwo.ArticleCode()))
			{
				return 1;
			}
			else if (RelatedArticlesForCode(relatedTwo, articleOne.ArticleCode()))
			{
				return -1;
			}
			else if (SummaryArticlesForCode(summaryOne, articleTwo.ArticleCode()))
			{
				return -1;
			}
			else if (SummaryArticlesForCode(summaryTwo, articleOne.ArticleCode()))
			{
				return 1;
			}
			else
			{
				int compareResult = conceptOne.ConceptCode().CompareTo(conceptTwo.ConceptCode());

				return compareResult;
			}
		}

		private static bool RelatedArticlesForCode(IPayrollArticle[] articles, uint articleCode)
		{
			return CountRelatedArticles(articles, articleCode) != 0;
		}

		private static int CountRelatedArticles(IPayrollArticle[] articles, uint articleCode)
		{
			if (articles == null)
			{
				return 0;
			}
			IPayrollArticle[] _articles = articles.Where(x => x.ArticleCode() == articleCode).ToArray<IPayrollArticle>();
			return _articles.Length;
		}

		private static bool SummaryArticlesForCode(IPayrollArticle[] articles, uint articleCode)
		{
			return CountSummaryArticles(articles, articleCode) != 0;
		}

		private static int CountSummaryArticles(IPayrollArticle[] articles, uint articleCode)
		{
			if (articles == null)
			{
				return 0;
			}
			IPayrollArticle[] _articles = articles.Where(x => x.ArticleCode() == articleCode).ToArray<IPayrollArticle>();
			return _articles.Length;
		}		
	}
}

