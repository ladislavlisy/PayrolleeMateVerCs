using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Factories;
using System.Linq;
using PayrolleeMate.ProcessService.Interfaces;
using System.Reflection;
using Payrollee.Common.Collection;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Logers;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public abstract class PayrollConceptCollection<CIDX> : GeneralCollection<IPayrollConcept, CIDX>
	{
		static class ArticleDependencyBuilder
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

			private static IPayrollArticle[] FindArticlesInDictionary (IDictionary<uint, IPayrollArticle[]> articlesDict, IPayrollArticle article)
			{
				IPayrollArticle[] articlePending = null;

				uint conceptCode = article.ConceptCode();

				bool existsInDictionary = articlesDict.TryGetValue(conceptCode, out articlePending);

				if (existsInDictionary)
				{
					return articlePending;
				}
				return new IPayrollArticle[0];
			}
		}

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

			UpdateRelatedArticles(relatedArticles, logger);

			LoggerWrapper.LogConceptsInModels (logger, Models, "InitRelatedArticles.Models");

			LoggerWrapper.LogRelatedArticlesInModels (logger, Models, "InitRelatedArticles.Related");
		}

		public IDictionary<uint, IPayrollArticle[]> ModelsToPendings()
		{
			var pendingArticles = Models.ToDictionary(key => key.Key, val => val.Value.PendingArticles());

			return pendingArticles.Where(kvp => kvp.Value.Length != 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
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

