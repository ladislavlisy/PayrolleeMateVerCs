using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Linq;
using PayrolleeMate.ProcessConfig.Collections;

namespace PayrolleeMate.ProcessConfig.Builders
{
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
}

