using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Collections;
using PayrolleeMate.Common;
using System.Linq;
using PayrolleeMate.ProcessConfig.Comparers;

namespace PayrolleeMate.ProcessConfig
{
	public class ArticleListBuilder
	{
		public static readonly IPayrollArticle[] EMPTY_ARTICLE_LIST = {};

		public static readonly uint[] EMPTY_ARTICLE_CODE_LIST = {};

		public static readonly SymbolName[] EMPTY_ARTICLE_SYMBOL_LIST = {};

	}

	public class ArticleObjectListBuilder<AIDX> : ArticleListBuilder
	{
		public static IDictionary<uint, IPayrollArticle[]> BuildRelatedArticleDict(
			IDictionary<uint, uint[]> relatedCodes, PayrollArticleCollection<AIDX> articles)
		{
			var relatedArticles = relatedCodes.Select((x) => (BuildRelatedArticleList(x.Key, x.Value, articles))).
				ToDictionary(key => key.Key, val => val.Value);

			return relatedArticles;
		}

		private static KeyValuePair<uint, IPayrollArticle[]> BuildRelatedArticleList (uint articleCode, uint[] articleCodes, 
			PayrollArticleCollection<AIDX> articles)
		{
			return new KeyValuePair<uint, IPayrollArticle[]> (articleCode, BuildArticleList(articleCodes, articles));
		}

		private static IPayrollArticle[] BuildArticleList(uint[] articleCodes, PayrollArticleCollection<AIDX> articles)
		{
			if (articleCodes == null) 
			{
				return EMPTY_ARTICLE_LIST;
			}
			else if (articleCodes.Length == 0) 
			{
				return EMPTY_ARTICLE_LIST;
			}
			else
			{
				var articleList = articleCodes.Select(x => articles.FindArticle(x)).ToArray();

				return articleList;
			}
		}

	}

	public class ArticleCodeListBuilder<AIDX> : ArticleListBuilder
	{
		public static IDictionary<uint, uint[]> BuildPendingCodesDict(PayrollArticleCollection<AIDX> articles)
		{
			var pendingArticles = articles.Models.ToDictionary(key => key.Key, val => BuildArticleCodesList(val.Value.PendingArticleNames()));

			var noemptyArticles = pendingArticles.Where (kvp => kvp.Value.Length != 0).ToDictionary (kvp => kvp.Key, kvp => kvp.Value);

			return noemptyArticles;
		}

		public static IDictionary<uint, uint[]> BuildRelatedCodesDict(PayrollArticleCollection<AIDX> articles)
		{
			var pendingArticles = articles.Models.ToDictionary(key => key.Key, val => BuildArticleCodesList(val.Value.PendingArticleNames()));

			var noemptyArticles = pendingArticles.Where (kvp => kvp.Value.Length == 0).ToDictionary (kvp => kvp.Key, kvp => kvp.Value);

			return noemptyArticles;
		}

		private static uint[] BuildArticleCodesList(SymbolName[] articleNames)
		{
			if (articleNames == null) 
			{
				return EMPTY_ARTICLE_CODE_LIST;
			}
			else if (articleNames.Length == 0) 
			{
				return EMPTY_ARTICLE_CODE_LIST;
			} 
			else 
			{
				var articleList = articleNames.Select (x => x.Code).ToArray ();

				return articleList;
			}
		}

	}

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

				Array.Sort (articleSortingList, ArticleDependencyComparer.CompareDependency);

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

