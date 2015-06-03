using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Linq;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Comparers
{
	public static class ArticleDependencyComparer
	{
		public static int CompareDependency(Tuple<IPayrollArticle, IPayrollArticle[]> entryOne, Tuple<IPayrollArticle, IPayrollArticle[]> entryTwo)
		{
			IPayrollArticle articleOne = entryOne.Item1;

			IPayrollArticle[] relatedOne = entryOne.Item2;

			SymbolName[] summaryOne = articleOne.SummaryArticleNames ();

			IPayrollArticle articleTwo = entryTwo.Item1;

			IPayrollArticle[] relatedTwo = entryTwo.Item2;

			SymbolName[] summaryTwo = articleTwo.SummaryArticleNames ();

			return CompareArticlesDependency (articleOne, relatedOne, summaryOne, articleTwo, relatedTwo, summaryTwo);
		}

		public static int CompareArticles(IPayrollArticle entryOne, IPayrollArticle entryTwo)
		{
			IPayrollArticle articleOne = entryOne;

			IPayrollArticle[] relatedOne = entryOne.RelatedArticles ();

			SymbolName[] summaryOne = articleOne.SummaryArticleNames ();

			IPayrollArticle articleTwo = entryTwo;

			IPayrollArticle[] relatedTwo = entryTwo.RelatedArticles ();

			SymbolName[] summaryTwo = articleTwo.SummaryArticleNames ();

			return CompareArticlesDependency (articleOne, relatedOne, summaryOne, articleTwo, relatedTwo, summaryTwo);
		}

		private static int CompareArticlesDependency(
			IPayrollArticle articleOne, IPayrollArticle[] relatedOne, SymbolName[] summaryOne,
			IPayrollArticle articleTwo, IPayrollArticle[] relatedTwo, SymbolName[] summaryTwo)
		{
			if (articleOne.Category() != articleTwo.Category())
			{
				int compareResult = articleOne.Category().CompareTo(articleTwo.Category());

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
				int compareResult = articleOne.ArticleCode().CompareTo(articleTwo.ArticleCode());

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

		private static bool SummaryArticlesForCode(SymbolName[] articles, uint articleCode)
		{
			return CountSummaryArticles(articles, articleCode) != 0;
		}

		private static int CountSummaryArticles(SymbolName[] articles, uint articleCode)
		{
			if (articles == null)
			{
				return 0;
			}
			SymbolName[] _articles = articles.Where(x => x.Code == articleCode).ToArray<SymbolName>();
			return _articles.Length;
		}		
	}
}

