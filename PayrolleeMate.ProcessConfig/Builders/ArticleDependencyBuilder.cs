﻿using System;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Logers;
using PayrolleeMate.ProcessConfig.Comparers;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Exceptions;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class ArticleDependencyBuilder
	{
		public static IDictionary<uint, IPayrollArticle[]> CollectArticles(
			IDictionary<uint, IPayrollArticle[]> pendingDict, IDictionary<uint, IPayrollArticle[]> initialDict, IProcessConfigLogger logger)
		{
			var relatedDict = pendingDict.Aggregate(initialDict,
				(agr, pair) => CollectDependentArticles(agr, pair.Key, pair.Value, pendingDict, logger).
				ToDictionary(key => key.Key, val => val.Value));

			LoggerWrapper.LogDependentArticlesCollection(logger, relatedDict, "CollectRelatedCollection");

			return relatedDict;
		}

		private static IDictionary<uint, IPayrollArticle[]> CollectDependentArticles(
			IDictionary<uint, IPayrollArticle[]> initialDict, 
			uint articleCode, IPayrollArticle[] pendingArticles, 
			IDictionary<uint, IPayrollArticle[]> pendingDict, IProcessConfigLogger logger)
		{
			LoggerWrapper.LogAppendMessageInfo(logger, ">>>>>", "CollectRelated");

			var resultList = CollectRelatedArticlesFromList(initialDict, articleCode, pendingArticles, pendingDict, logger);

			LoggerWrapper.LogAppendMessageInfo(logger, "<<<<<", "CollectRelated");

			LoggerWrapper.LogDependentCodeArticlesInfo(logger, articleCode, resultList, "ConceptArticles");					

			var relatedDict = MergeIntoDictionary(initialDict, articleCode, resultList);

			return relatedDict;
		}

		private static IPayrollArticle[] CollectRelatedArticlesFromList(IDictionary<uint, IPayrollArticle[]> initialDict,
			uint articleCode, IPayrollArticle[] pendingArticles, IDictionary<uint, IPayrollArticle[]> pendingDict, 
			IProcessConfigLogger logger)
		{

			var callingArticles = new SymbolName[0];

			var relatedList = pendingArticles.Aggregate(new IPayrollArticle[0],
				(agr, article) => agr.Concat(CollectRelatedArticlesFromDict(initialDict, article, callingArticles, pendingDict, logger)).ToArray());

			var articleList = relatedList.Distinct ().OrderBy (x => x.ArticleSymbol ()).ToArray ();

			return articleList;
		}

		private static IDictionary<uint, IPayrollArticle[]> MergeIntoDictionary(
			IDictionary<uint, IPayrollArticle[]> initialDict, 
			uint articleode, IPayrollArticle[] relatedArticles)
		{
			var articleList = relatedArticles.Distinct ().OrderBy (x => x.ArticleSymbol ()).ToArray ();

			var relatedPair = new Dictionary<uint, IPayrollArticle[]> () { { articleode,  articleList} };

			var relatedDict = initialDict.Union(relatedPair).ToDictionary(key => key.Key, val => val.Value);

			return relatedDict;
		}

		private static IPayrollArticle[] CollectRelatedArticlesFromDict(IDictionary<uint, IPayrollArticle[]> initialDict, 
			IPayrollArticle article, SymbolName[] callingArticles, IDictionary<uint, IPayrollArticle[]> pendingDict, IProcessConfigLogger logger)
		{
			var relatedArticles = CollectFromRelated (initialDict, article, pendingDict);

			bool existsRelated = relatedArticles != null;

			if (existsRelated) 
			{
				LoggerWrapper.LogRelatedArticles(logger, article, relatedArticles, "CollectRelated");

				return relatedArticles;
			}
			else 
			{
				relatedArticles = CollectFromPending (initialDict, article, callingArticles, pendingDict, logger);

				var pendingArticles = FindArticlesInDictionary(pendingDict, article);

				LoggerWrapper.LogPendingArticles(logger, article, pendingArticles, callingArticles, relatedArticles, "CollectRelated");

				return relatedArticles;
			}
		}

		private static IPayrollArticle[] CollectFromRelated(IDictionary<uint, IPayrollArticle[]> relatedDict, 
			IPayrollArticle article, IDictionary<uint, IPayrollArticle[]> pendingDict)
		{
			uint articleCode = article.ArticleCode();

			bool skipExecToPending = !relatedDict.ContainsKey(articleCode);

			if (skipExecToPending)
			{
				return null;
			}

			var initialArticles = new IPayrollArticle[] { article };

			var relatedArticles = FindArticlesInDictionary(relatedDict, article);

			return initialArticles.Concat(relatedArticles).ToArray();
		}

		private static IPayrollArticle[] CollectFromPending(IDictionary<uint, IPayrollArticle[]> relatedDict, 
			IPayrollArticle article, SymbolName[] articlePath, IDictionary<uint, IPayrollArticle[]> pendingDict, IProcessConfigLogger logger)
		{
			uint articleCode = article.ArticleCode();

			bool skipExecToRelated = relatedDict.ContainsKey(articleCode);

			if (skipExecToRelated)
			{
				return null;
			}

			bool articlesCircle = (articlePath.Count (x => x.Code == articleCode) > 0);

			if (articlesCircle) 
			{
				throw new EngineProcessCircleException ("Circular article reference", articlePath, article.ArticleSymbol());
			}

			var initialArticles = new IPayrollArticle[] { article };

			var callingArticles = articlePath.Concat (new SymbolName[] { article.ArticleSymbol() }).ToArray();

			var pendingArticles = FindArticlesInDictionary(pendingDict, article);

			var collectArticles = pendingArticles.Aggregate(initialArticles,
				(agr, articleSource) => agr.Concat(CollectRelatedArticlesFromDict(relatedDict, articleSource, callingArticles, pendingDict, logger)).ToArray());

			var relatedArticles = collectArticles.Distinct ().OrderBy (x => x.ArticleSymbol ()).ToArray ();

			return relatedArticles;
		}

		public static IPayrollArticle[] FindArticlesInDictionary (IDictionary<uint, IPayrollArticle[]> articlesDict, IPayrollArticle article)
		{
			IPayrollArticle[] articleList = null;

			uint articleCode = article.ArticleCode();

			bool existsInDictionary = articlesDict.TryGetValue(articleCode, out articleList);

			if (existsInDictionary)
			{
				return articleList;
			}
			return new IPayrollArticle[0];
		}

		public static IPayrollArticle[] SortDependecyArticles (
			IDictionary<uint, IPayrollArticle[]> relatedDict, IPayrollArticle[] articleList)
		{
			Tuple<IPayrollArticle, IPayrollArticle[]>[] articleDependencyList = 
				articleList.Select (x => (Tuple.Create (x, FindArticlesInDictionary (relatedDict, x)))).ToArray();

			Array.Sort (articleDependencyList, ConceptDependencyComparer.CompareDependency);

			IPayrollArticle[] sortedArticleList = articleDependencyList.Select (x => (x.Item1)).ToArray();

			return sortedArticleList;
		}

	}


}
