using System;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IProcessService
	{
		IResultStream EvaluateTargetsToResults ();
	}
}

