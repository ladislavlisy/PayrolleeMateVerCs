using System;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.ProcessConfig.Payroll.Concepts
{
	public class UnknownConcept : GeneralPayrollConcept
	{
		public UnknownConcept () : base(ConceptSymbolName.REF_UNKNOWN, false, false, "", "", null)
		{
		}

		public override IResultStream CallEvaluate(IProcessConfig config, IEngineProfile engine, IBookIndex element, IResultStream results)
		{
			return results;
		}

	}
}

