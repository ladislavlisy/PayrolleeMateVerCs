using System;
using PayrolleeMate.ProcessService.Interfaces.Loggers;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IProcessService
	{
		IResultStream EvaluateTargetsToResults ();
	}
}

