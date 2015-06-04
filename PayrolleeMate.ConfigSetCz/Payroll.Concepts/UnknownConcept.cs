using System;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.ProcessService.Patterns;

namespace PayrolleeMate.ProcessConfig.Payroll.Concepts
{
	public class UnknownConcept : GeneralPayrollConcept
	{
		public UnknownConcept () : base(ConceptSymbolName.REF_UNKNOWN, false, false, false, false, "", "", null)
		{
		}

		public override IBookResult[] CallEvaluate(IProcessConfig config, IEngineProfile engine, 
			IPayrollArticle article, IBookIndex element, ITargetValues values, IResultStream results)
		{
			return BookResultBase.EMPTY_RESULT_LIST;
		}

	}
}

