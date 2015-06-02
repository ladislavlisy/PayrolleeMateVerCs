using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using System.Linq;
using PayrolleeMate.ProcessConfig.Logers;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Comparers;
using PayrolleeMate.ProcessConfig.Exceptions;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public class ArticleDependencyBuilder : ArticleListBuilder
	{
		public static IDictionary<uint, uint[]> CollectArticles(
			IDictionary<uint, uint[]> dependencyDict, IDictionary<uint, uint[]> initialDict, IProcessConfigLogger logger)
		{
			var relatedDict = initialDict.ToDictionary(key => key.Key, val => val.Value);

			var articleCodes = dependencyDict.Keys;

			uint pendingCode = 0;

			uint[] pendingList = EMPTY_ARTICLE_CODE_LIST;

			uint[] callingList = EMPTY_ARTICLE_CODE_LIST;

			var collectedDict = articleCodes.Aggregate(relatedDict,
				(agr, code) => CollectRelatedArticles(agr, code, 
					callingList, pendingCode, pendingList, dependencyDict, logger).
						ToDictionary(key => key.Key, val => val.Value));

			return collectedDict;
		}
			
		private static IDictionary<uint, uint[]> CollectRelatedArticles(
			IDictionary<uint, uint[]> relatedInit, uint articleCode, 
			uint[] callingList, uint pendingCode, uint[] pendingList, 
			IDictionary<uint, uint[]> dependencyDict, IProcessConfigLogger logger)
		{
			if (articleCode == 0) 
			{
				uint[] initialList = (uint[]) pendingList.Clone();

				var composeList = pendingList.Aggregate(initialList, 
					(agrList, article) => ComposeRelatedArticles(agrList, article, relatedInit)).ToArray();

				return MergeIntoDictionary(relatedInit, pendingCode, composeList);
			}

			bool relatedExists = relatedInit.ContainsKey (articleCode);

			if (relatedExists == true) 
			{
				return relatedInit;
			}
		
			uint[] articleList = dependencyDict.FirstOrDefault (x => x.Key == articleCode).Value;

			if (articleList == null || articleList.Length == 0) 
			{
				return MergeIntoDictionary(relatedInit, articleCode, EMPTY_ARTICLE_CODE_LIST);
			}

			VerifyCircularDependency (articleCode, callingList);

			uint[] callingPath = callingList.Concat (new uint[] { articleCode }).ToArray();

			uint[] articleCodes = articleList.Select (x => x).Concat (new uint[] { 0 }).ToArray (); 

			var collectedDict = articleCodes.Aggregate(relatedInit, 
				(agr, code) => CollectRelatedArticles(agr, code, 
					callingPath, articleCode, articleList, dependencyDict, logger).
						ToDictionary(key => key.Key, val => val.Value));
			
			return collectedDict;
		}

		private static uint[] ComposeRelatedArticles (uint[] initialList, uint articleCode, IDictionary<uint, uint[]> relatedDict)
		{
			uint[] articleList = relatedDict.FirstOrDefault (x => x.Key == articleCode).Value;

			return initialList.Concat(articleList).ToArray();
		}

		private static IDictionary<uint, uint[]> MergeIntoDictionary(
			IDictionary<uint, uint[]> initialDict, 
			uint articleCode, uint[] relatedArticles)
		{
			var articleList = relatedArticles.Distinct ().OrderBy (x => x).ToArray ();

			var relatedPair = new Dictionary<uint, uint[]> () { { articleCode,  articleList} };

			var relatedDict = initialDict.Union(relatedPair).ToDictionary(key => key.Key, val => val.Value);

			return relatedDict;
		}

		private static void VerifyCircularDependency (uint articleCode, uint[] articlePath)
		{
			bool articlesCircle = (articlePath.Count (x => (x == articleCode)) > 0);

			if (articlesCircle) {
				throw new EngineProcessCircleException ("Circular article reference", articlePath, articleCode);
			}
		}
	}
}

