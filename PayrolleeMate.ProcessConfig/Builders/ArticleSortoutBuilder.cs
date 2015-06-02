using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.ProcessConfig.Comparers;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public class ArticleSortoutBuilder : ArticleListBuilder
	{
		public static IDictionary<uint, IPayrollArticle[]> BuildSortedArticleDict(IDictionary<uint, IPayrollArticle[]> relatedArticles)
		{
			var sortoutArticles = relatedArticles.Select((x) => (BuildSortedArticleList(x.Key, x.Value, relatedArticles))).
				ToDictionary(key => key.Key, val => val.Value);

			return sortoutArticles;
		}

		private static KeyValuePair<uint, IPayrollArticle[]> BuildSortedArticleList (uint articleCode, 
			IPayrollArticle[] articleList, IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			var sortedList = SortDependecyArticles (articleList, relatedDict);

			return new KeyValuePair<uint, IPayrollArticle[]> (articleCode, sortedList);
		}

		private static IPayrollArticle[] SortDependecyArticles (IPayrollArticle[] articleList, IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			if (articleList == null) 
			{
				return EMPTY_ARTICLE_LIST;
			} 
			else if (articleList.Length == 0) 
			{
				return EMPTY_ARTICLE_LIST;
			} 
			else
			{
				var articleSortingList = BuildDependencyList (articleList, relatedDict);

				Array.Sort (articleSortingList, ConceptDependencyComparer.CompareDependency);

				IPayrollArticle[] articleSortoutList = articleSortingList.Select (x => (x.Item1)).ToArray ();

				return articleSortoutList;
			}
		}

		private static Tuple<IPayrollArticle, IPayrollArticle[]>[] BuildDependencyList (IPayrollArticle[] articleList, IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			Tuple<IPayrollArticle, IPayrollArticle[]>[] dependencyList = articleList.Select (x => (Tuple.Create (x, FindArticleListInDictionary (relatedDict, x)))).ToArray ();

			return dependencyList;
		}

		private static IPayrollArticle[] FindArticleListInDictionary (IDictionary<uint, IPayrollArticle[]> articlesDict, IPayrollArticle article)
		{
			uint articleCode = article.ArticleCode();

			IPayrollArticle[] articleList = null;

			bool existsInDictionary = articlesDict.TryGetValue(articleCode, out articleList);

			if (existsInDictionary)
			{
				return articleList;
			}
			return EMPTY_ARTICLE_LIST;
		}

	}
}

