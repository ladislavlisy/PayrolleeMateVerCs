using System;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Logers
{
	static class LoggerWrapper
	{
		public static void OpenLogStream (IProcessServiceLogger logger, string testName)
		{
			if (logger != null) 
			{
				logger.OpenLogStream (testName);
			}
		}

		public static void CloseLogStream (IProcessServiceLogger logger)
		{
			if (logger != null) 
			{
				logger.CloseLogStream ();
			}
		}

		public static void LogEvaluationStream (IProcessServiceLogger logger, ITargetStream targets, string testName)
		{
			if (logger != null) 
			{
				logger.LogEvaluationStream (targets, testName);
			}
		}

		public static void LogAppendMessageInfo (IProcessServiceLogger logger, string message, string testName)
		{
			if (logger != null) 
			{
				logger.LogAppendMessageInfo (message, testName);
			}
		}

	}
}

