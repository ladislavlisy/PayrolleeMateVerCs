using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Collections;

namespace PayrolleeMate.ProcessConfig
{
	public class ProcessConfig : IProcessConfig
	{
		public ProcessConfig ()
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

		public void InitArticlesAndConcepts()
		{
			InitArticles();
			InitConcepts();

			ConceptsCollection.InitRelatedArticles();
		}
	}
}

