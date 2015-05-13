using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Collections;
using System.Reflection;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;

namespace PayrolleeMate.ProcessConfig
{
	public abstract class ProcessConfigModule<AIDX, CIDX> : IProcessConfig
	{
		protected static readonly IPayrollArticle[] EMPTY_PENDING_ARTICLES = GeneralPayrollConcept.EMPTY_ARTICLES;

		protected static readonly IPayrollArticle[] EMPTY_SUMMARY_ARTICLES = GeneralPayrollConcept.EMPTY_ARTICLES;

		protected static readonly uint[] EMPTY_PENDING_CODES = { };

		protected static readonly uint[] EMPTY_SUMMARY_CODES = { };

		protected ProcessConfigModule (IProcessConfigLogger logger)
		{
			Logger = logger;
		}

		protected IProcessConfigLogger Logger { get; private set; }

		public PayrollArticleCollection<AIDX> ArticlesCollection { get; protected set; }

		public PayrollConceptCollection<CIDX> ConceptsCollection { get; protected set; }

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

		public IPayrollArticle ConfigureArticle (SymbolName article, SymbolName concept, 
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts)
		{
			return ArticlesCollection.ConfigureArticle (
				article, concept, taxingIncome, healthIncome, socialIncome, grossSummary, nettoSummary, nettoDeducts);
		}

		public IPayrollConcept ConfigureConcept (SymbolName concept, ProcessCategory category, 
			uint[] pendingArticleCodes, uint[] summaryArticleCodes, 
			string targetValues, string resultValues, GeneralPayrollConcept.EvaluateDelegate evaluate)
		{
			IPayrollArticle[] pendingArticles = ArticlesCollection.BildArticlesList(pendingArticleCodes);

			IPayrollArticle[] summaryArticles = ArticlesCollection.BildArticlesList(summaryArticleCodes);

			return ConceptsCollection.ConfigureConcept (
				concept, category, pendingArticles, summaryArticles, targetValues, resultValues, evaluate);
		}

		public abstract void InitArticles ();

		public abstract void InitConcepts ();

		public void InitModule()
		{
			InitArticles();
			InitConcepts();

			ConceptsCollection.InitRelatedArticles(Logger);
		}
	}
}

