using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using PayrolleeMate.Common;
using PayrolleeMate.Common.Collection;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Builders;
using PayrolleeMate.ProcessConfig.Logers;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public abstract class PayrollConceptCollection<CIDX> : GeneralCollection<IPayrollConcept, CIDX>
	{
		public PayrollConceptCollection() : base()
		{
		}

		#region Concept Dictionary

		public IPayrollConcept ArticleConceptFromModels(Assembly configAssembly, IPayrollArticle article)
		{
			IPayrollConcept baseConcept = ConceptFromModels(configAssembly, article.ConceptCode());

			return baseConcept;
		}

		public IPayrollConcept ConceptFromModels(Assembly configAssembly, uint conceptCode)
		{
			IPayrollConcept baseConcept = InstanceFromModels(configAssembly, conceptCode);

			return baseConcept;
		}

		public IPayrollConcept FindConcept(uint conceptCode)
		{
			IPayrollConcept baseConcept = FindInstanceForCode(conceptCode);

			return baseConcept;
		}

		public IPayrollConcept ConfigureConcept (SymbolName concept, ProcessCategory category, 
			IPayrollArticle[] pendingArticles, IPayrollArticle[] summaryArticles, string targetValues, string resultValues, 
			GeneralPayrollConcept.EvaluateDelegate evaluate)
		{
			IPayrollConcept conceptInstance = GeneralPayrollConcept.CreateConcept (
				concept, category, pendingArticles, summaryArticles, targetValues, resultValues, evaluate);

			return ConfigureModel (conceptInstance, concept.Code);
		}

		#endregion

		public void InitRelatedArticles(IProcessConfigLogger logger)
		{
			var pendingArticles = ModelsToPendings();

			var relatedArticles = ArticleDependencyBuilder.CollectArticles(pendingArticles, logger);

			var relatedSortList = BuildSortedRelatedArticleDict (relatedArticles);

			UpdateRelatedArticles (relatedSortList, logger);

			LoggerWrapper.LogConceptsInModels (logger, Models, "InitRelatedArticles.Models");

			LoggerWrapper.LogRelatedArticlesInModels (logger, Models, "InitRelatedArticles.Related");
		}

		private IDictionary<uint, IPayrollArticle[]> ModelsToPendings()
		{
			var pendingArticles = Models.ToDictionary(key => key.Key, val => val.Value.PendingArticles());

			return pendingArticles.Where(kvp => kvp.Value.Length != 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
		}

		private Tuple<IPayrollConcept, IPayrollArticle>[] BuildConceptArticleTuple (IPayrollArticle[] articleList)
		{
			Tuple<IPayrollConcept, IPayrollArticle>[] conceptArticleList = 
				articleList.Select (x => (Tuple.Create (FindConcept (x.ConceptCode ()), x))).ToArray();

			return conceptArticleList;
		}

		private KeyValuePair<uint, IPayrollArticle[]> BuildSortedRelatedArticleList (uint conceptCode, 
			IPayrollArticle[] articleList, IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			if (articleList != null) 
			{
				var pairedList = BuildConceptArticleTuple (articleList);

				var sortedList = ArticleDependencyBuilder.SortDependecyArticles (relatedDict, pairedList);

				return new KeyValuePair<uint, IPayrollArticle[]> (conceptCode, sortedList);
			}
			else 
			{
				return new KeyValuePair<uint, IPayrollArticle[]> (conceptCode, articleList);
			}
		}

		private IDictionary<uint, IPayrollArticle[]> BuildSortedRelatedArticleDict(IDictionary<uint, IPayrollArticle[]> relatedDict)
		{
			var sortedRelatedArticles = relatedDict.Select((x) => (BuildSortedRelatedArticleList(x.Key, x.Value, relatedDict))).
				ToDictionary(key => key.Key, val => val.Value);

			return sortedRelatedArticles;
		}

		private void UpdateRelatedArticles(IDictionary<uint, IPayrollArticle[]> relatedDict, IProcessConfigLogger logger)
		{
			foreach (var concept in Models)
			{
				var conceptCode = concept.Key;

				var conceptItem = concept.Value;

				IPayrollArticle[] relatedArticles = null;

				bool existInDictionary = relatedDict.TryGetValue(conceptCode, out relatedArticles);

				if (existInDictionary)
				{
					conceptItem.UpdateRelatedArticles(relatedArticles);
				}
				else
				{
					conceptItem.UpdateRelatedArticles(new IPayrollArticle[0]);
				}

				LoggerWrapper.LogArticlesInConcept (logger, conceptItem, relatedArticles, "UpdateRelatedArticles");
			}
		}

		#region implemented abstract members of GeneralCollection

		protected override IPayrollConcept InstanceFor (Assembly configAssembly, SymbolName configSymbol)
		{
			IPayrollConcept emptyConcept = PayrollConceptFactory.ConceptFor(configAssembly, configSymbol.Name);

			return emptyConcept;
		}

		#endregion

	}
}

