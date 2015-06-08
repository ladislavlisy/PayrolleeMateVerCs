using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.Common.Interfaces
{
	public static class GeneralModule
	{
		public static readonly IBookResult[] EMPTY_RESULT_LIST = { };

		public delegate IBookResult[] EvaluateDelegate (IPayrollConcept concept, IProcessConfig config, IEngineProfile engine, 
			IPayrollArticle article, IBookIndex element, ITargetValues targets, IResultStream results);
	}
}

