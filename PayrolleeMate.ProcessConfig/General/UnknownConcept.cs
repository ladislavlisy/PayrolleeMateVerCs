using System;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfig.Payroll.Concepts
{
	public class UnknownConcept : GeneralPayrollConcept
	{
		public UnknownConcept () : 
			base(ConceptSymbolName.REF_UNKNOWN, EMPTY_ARTICLES, EMPTY_ARTICLES, ProcessCategory.CATEGORY_START, "")
		{
		}
	}
}

