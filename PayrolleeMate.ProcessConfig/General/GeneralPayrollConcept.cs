using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollConcept : IPayrollConcept
	{
		public GeneralPayrollConcept ()
		{
		}

		#region IPayrollConcept implementation

		public uint ConceptCode ()
		{
			throw new NotImplementedException ();
		}

		public string ConceptName ()
		{
			throw new NotImplementedException ();
		}

		public string[] TargetValues ()
		{
			throw new NotImplementedException ();
		}

		public IPayrollArticle[] RelatedArticles ()
		{
			throw new NotImplementedException ();
		}

		public IPayrollArticle[] PendingArticles ()
		{
			throw new NotImplementedException ();
		}

		public IPayrollArticle[] SummaryArticles ()
		{
			throw new NotImplementedException ();
		}

		public ProcessCategory Category ()
		{
			throw new NotImplementedException ();
		}

		public void UpdateRelatedArticles (IPayrollArticle[] articles)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

