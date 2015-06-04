using System;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using PayrolleeMate.ProcessService.Interfaces;

namespace Tests.ProcessService.Loggers
{
	public class TestEmptyLogger : IProcessServiceLogger
	{
		public TestEmptyLogger (string testNamespace)
		{
		}

		#region IGeneralLogger implementation

		public void OpenLogStream (string testName)
		{
		}

		public void CloseLogStream ()
		{
		}

		public void LogAppendMessageInfo (string message, string testName)
		{
		}

		#endregion

		#region IProcessServiceLogger implementation

		public void LogEvaluationStream (ITargetStream targets, string testName)
		{
		}

		public void LogEvaluationList (IBookTarget[] targets, string testName)
		{
		}
			
		public void LogResultStream (IResultStream results, string testName)
		{
		}

		#endregion

	}
}

