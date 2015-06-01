using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using System.Linq;
using PayrolleeMate.ProcessConfig.Logers;
using PayrolleeMate.ProcessConfig.General;

namespace PayrolleeMate.ProcessConfig.Builders
{
	public static class ArticleRelatedBuilder
	{
		public static readonly IPayrollArticle[] EMPTY_ARTICLES = {};

		public static IDictionary<uint, IPayrollArticle[]> CollectArticles(
			IDictionary<uint, IPayrollArticle[]> dependencyDict, IProcessConfigLogger logger)
		{
			var relatedDict = new Dictionary<uint, IPayrollArticle[]> ();

			var articleCodes = dependencyDict.Keys;

			uint pendingCode = 0;

			IPayrollArticle[] pendingList = new IPayrollArticle[0];

			var collectedDict = articleCodes.Aggregate(relatedDict,
				(agr, code) => CollectRelatedArticles(agr, 
					pendingCode, pendingList, code, dependencyDict, logger).
						ToDictionary(key => key.Key, val => val.Value));

			return collectedDict;
		}
			
		private static IDictionary<uint, IPayrollArticle[]> CollectRelatedArticles(
			IDictionary<uint, IPayrollArticle[]> relatedInit, 
			uint pendingCode, IPayrollArticle[] pendingList, uint articleCode, 
			IDictionary<uint, IPayrollArticle[]> dependencyDict, IProcessConfigLogger logger)
		{
			if (articleCode == 0) 
			{
				IPayrollArticle[] initialList = (IPayrollArticle[]) pendingList.Clone();

				var composeList = pendingList.Aggregate(initialList, 
					(agrList, article) => ComposeRelatedArticles(agrList, article, relatedInit)).ToArray();

				return MergeIntoDictionary(relatedInit, pendingCode, composeList);
			}

			bool relatedExists = relatedInit.ContainsKey (articleCode);

			if (relatedExists == true) 
			{
				return relatedInit;
			}
		
			IPayrollArticle[] articleList = dependencyDict.FirstOrDefault (x => x.Key == articleCode).Value;

			if (articleList == null || articleList.Length == 0) 
			{
				return MergeIntoDictionary(relatedInit, articleCode, EMPTY_ARTICLES);
			}

			uint[] articleCodes = articleList.Select (x => x.ArticleCode ()).Concat (new uint[] { 0 }).ToArray (); 

			var collectedDict = articleCodes.Aggregate(relatedInit, 
				(agr, code) => CollectRelatedArticles(agr, 
					articleCode, articleList, code, dependencyDict, logger).
						ToDictionary(key => key.Key, val => val.Value));
			
			return collectedDict;
		}

		private static IPayrollArticle[] ComposeRelatedArticles (IPayrollArticle[] initialList, IPayrollArticle article, IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			IPayrollArticle[] articleList = relatedDict.FirstOrDefault (x => x.Key == article.ArticleCode()).Value;

			return initialList.Concat(articleList).ToArray();
		}

		private static uint[] PendingCodesFromCollection(IDictionary<uint, IPayrollArticle[]> pendingDict, uint articleCode)
		{
			IPayrollArticle[] articleList = pendingDict.FirstOrDefault (x => x.Key == articleCode).Value;

			uint[] pendingList = articleList.Select (x => x.ArticleCode() ).ToArray();

			return pendingList;
		}

		private static IDictionary<uint, IPayrollArticle[]> MergeIntoDictionary(
			IDictionary<uint, IPayrollArticle[]> initialDict, 
			uint articleCode, IPayrollArticle[] relatedArticles)
		{
			var articleList = relatedArticles.Distinct ().OrderBy (x => x.ArticleSymbol ()).ToArray ();

			var relatedPair = new Dictionary<uint, IPayrollArticle[]> () { { articleCode,  articleList} };

			var relatedDict = initialDict.Union(relatedPair).ToDictionary(key => key.Key, val => val.Value);

			return relatedDict;
		}

	}
}

