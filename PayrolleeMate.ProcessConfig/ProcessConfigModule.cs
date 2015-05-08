using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Collections;

namespace PayrolleeMate.ProcessConfig
{
	public class ProcessConfigModule : IProcessConfig
	{
		public static IProcessConfig CreateModule()
		{
			IProcessConfig config = new ProcessConfigModule ();

			return config;
		}

		private ProcessConfigModule ()
		{
			ArticlesCollection = new PayrollArticleCollection();

			ConceptsCollection = new PayrollConceptCollection();
		}

		public PayrollArticleCollection ArticlesCollection { get; private set; }

		public PayrollConceptCollection ConceptsCollection { get; private set; }

		public IPayrollArticle ArticleFromModels(uint articleCode)
		{
			return ArticlesCollection.ArticleFromModels(articleCode);
		}

		public IPayrollArticle FindArticle(uint articleCode)
		{
			return ArticlesCollection.FindArticle(articleCode);
		}

		public IPayrollConcept ArticleConceptFromModels(IPayrollArticle article)
		{
			return ConceptsCollection.ArticleConceptFromModels(article);
		}

		public IPayrollConcept ConceptFromModels(uint conceptCode)
		{
			return ConceptsCollection.ConceptFromModels(conceptCode);
		}

		public IPayrollConcept FindConcept(uint conceptCode)
		{
			return ConceptsCollection.FindConcept(conceptCode);
		}

		public void InitArticles()
		{
		}

		public void InitConcepts()
		{
		}

		public void InitModule()
		{
			InitArticles();
			InitConcepts();

			ConceptsCollection.InitRelatedArticles();
		}
	}
}

