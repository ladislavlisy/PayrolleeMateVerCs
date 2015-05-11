using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Collections;
using System.Reflection;

namespace PayrolleeMate.ProcessConfig
{
	public abstract class ProcessConfigModule : IProcessConfig
	{
		protected ProcessConfigModule ()
		{
			ArticlesCollection = new PayrollArticleCollection();

			ConceptsCollection = new PayrollConceptCollection();
		}

		public PayrollArticleCollection ArticlesCollection { get; private set; }

		public PayrollConceptCollection ConceptsCollection { get; private set; }

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

		public abstract void InitArticles ();

		public abstract void InitConcepts ();

		public void InitModule()
		{
			InitArticles();
			InitConcepts();

			ConceptsCollection.InitRelatedArticles();
		}
	}
}

