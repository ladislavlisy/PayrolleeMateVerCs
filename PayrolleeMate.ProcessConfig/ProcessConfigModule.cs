﻿using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Collections;
using System.Reflection;
using PayrolleeMate.Common.Core;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Logers;
using PayrolleeMate.Common.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace PayrolleeMate.ProcessConfig
{
	public abstract class ProcessConfigModule<AIDX, CIDX> : IProcessConfig
	{
		protected static readonly SymbolName[] EMPTY_PENDING_NAMES = GeneralPayrollArticle.EMPTY_ARTICLE_NAMES;

		protected static readonly SymbolName[] EMPTY_SUMMARY_NAMES = GeneralPayrollArticle.EMPTY_ARTICLE_NAMES;

		protected static readonly uint[] EMPTY_PENDING_CODES = { };

		protected static readonly uint[] EMPTY_SUMMARY_CODES = { };

		protected ProcessConfigModule (IProcessConfigLogger logger)
		{
			Logger = logger;
		}

		protected IProcessConfigLogger Logger { get; private set; }

		public PayrollArticleCollection<AIDX> ArticlesCollection { get; protected set; }

		public PayrollConceptCollection<CIDX> ConceptsCollection { get; protected set; }

		public IPayrollArticle[] ArticleList ()
		{
			return ArticlesCollection.Models.Select(x => x.Value).ToArray();
		}

		public IDictionary<uint, IPayrollArticle> ArticleModels ()
		{
			return ArticlesCollection.Models.ToDictionary(key => key.Key, val => val.Value);
		}

		public IPayrollConcept[] ConceptList ()
		{
			return ConceptsCollection.Models.Select(x => x.Value).ToArray();
		}

		public IDictionary<uint, IPayrollConcept> ConceptModels ()
		{
			return ConceptsCollection.Models.ToDictionary(key => key.Key, val => val.Value);
		}

		public IPayrollArticle ArticleFromModels(Assembly assemblyConfigSet, uint articleCode)
		{
			return ArticlesCollection.ArticleFromModels(assemblyConfigSet, articleCode);
		}

		public IPayrollArticle FindArticle(uint articleCode)
		{
			return ArticlesCollection.FindArticle(articleCode);
		}

		public IPayrollConcept ArticleConceptFromModels(Assembly assemblyConfigSet, IPayrollArticle article)
		{
			return ConceptsCollection.ArticleConceptFromModels(assemblyConfigSet, article);
		}

		public IPayrollConcept ConceptFromModels(Assembly assemblyConfigSet, uint conceptCode)
		{
			return ConceptsCollection.ConceptFromModels(assemblyConfigSet, conceptCode);
		}

		public IPayrollConcept FindConcept(uint conceptCode)
		{
			return ConceptsCollection.FindConcept(conceptCode);
		}

		public IPayrollArticle ConfigureArticle (SymbolName article, 
			SymbolName concept, ProcessCategory category, 
			SymbolName[] pendingNames, SymbolName[] summaryNames,
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts)
		{
			return ArticlesCollection.ConfigureArticle (
				article, concept, category, pendingNames, summaryNames,
				taxingIncome, healthIncome, socialIncome, grossSummary, nettoSummary, nettoDeducts);
		}

		public IPayrollConcept ConfigureConcept (SymbolName concept, 
			bool nodeContract, bool nodePosition, bool qualContract, bool qualPosition,
			string targetValues, string resultValues, 
			GeneralModule.EvaluateDelegate evaluate)
		{
			return ConceptsCollection.ConfigureConcept (
				concept, nodeContract, nodePosition, qualContract, qualPosition,
				targetValues, resultValues, evaluate);
		}

		public abstract void InitArticles ();

		public abstract void InitConcepts ();

		public void InitModule()
		{
			InitArticles();
			InitConcepts();

			ArticlesCollection.InitRelatedArticles(Logger);

			LoggerWrapper.LogConceptsInModels (Logger, ArticlesCollection.Models, ConceptsCollection.Models, "InitRelatedArticles.Models");
		
			LoggerWrapper.LogRelatedArticlesInModels (Logger, ArticlesCollection.Models, "InitRelatedArticles.Related");
		}
	}
}

