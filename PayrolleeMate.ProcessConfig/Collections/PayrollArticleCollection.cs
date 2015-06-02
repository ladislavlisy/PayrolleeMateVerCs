using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using PayrolleeMate.Common;
using PayrolleeMate.Common.Collection;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Logers;
using PayrolleeMate.ProcessConfig.Builders;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public abstract class PayrollArticleCollection<AIDX> : GeneralCollection<IPayrollArticle, AIDX>
	{
		public static readonly IPayrollArticle[] EMPTY_ARTICLE_LIST = {};

		public static readonly uint[] EMPTY_ARTICLE_CODE_LIST = {};

		public PayrollArticleCollection() : base()
		{
		}

		public IPayrollArticle ArticleFromModels(Assembly configAssembly, uint articleCode)
		{
			IPayrollArticle baseArticle = InstanceFromModels(configAssembly, articleCode);

			return baseArticle;
		}

		public IPayrollArticle FindArticle(uint articleCode)
		{
			IPayrollArticle baseArticle = FindInstanceForCode(articleCode);

			return baseArticle;
		}

		public IPayrollArticle ConfigureArticle (SymbolName article, SymbolName concept, ProcessCategory category, 
			SymbolName[] pendingNames, SymbolName[] summaryNames,
			bool taxingIncome, bool healthIncome, bool socialIncome, bool grossSummary, bool nettoSummary, bool nettoDeducts)
		{
			IPayrollArticle articleInstance = GeneralPayrollArticle.CreateArticle (
				article, concept, category, pendingNames, summaryNames,
				taxingIncome, healthIncome, socialIncome, grossSummary, nettoSummary, nettoDeducts);

			return ConfigureModel (articleInstance, article.Code);
		}

		#region implemented abstract members of GeneralCollection

		protected override IPayrollArticle InstanceFor(Assembly configAssembly, SymbolName configSymbol)
		{
			IPayrollArticle emptyArticle = PayrollArticleFactory.ArticleFor(configAssembly, configSymbol.Name);

			return emptyArticle;
		}

		#endregion

		public void InitRelatedArticles(IProcessConfigLogger logger)
		{
			var pendingArticles = ArticleCodeListBuilder<AIDX>.BuildPendingCodesDict (this);

			var initialArticles = ArticleCodeListBuilder<AIDX>.BuildRelatedCodesDict (this);

			var relatedArticles = ArticleDependencyBuilder.CollectArticles (pendingArticles, initialArticles, logger);

			var relatedInitList = ArticleObjectListBuilder<AIDX>.BuildRelatedArticleDict (relatedArticles, this);

			var relatedSortList = ArticleSortoutBuilder.BuildSortedArticleDict (relatedInitList);

			UpdateRelatedArticles (relatedSortList, logger);
		}

		private void UpdateRelatedArticles(IDictionary<uint, IPayrollArticle[]> relatedDict, IProcessConfigLogger logger)
		{
			foreach (var article in Models)
			{
				var articleCode = article.Key;

				var articleItem = article.Value;

				IPayrollArticle[] relatedArticles = null;

				bool existInDictionary = relatedDict.TryGetValue(articleCode, out relatedArticles);

				if (existInDictionary)
				{
					articleItem.UpdateRelatedArticles(relatedArticles);
				}
				else
				{
					articleItem.UpdateRelatedArticles(EMPTY_ARTICLE_LIST);
				}

				LoggerWrapper.LogListArticlesUnderArticle (logger, articleItem, relatedArticles, "UpdateRelatedArticles");
			}
		}
	}
}

