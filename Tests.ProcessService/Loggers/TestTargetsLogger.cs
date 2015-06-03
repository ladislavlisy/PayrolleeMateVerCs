using System;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using System.IO;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace Tests.ProcessService.Loggers
{
	public class TestTargetsLogger : IProcessServiceLogger
	{
		public TestTargetsLogger (string testNamespace)
		{
			TestNamespaceDir = "../../../LoggFiles/" + testNamespace + "/";

			LogSequenceId = 0;

			SequenceNames = new Dictionary<string, string> ();
		}

		private string TestNamespaceDir { get; set; }

		private Stream LogFileStream { get; set; }

		private UInt16 LogSequenceId { get; set; }

		private IDictionary<string, string> SequenceNames { get; set; }

		#region IGeneralLogger implementation

		public void OpenLogStream (string testName)
		{
			string TestFilenameExist = LogSequenceId.ToString () + "-" + testName;

			FileMode fileOpenMode = FileMode.Append;

			if (SequenceNames.ContainsKey (testName))
			{
				TestFilenameExist = SequenceNames[testName];
			}
			else
			{
				LogSequenceId ++; 

				TestFilenameExist = LogSequenceId.ToString () + "-" + testName;

				SequenceNames[testName] = TestFilenameExist;

				fileOpenMode = FileMode.Create;
			}

			string TestNamespaceFile = TestNamespaceDir + TestFilenameExist + ".txt";

			LogFileStream = new FileStream (TestNamespaceFile, fileOpenMode);
		}

		public void CloseLogStream ()
		{
			LogFileStream = null;
		}

		public void LogAppendMessageInfo (string message, string testName)
		{
			OpenLogStream(testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream) ) 
			{
				logWriter.WriteLine (message);
			}
		}

		#endregion

		#region IProcessServiceLogger implementation

		public void LogEvaluationStream (ITargetStream targets, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += TargetStreamLogger.LogTargetListInfo (targets.Targets ());

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		#endregion

		private static class TargetStreamLogger
		{
			public static string LogTargetListInfo(IDictionary<IBookIndex, IBookTarget> targets)
			{
				string lineDefinition = "";

				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				foreach (var target in targets)
				{
					lineDefinition += LogArticleInfo (target.Value.Article ());
				}
				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogArticleInfo(IPayrollArticle article)
			{
				string lineDefinition = string.Format("\n--- {0} - {1} - {2}", article.ArticleName(), article.ConceptName(), article.ArticleCode());

				return lineDefinition;
			}

		}

	}
}

