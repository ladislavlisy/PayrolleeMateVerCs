using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollArticle : SymbolName, IPayrollArticle
	{
		public GeneralPayrollArticle (SymbolName article, SymbolName concept, 
			bool taxingIncome, 
			bool healthIncome, 
			bool socialIncome, 
			bool grossIncome, 
			bool nettoIncome, 
			bool nettoDeduct) : base(article.Code, article.Name)
		{
			__conceptSymbol = concept;

			__healthIncome = healthIncome;

			__socialIncome = socialIncome;

			__taxingIncome = taxingIncome;

			__incomeGross = grossIncome;

			__incomeNetto = nettoIncome;

			__deductNetto = nettoDeduct;
		}

		public GeneralPayrollArticle (uint articleCode, string articleName, uint conceptCode, string conceptName, 
			bool taxingIncome, 
			bool healthIncome, 
			bool socialIncome, 
			bool grossIncome, 
			bool nettoIncome, 
			bool nettoDeduct) : base(articleCode, articleName)
		{
			__conceptSymbol = new SymbolName(conceptCode, conceptName);

			__healthIncome = healthIncome;

			__socialIncome = socialIncome;

			__taxingIncome = taxingIncome;

			__incomeGross = grossIncome;

			__incomeNetto = nettoIncome;

			__deductNetto = nettoDeduct;
		}

		private SymbolName __conceptSymbol;

		private bool __healthIncome = false;

		private bool __socialIncome = false;

		private bool __taxingIncome = false;

		private bool __incomeGross = false;

		private bool __incomeNetto = false;

		private bool __deductNetto = false;

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
			return __incomeGross;
		}

		public bool IncomeNetto ()
		{
			return __incomeNetto;
		}

		public bool DeductNetto ()
		{
			return __deductNetto;
		}

		#endregion
	}
}

