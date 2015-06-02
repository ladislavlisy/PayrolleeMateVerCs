using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Collections;
using System.Linq;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessConfig.Builders
{
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
}

