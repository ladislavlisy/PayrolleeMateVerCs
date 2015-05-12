using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollArticle : SymbolName, IPayrollArticle
	{
		public static IPayrollArticle CreateArticle(SymbolName article, SymbolName concept, 
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts)
		{
			return new GeneralPayrollArticle (article, concept, 
				taxingIncome, healthIncome, socialIncome, grossSummary, nettoSummary, nettoDeducts);
		}
		
		protected GeneralPayrollArticle (SymbolName article, SymbolName concept, 
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts) : base(article.Code, article.Name)
		{
			__conceptSymbol = concept;

			__healthIncome = healthIncome;

			__socialIncome = socialIncome;

			__taxingIncome = taxingIncome;

			__summaryGross = grossSummary;

			__summaryNetto = nettoSummary;

			__deductsNetto = nettoDeducts;
		}

		protected GeneralPayrollArticle (uint articleCode, string articleName, uint conceptCode, string conceptName, 
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts) : base(articleCode, articleName)
		{
			__conceptSymbol = new SymbolName(conceptCode, conceptName);

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

		#region IPayrollArticle implementation

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

		public bool IncomeGross ()
		{
			return __summaryGross;
		}

		public bool IncomeNetto ()
		{
			return __summaryNetto;
		}

		public bool DeductNetto ()
		{
			return __deductsNetto;
		}

		#endregion
	}
}

