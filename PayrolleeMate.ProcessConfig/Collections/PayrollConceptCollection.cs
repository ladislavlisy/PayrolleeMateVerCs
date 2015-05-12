﻿using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Factories;
using System.Linq;
using PayrolleeMate.ProcessService.Interfaces;
using System.Reflection;
using Payrollee.Common.Collection;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public abstract class PayrollConceptCollection<CIDX> : GeneralCollection<IPayrollConcept, CIDX>
	{
		static class ArticleCollectionAggregator
		{
			public static IDictionary<uint, IPayrollArticle[]> CollectArticles(
				IDictionary<uint, IPayrollArticle[]> pendingDict)
			{
				var initialDict = new Dictionary<uint, IPayrollArticle[]>();

				var relatedDict = pendingDict.Aggregate(initialDict,
					(agr, pair) => CollectArticlesForConcept(agr, 
						pair.Key, pair.Value, pendingDict).ToDictionary(key => key.Key, val => val.Value));

				#if (LOG_ENABLED)
				ArticlesLogger.LogConceptArticlesCollection(relatedDict, "CollectRelatedCollection");
				#endif

				return relatedDict;
			}

			private static IDictionary<uint, IPayrollArticle[]> CollectArticlesForConcept(
				IDictionary<uint, IPayrollArticle[]> initialDict, 
				uint conceptCode, IPayrollArticle[] pendingArticles, 
				IDictionary<uint, IPayrollArticle[]> pendingDict)
			{
				var resultDict = CollectRelatedArticlesFromList(initialDict, conceptCode, pendingArticles, pendingDict);

				#if (LOG_ENABLED)
				ArticlesLogger.LogConceptCodeArticles(code, resultDict, "ConceptArticles");
				#endif

				var relatedDict = MergeIntoDictionary(initialDict, conceptCode, resultDict);

				return relatedDict;
			}

			private static IDictionary<uint, IPayrollArticle[]> MergeIntoDictionary(
				IDictionary<uint, IPayrollArticle[]> initialDict, 
				uint conceptCode, IPayrollArticle[] relatedArticles)
			{
				var mergeArticles = new Dictionary<uint, IPayrollArticle[]> () {
					{ conceptCode, relatedArticles.Distinct ().OrderBy (x => x).ToArray () }
				};

				var relatedDict = initialDict.Union(mergeArticles).ToDictionary(key => key.Key, val => val.Value);

				return relatedDict;
			}

			private static IPayrollArticle[] CollectRelatedArticlesFromList(IDictionary<uint, IPayrollArticle[]> initialDict,
				uint conceptCode, IPayrollArticle[] pendingArticles, IDictionary<uint, IPayrollArticle[]> pendingDict)
			{
				var relatedDict = pendingArticles.Aggregate(new IPayrollArticle[0],
					(agr, article) => agr.Concat(CollectRelatedArticlesFromDict(initialDict, article, pendingDict)).ToArray());
				
				return relatedDict;
			}

			private static IPayrollArticle[] CollectRelatedArticlesFromDict(IDictionary<uint, IPayrollArticle[]> initialDict, 
				IPayrollArticle article, IDictionary<uint, IPayrollArticle[]> pendingDict)
			{
				var relatedArticles = CollectFromRelated (initialDict, article, pendingDict);

				bool existsRelated = relatedArticles != null;

				if (existsRelated) 
				{
					#if (LOG_ENABLED)
					ArticlesLogger.LogRelatedArticles(article, articleRelated, "CollectFromRelated");
					#endif
					return relatedArticles;
				}
				else 
				{
					relatedArticles = CollectFromPending (initialDict, article, pendingDict);
					#if (LOG_ENABLED)
					ArticlesLogger.LogPendingArticles(article, articleRelated, "CollectFromPending");
					#endif
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
				IPayrollArticle article, IDictionary<uint, IPayrollArticle[]> pendingDict)
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
					(agr, articleSource) => agr.Concat(CollectRelatedArticlesFromDict(relatedDict, articleSource, pendingDict)).ToArray());

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

		#endregion

		public void InitRelatedArticles()
		{
			var pendingArticles = ModelsToPendings();

			var relatedArticles = ArticleCollectionAggregator.CollectArticles(pendingArticles);

			UpdateRelatedArticles(relatedArticles);

			#if (LOG_ENABLED)
			LogConceptModels();
			#endif
		}

		public IDictionary<uint, IPayrollArticle[]> ModelsToPendings()
		{
			var pendingArticles = Models.ToDictionary(key => key.Key, val => val.Value.PendingArticles());

			return pendingArticles.Where(kvp => kvp.Value.Length != 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
		}

		#if (LOG_ENABLED)
		private void LogConceptModels()
		{
			ConceptsLogger.LogModels(Models, "ConceptsDefinitions");

			RelatedLogger.LogModels(Models, "RelatedDefinitions");
		}
		#endif

		private void UpdateRelatedArticles(IDictionary<uint, IPayrollArticle[]> relatedDict)
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
				#if (LOG_ENABLED)
				ArticlesLogger.LogConceptArticles(conceptVal, relatedArray, "UpdateRelatedArticles");
				#endif
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

