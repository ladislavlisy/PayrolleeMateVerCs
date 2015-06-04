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

				lineDefinition += TargetStreamLogger.LogTargetStreamInfo (targets.Targets ());

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogEvaluationList (IBookTarget[] targets, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += TargetStreamLogger.LogTargetListInfo (targets);

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogResultStream (IResultStream results, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += ResultStreamLogger.LogResultStreamInfo (results.Results ());

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
			public static string LogTargetStreamInfo(IDictionary<IBookIndex, IBookTarget> targets)
			{
				string lineDefinition = "";

				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				foreach (var target in targets)
				{
					lineDefinition += LogArticleInfo (target.Value);
				}
				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogTargetListInfo(IBookTarget[] targets)
			{
				string lineDefinition = "";

				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				foreach (var target in targets)
				{
					lineDefinition += LogArticleInfo (target);
				}
				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogArticleInfo(IBookTarget target)
			{
				IPayrollArticle article = target.Article ();

				IBookIndex element = target.Element ();

				string lineDefinition = string.Format("\n--- {0} - {1} - {2} - {3}", 
					article.ArticleName(), article.ConceptName(), article.ArticleCode(), element.ToString());

				return lineDefinition;
			}

		}

		private static class ResultStreamLogger
		{
			public static string LogResultStreamInfo(IDictionary<IBookIndex, IBookResult> results)
			{
				string lineDefinition = "";

				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				foreach (var result in results)
				{
					lineDefinition += LogArticleInfo (result.Value);
				}
				lineDefinition += "\n";

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogArticleInfo(IBookResult result)
			{
				IPayrollArticle article = result.Article ();

				IBookIndex element = result.Element ();

				string lineDefinition = string.Format("\n--- {0} - {1} - {2} - {3}", 
					article.ArticleName(), article.ConceptName(), article.ArticleCode(), element.ToString());

				return lineDefinition;
			}

		}

	}
}

