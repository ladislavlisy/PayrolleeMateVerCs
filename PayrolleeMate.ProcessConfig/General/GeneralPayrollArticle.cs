using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollArticle : IPayrollArticle
	{
		public GeneralPayrollArticle ()
		{
		}

		#region IPayrollArticle implementation

		public uint ArticleCode ()
		{
			throw new NotImplementedException ();
		}

		public string ArticleName ()
		{
			throw new NotImplementedException ();
		}

		public SymbolName ConceptSymbol ()
		{
			throw new NotImplementedException ();
		}

		public uint ConceptCode ()
		{
			throw new NotImplementedException ();
		}

		public string ConceptName ()
		{
			throw new NotImplementedException ();
		}

		public bool HealthIncome ()
		{
			throw new NotImplementedException ();
		}

		public bool SocialIncome ()
		{
			throw new NotImplementedException ();
		}

		public bool TaxingIncome ()
		{
			throw new NotImplementedException ();
		}

		public bool IncomeGross ()
		{
			throw new NotImplementedException ();
		}

		public bool IncomeNetto ()
		{
			throw new NotImplementedException ();
		}

		public bool DeductionNetto ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

