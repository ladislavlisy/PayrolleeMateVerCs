using System;
using PayrolleeMate.Common.Interfaces;

namespace PayrolleeMate.ProcessService.Interfaces.Loggers
{
	public interface IProcessServiceLogger : IGeneralLogger
	{
		void LogEvaluationStream (ITargetStream targets, string testName);
	}
}

