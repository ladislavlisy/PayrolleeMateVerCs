using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.Common.Interfaces
{
	public static class GeneralModule
	{
		public delegate IBookResult[] EvaluateDelegate (IProcessConfig config, IEngineProfile engine, 
			IPayrollArticle article, IBookIndex element, ITargetValues values, IResultStream results);
	}
}

