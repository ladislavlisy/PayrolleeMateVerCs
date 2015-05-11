using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollConcept : SymbolName, IPayrollConcept
	{
		public static readonly IPayrollArticle[] EMPTY_ARTICLES = {};

		public static readonly char[] VALUES_SEPARATOR = { ',' };

		public GeneralPayrollConcept (SymbolName concept, IPayrollArticle[] pendingArticles, IPayrollArticle[] summaryArticles, 
			ProcessCategory category, string targetValues) : base(concept.Code, concept.Name)
		{
			__targetValues = targetValues.Split(VALUES_SEPARATOR);

			__relatedArticles = EMPTY_ARTICLES;

			__pendingArticles = (IPayrollArticle[])pendingArticles.Clone();

			__summaryArticles = (IPayrollArticle[])summaryArticles.Clone();

			__category = category;

		}

		private string[] __targetValues;

		private IPayrollArticle[] __relatedArticles = EMPTY_ARTICLES;

		private IPayrollArticle[] __pendingArticles = EMPTY_ARTICLES;

		private IPayrollArticle[] __summaryArticles = EMPTY_ARTICLES;

		private ProcessCategory __category = ProcessCategory.CATEGORY_START;

		#region IPayrollConcept implementation

		public uint ConceptCode ()
		{
			return this.Code;
		}

		public string ConceptName ()
		{
			return this.Name;
		}

		public string[] TargetValues ()
		{
			return __targetValues;
		}

		public IPayrollArticle[] RelatedArticles ()
		{
			return __relatedArticles;
		}

		public IPayrollArticle[] PendingArticles ()
		{
			return __pendingArticles;
		}

		public IPayrollArticle[] SummaryArticles ()
		{
			return __summaryArticles;
		}

		public ProcessCategory Category ()
		{
			return __category;
		}

		public void UpdateRelatedArticles (IPayrollArticle[] articles)
		{
			this.__relatedArticles = null;
			if (articles != null)
			{
				this.__relatedArticles = (IPayrollArticle[])articles.Clone();
			}
		}

		#endregion
	}
}

