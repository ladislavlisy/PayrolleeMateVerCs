using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using System.Linq;
using PayrolleeMate.ProcessService.Interfaces;
using System.Reflection;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public class PayrollConceptCollection
	{
		static class ArticleCollectionAggregator
		{
			public static IDictionary<ConceptSymbolCode, IPayrollArticle[]> CollectArticles(
				IDictionary<ConceptSymbolCode, IPayrollArticle[]> pendingDict)
			{
				var initialDict = new Dictionary<ConceptSymbolCode, IPayrollArticle[]>();

				var relatedDict = pendingDict.Aggregate(initialDict,
					(agr, pair) => CollectArticlesForConcept(agr, 
						pair.Key, pair.Value, pendingDict).ToDictionary(key => key.Key, val => val.Value));

				#if (LOG_ENABLED)
				ArticlesLogger.LogConceptArticlesCollection(relatedDict, "CollectRelatedCollection");
				#endif

				return relatedDict;
			}

			private static IDictionary<ConceptSymbolCode, IPayrollArticle[]> CollectArticlesForConcept(
				IDictionary<ConceptSymbolCode, IPayrollArticle[]> initialDict, 
				ConceptSymbolCode conceptCode, IPayrollArticle[] pendingArticles, 
				IDictionary<ConceptSymbolCode, IPayrollArticle[]> pendingDict)
			{
				var resultDict = CollectRelatedArticlesFromList(initialDict, conceptCode, pendingArticles, pendingDict);

				#if (LOG_ENABLED)
				ArticlesLogger.LogConceptCodeArticles(code, resultDict, "ConceptArticles");
				#endif

				var relatedDict = MergeIntoDictionary(initialDict, conceptCode, resultDict);

				return relatedDict;
			}

			private static IDictionary<ConceptSymbolCode, IPayrollArticle[]> MergeIntoDictionary(
				IDictionary<ConceptSymbolCode, IPayrollArticle[]> initialDict, 
				ConceptSymbolCode conceptCode, IPayrollArticle[] relatedArticles)
			{
				var mergeArticles = new Dictionary<ConceptSymbolCode, IPayrollArticle[]> () {
					{ conceptCode, relatedArticles.Distinct ().OrderBy (x => x).ToArray () }
				};

				var relatedDict = initialDict.Union(mergeArticles).ToDictionary(key => key.Key, val => val.Value);

				return relatedDict;
			}

			private static IPayrollArticle[] CollectRelatedArticlesFromList(IDictionary<ConceptSymbolCode, IPayrollArticle[]> initialDict,
				ConceptSymbolCode conceptCode, IPayrollArticle[] pendingArticles, IDictionary<ConceptSymbolCode, IPayrollArticle[]> pendingDict)
			{
				var relatedDict = pendingArticles.Aggregate(new IPayrollArticle[0],
					(agr, article) => agr.Concat(CollectRelatedArticlesFromDict(initialDict, article, pendingDict)).ToArray());
				
				return relatedDict;
			}

			private static IPayrollArticle[] CollectRelatedArticlesFromDict(IDictionary<ConceptSymbolCode, IPayrollArticle[]> initialDict, 
				IPayrollArticle article, IDictionary<ConceptSymbolCode, IPayrollArticle[]> pendingDict)
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

			private static IPayrollArticle[] CollectFromRelated(IDictionary<ConceptSymbolCode, IPayrollArticle[]> relatedDict, 
				IPayrollArticle article, IDictionary<ConceptSymbolCode, IPayrollArticle[]> pendingDict)
			{
				ConceptSymbolCode conceptCode = (ConceptSymbolCode)Enum.ToObject (typeof(ConceptSymbolCode), article.ConceptCode());

				bool skipExecToPending = !relatedDict.ContainsKey(conceptCode);

				if (skipExecToPending)
				{
					return null;
				}

				var initialArticles = new IPayrollArticle[] { article };

				var relatedArticles = FindArticlesInDictionary(relatedDict, article);

				return initialArticles.Concat(relatedArticles).ToArray();
			}

			private static IPayrollArticle[] CollectFromPending(IDictionary<ConceptSymbolCode, IPayrollArticle[]> relatedDict, 
				IPayrollArticle article, IDictionary<ConceptSymbolCode, IPayrollArticle[]> pendingDict)
			{
				ConceptSymbolCode conceptCode = (ConceptSymbolCode)Enum.ToObject (typeof(ConceptSymbolCode), article.ConceptCode());

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

			private static IPayrollArticle[] FindArticlesInDictionary (IDictionary<ConceptSymbolCode, IPayrollArticle[]> articlesDict, IPayrollArticle article)
			{
				IPayrollArticle[] articlePending = null;

				ConceptSymbolCode conceptCode = (ConceptSymbolCode)Enum.ToObject (typeof(ConceptSymbolCode), article.ConceptCode());

				bool existsInDictionary = articlesDict.TryGetValue(conceptCode, out articlePending);

				if (existsInDictionary)
				{
					return articlePending;
				}
				return new IPayrollArticle[0];
			}
		}

		public PayrollConceptCollection()
		{
			this.Models = new Dictionary<ConceptSymbolCode, IPayrollConcept>();

			this.Models[ConceptSymbolCode.CONCEPT_UNKNOWN] = new UnknownConcept();
		}

		public IDictionary<ConceptSymbolCode, IPayrollConcept> Models { get; private set; }

		#region Concept Dictionary

		public IPayrollConcept ArticleConceptFromModels(Assembly assemblyConfigSet, IPayrollArticle article)
		{
			IPayrollConcept baseConcept = ConceptFromModels(assemblyConfigSet, article.ConceptCode());

			return baseConcept;
		}

		public IPayrollConcept ConceptFromModels(Assembly assemblyConfigSet, uint conceptCode)
		{
			ConceptSymbolCode conceptIndex = (ConceptSymbolCode)conceptCode;

			IPayrollConcept baseConcept = null;

			if (!Models.ContainsKey(conceptIndex))
			{
				baseConcept = EmptyConceptFor(assemblyConfigSet, conceptCode);

				Models[conceptIndex] = baseConcept;
			}
			else
			{
				baseConcept = Models[conceptIndex];
			}
			return baseConcept;
		}

		public IPayrollConcept FindConcept(uint conceptCode)
		{
			ConceptSymbolCode conceptIndex = (ConceptSymbolCode)conceptCode;

			IPayrollConcept baseConcept = null;

			if (Models.ContainsKey(conceptIndex))
			{
				baseConcept = Models[conceptIndex];
			}
			else
			{
				baseConcept = Models[ConceptSymbolCode.CONCEPT_UNKNOWN];
			}
			return baseConcept;
		}

		public IPayrollConcept EmptyConceptFor(Assembly assemblyConfigSet, uint conceptCode)
		{
			ConceptSymbolCode conceptIndex = (ConceptSymbolCode)conceptCode;

			SymbolName conceptSymbol = conceptIndex.GetSymbol ();

			IPayrollConcept emptyConcept = PayrollConceptFactory.ConceptFor(assemblyConfigSet, conceptSymbol.Name);

			return emptyConcept;
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

		public IDictionary<ConceptSymbolCode, IPayrollArticle[]> ModelsToPendings()
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

		private void UpdateRelatedArticles(IDictionary<ConceptSymbolCode, IPayrollArticle[]> relatedDict)
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
	}
}

