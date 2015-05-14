using System;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Logers;
using PayrolleeMate.ProcessConfig.Comparers;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class ArticleDependencyBuilder
	{
		public static IDictionary<uint, IPayrollArticle[]> CollectArticles(
			IDictionary<uint, IPayrollArticle[]> pendingDict, IProcessConfigLogger logger)
		{
			var initialDict = new Dictionary<uint, IPayrollArticle[]>();

			var relatedDict = pendingDict.Aggregate(initialDict,
				(agr, pair) => CollectArticlesForConcept(agr, pair.Key, pair.Value, pendingDict, logger).
				ToDictionary(key => key.Key, val => val.Value));

			LoggerWrapper.LogConceptArticlesCollection(logger, relatedDict, "CollectRelatedCollection");

			return relatedDict;
		}

		private static IDictionary<uint, IPayrollArticle[]> CollectArticlesForConcept(
			IDictionary<uint, IPayrollArticle[]> initialDict, 
			uint conceptCode, IPayrollArticle[] pendingArticles, 
			IDictionary<uint, IPayrollArticle[]> pendingDict, IProcessConfigLogger logger)
		{
			var resultList = CollectRelatedArticlesFromList(initialDict, conceptCode, pendingArticles, pendingDict, logger);

			LoggerWrapper.LogConceptCodeArticles(logger, conceptCode, resultList, "ConceptArticles");					

			var relatedDict = MergeIntoDictionary(initialDict, conceptCode, resultList);

			return relatedDict;
		}

		private static IDictionary<uint, IPayrollArticle[]> MergeIntoDictionary(
			IDictionary<uint, IPayrollArticle[]> initialDict, 
			uint conceptCode, IPayrollArticle[] relatedArticles)
		{
			var mergeArticles = new Dictionary<uint, IPayrollArticle[]> () {
				{ conceptCode, relatedArticles.Distinct ().OrderBy (x => x.ArticleSymbol()).ToArray () }
			};

			var relatedDict = initialDict.Union(mergeArticles).ToDictionary(key => key.Key, val => val.Value);

			return relatedDict;
		}

		private static IPayrollArticle[] CollectRelatedArticlesFromList(IDictionary<uint, IPayrollArticle[]> initialDict,
			uint conceptCode, IPayrollArticle[] pendingArticles, IDictionary<uint, IPayrollArticle[]> pendingDict, 
			IProcessConfigLogger logger)
		{
			var relatedDict = pendingArticles.Aggregate(new IPayrollArticle[0],
				(agr, article) => agr.Concat(CollectRelatedArticlesFromDict(initialDict, article, pendingDict, logger)).ToArray());

			return relatedDict;
		}

		private static IPayrollArticle[] CollectRelatedArticlesFromDict(IDictionary<uint, IPayrollArticle[]> initialDict, 
			IPayrollArticle article, IDictionary<uint, IPayrollArticle[]> pendingDict, IProcessConfigLogger logger)
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
				relatedArticles = CollectFromPending (initialDict, article, pendingDict, logger);

				LoggerWrapper.LogPendingArticles(logger, article, relatedArticles, "CollectRelated");

				return relatedArticles;
			}
		}

		private static IPayrollArticle[] CollectFromRelated(IDictionary<uint, IPayrollArticle[]> relatedDict, 
			IPayrollArticle article, IDictionary<uint, IPayrollArticle[]> pendingDict)
		{
			uint conceptCode = article.ConceptCode();

			bool skipExecToPending = !relatedDict.ContainsKey(conceptCode);

			if (skipExecToPending)
			{
				return null;
			}

			var initialArticles = new IPayrollArticle[] { article };

			var relatedArticles = FindArticlesInDictionary(relatedDict, article);

			return initialArticles.Concat(relatedArticles).ToArray();
		}

		private static IPayrollArticle[] CollectFromPending(IDictionary<uint, IPayrollArticle[]> relatedDict, 
			IPayrollArticle article, IDictionary<uint, IPayrollArticle[]> pendingDict, IProcessConfigLogger logger)
		{
			uint conceptCode = article.ConceptCode();

			bool skipExecToRelated = relatedDict.ContainsKey(conceptCode);

			if (skipExecToRelated)
			{
				return null;
			}

			var initialArticles = new IPayrollArticle[] { article };

			var pendingArticles = FindArticlesInDictionary(pendingDict, article);

			var relatedArticles = pendingArticles.Aggregate(initialArticles,
				(agr, articleSource) => agr.Concat(CollectRelatedArticlesFromDict(relatedDict, articleSource, pendingDict, logger)).ToArray());

			return relatedArticles;
		}
		public static IPayrollArticle[] FindArticlesInDictionary (IDictionary<uint, IPayrollArticle[]> articlesDict, IPayrollArticle article)
		{
			IPayrollArticle[] articleList = null;

			uint conceptCode = article.ConceptCode();

			bool existsInDictionary = articlesDict.TryGetValue(conceptCode, out articleList);

			if (existsInDictionary)
			{
				return articleList;
			}
			return new IPayrollArticle[0];
		}

		public static IPayrollArticle[] SortDependecyArticles (IDictionary<uint, IPayrollArticle[]> relatedDict, 
			Tuple<IPayrollConcept, IPayrollArticle>[] conceptArticleList)
		{
			Tuple<IPayrollConcept, IPayrollArticle, IPayrollArticle[]>[] sortConceptArticleList = 
				conceptArticleList.Select (x => (Tuple.Create (x.Item1, x.Item2, 
					FindArticlesInDictionary (relatedDict, x.Item2)))).ToArray();

			Array.Sort (sortConceptArticleList, ConceptDependencyComparer.CompareDependency);

			IPayrollArticle[] sortedArticleList = sortConceptArticleList.Select (x => (x.Item2)).ToArray();

			return sortedArticleList;
		}

	}


}

