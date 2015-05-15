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
			var pendingArticles = ModelsToPendings();

			var relatedArticles = ArticleDependencyBuilder.CollectArticles(pendingArticles, logger);

			var relatedSortList = BuildSortedRelatedArticleDict (relatedArticles);

			UpdateRelatedArticles (relatedSortList, logger);
		}

		private IPayrollArticle[] BuildArticlesList(SymbolName[] articleNames)
		{
			var articleList = articleNames.Select (x => (FindArticle (x.Code))).ToArray ();

			return articleList;
		}

		private IDictionary<uint, IPayrollArticle[]> ModelsToPendings()
		{
			var pendingArticles = Models.ToDictionary(key => key.Key, val => BuildArticlesList(val.Value.PendingArticleNames()));

			var noemptyArticles = pendingArticles.Where (kvp => kvp.Value.Length != 0).ToDictionary (kvp => kvp.Key, kvp => kvp.Value);

			return noemptyArticles;
		}

		private IDictionary<uint, IPayrollArticle[]> BuildSortedRelatedArticleDict(IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			var sortedRelatedArticles = relatedDict.Select((x) => (BuildSortedRelatedArticleList(x.Key, x.Value, relatedDict))).
				ToDictionary(key => key.Key, val => val.Value);

			return sortedRelatedArticles;
		}

		private KeyValuePair<uint, IPayrollArticle[]> BuildSortedRelatedArticleList (uint conceptCode, 
			IPayrollArticle[] articleList, IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			if (articleList != null) 
			{
				var sortedList = ArticleDependencyBuilder.SortDependecyArticles (relatedDict, articleList);

				return new KeyValuePair<uint, IPayrollArticle[]> (conceptCode, sortedList);
			}
			else 
			{
				return new KeyValuePair<uint, IPayrollArticle[]> (conceptCode, articleList);
			}
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
					articleItem.UpdateRelatedArticles(new IPayrollArticle[0]);
				}

				LoggerWrapper.LogArticlesInConcept (logger, articleItem, relatedArticles, "UpdateRelatedArticles");
			}
		}
		}
}

