using System;
using PayrolleeMate.Common.Interfaces;

namespace PayrolleeMate.ProcessService.Interfaces.Loggers
{
	public interface IProcessServiceLogger : IGeneralLogger
	{
		void LogEvaluationStream (ITargetStream targets, string testName);

		void LogEvaluationList (IBookTarget[] targets, string testName);

		void LogResultStream (IResultStream results, string testName);
	}
}

