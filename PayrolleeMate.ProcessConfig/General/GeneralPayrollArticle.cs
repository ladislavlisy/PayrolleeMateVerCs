using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Comparers;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollArticle : SymbolName, IPayrollArticle
	{
		public static readonly SymbolName[] EMPTY_ARTICLE_NAMES = {};

		public static readonly IPayrollArticle[] EMPTY_ARTICLES = {};

		public static IPayrollArticle CreateArticle(SymbolName article, 
			SymbolName concept, ProcessCategory category, 
			SymbolName[] pendingNames, SymbolName[] summaryNames,
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts)
		{
			return new GeneralPayrollArticle (article, concept, category, 
				pendingNames, summaryNames,
				taxingIncome, healthIncome, socialIncome, grossSummary, nettoSummary, nettoDeducts);
		}
		
		protected GeneralPayrollArticle (SymbolName article, 
			SymbolName concept, ProcessCategory category, 
			SymbolName[] pendingNames, SymbolName[] summaryNames,
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts) : base(article.Code, article.Name)
		{
			__conceptSymbol = concept;

			__category = category;

			__pendingArticleNames = (SymbolName[])pendingNames.Clone();

			__summaryArticleNames = (SymbolName[])summaryNames.Clone();

			__healthIncome = healthIncome;

			__socialIncome = socialIncome;

			__taxingIncome = taxingIncome;

			__summaryGross = grossSummary;

			__summaryNetto = nettoSummary;

			__deductsNetto = nettoDeducts;
		}

		protected GeneralPayrollArticle (uint articleCode, string articleName, 
			uint conceptCode, string conceptName, ProcessCategory category, 
			SymbolName[] pendingNames, SymbolName[] summaryNames,
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts) : base(articleCode, articleName)
		{
			__conceptSymbol = new SymbolName(conceptCode, conceptName);

			__category = category;

			__pendingArticleNames = (SymbolName[])pendingNames.Clone();

			__summaryArticleNames = (SymbolName[])summaryNames.Clone();

			__healthIncome = healthIncome;

			__socialIncome = socialIncome;

			__taxingIncome = taxingIncome;

			__summaryGross = grossSummary;

			__summaryNetto = nettoSummary;

			__deductsNetto = nettoDeducts;
		}

		private SymbolName __conceptSymbol;

		private bool __healthIncome = false;

		private bool __socialIncome = false;

		private bool __taxingIncome = false;

		private bool __summaryGross = false;

		private bool __summaryNetto = false;

		private bool __deductsNetto = false;

		private ProcessCategory __category = ProcessCategory.CATEGORY_START;

		SymbolName[] __pendingArticleNames = EMPTY_ARTICLE_NAMES;

		SymbolName[] __summaryArticleNames = EMPTY_ARTICLE_NAMES;

		IPayrollArticle[] __relatedArticles = EMPTY_ARTICLES;

		#region IPayrollArticle implementation

		public SymbolName ArticleSymbol ()
		{
			return (SymbolName)this;
		}

		public uint ArticleCode ()
		{
			return this.Code;
		}

		public string ArticleName ()
		{
			return this.Name;
		}

		public SymbolName ConceptSymbol ()
		{
			return __conceptSymbol;
		}

		public uint ConceptCode ()
		{
			return __conceptSymbol.Code;
		}

		public string ConceptName ()
		{
			return __conceptSymbol.Name;
		}

		public bool HealthIncome ()
		{
			return __healthIncome;
		}

		public bool SocialIncome ()
		{
			return __socialIncome;
		}

		public bool TaxingIncome ()
		{
			return __taxingIncome;
		}

		public bool SummaryGross ()
		{
			return __summaryGross;
		}

		public bool SummaryNetto ()
		{
			return __summaryNetto;
		}

		public bool DeductsNetto ()
		{
			return __deductsNetto;
		}

		public ProcessCategory Category ()
		{
			return __category;
		}
			
		public SymbolName[] PendingArticleNames ()
		{
			return __pendingArticleNames;
		}

		public SymbolName[] SummaryArticleNames ()
		{
			return __summaryArticleNames;
		}

		public IPayrollArticle[] RelatedArticles ()
		{
			return __relatedArticles;
		}

		public void UpdateRelatedArticles (IPayrollArticle[] articles)
		{
			this.__relatedArticles = null;
			if (articles != null)
			{
				this.__relatedArticles = (IPayrollArticle[])articles.Clone();
			}
		}

		public int CompareTo(IPayrollArticle articleOther)
		{
			return ArticleDependencyComparer.CompareArticles(this, articleOther);
		}

		#endregion
	}
}

