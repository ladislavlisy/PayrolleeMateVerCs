using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollConcept : SymbolName, IPayrollConcept
	{
		public delegate IResultStream EvaluateDelegate (IProcessConfig config, IEngineProfile engine, IBookIndex element, IResultStream results);

		public static readonly IPayrollArticle[] EMPTY_ARTICLES = {};

		public static readonly char[] VALUES_SEPARATOR = { ',' };

		public static IPayrollConcept CreateConcept (SymbolName concept, ProcessCategory category, 
			IPayrollArticle[] pendingArticles, IPayrollArticle[] summaryArticles, 
			string targetValues, string resultValues, EvaluateDelegate evaluate)
		{
			IPayrollConcept conceptInstance = new GeneralPayrollConcept (concept, category, 
				pendingArticles, summaryArticles, targetValues, resultValues, evaluate);

			return conceptInstance;
		}

		public GeneralPayrollConcept (SymbolName concept, ProcessCategory category, 
			IPayrollArticle[] pendingArticles, IPayrollArticle[] summaryArticles, 
			string targetValues, string resultValues, EvaluateDelegate evaluate) : base(concept.Code, concept.Name)
		{
			__targetValues = targetValues.Split(VALUES_SEPARATOR);

			__resultValues = resultValues.Split(VALUES_SEPARATOR);

			__relatedArticles = EMPTY_ARTICLES;

			__pendingArticles = (IPayrollArticle[])pendingArticles.Clone();

			__summaryArticles = (IPayrollArticle[])summaryArticles.Clone();

			__category = category;

			__evaluate = evaluate;

		}

		private string[] __targetValues;

		private string[] __resultValues;

		private IPayrollArticle[] __relatedArticles = EMPTY_ARTICLES;

		private IPayrollArticle[] __pendingArticles = EMPTY_ARTICLES;

		private IPayrollArticle[] __summaryArticles = EMPTY_ARTICLES;

		private ProcessCategory __category = ProcessCategory.CATEGORY_START;

		private EvaluateDelegate __evaluate = null;

		#region IPayrollConcept implementation

		public SymbolName ConceptSymbol()
		{
			return (SymbolName) this;
		}

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

		public string[] ResultValues ()
		{
			return __resultValues;
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

		public virtual IResultStream CallEvaluate(IProcessConfig config, IEngineProfile engine, IBookIndex element, IResultStream results)
		{
			if (__evaluate != null)
			{
				return __evaluate (config, engine, element, results);
			}
			return results;
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

