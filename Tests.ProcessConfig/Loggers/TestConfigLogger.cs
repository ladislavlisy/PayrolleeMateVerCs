using NUnit.Framework;
using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfigSetCz;
using PayrolleeMate.ProcessConfig.Payroll.Articles;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using System.Collections.Generic;
using System.IO;
using PayrolleeMate.ConfigSetCz.Constants;

namespace Tests.ProcessConfig.Logers
{
	public class TestConfigLogger : IProcessConfigLogger
	{
		public TestConfigLogger(string testNamespace)
		{
			TestNamespaceDir = "../../../LoggFiles/" + testNamespace + "/";

			LogSequenceId = 0;

			SequenceNames = new Dictionary<string, string> ();
		}

		private string TestNamespaceDir { get; set; }

		private Stream LogFileStream { get; set; }

		private UInt16 LogSequenceId { get; set; }

		private IDictionary<string, string> SequenceNames { get; set; }

		public Stream OpenCustomStream (string testName)
		{
			LogSequenceId ++; 

			string TestFilenameExist = LogSequenceId.ToString () + "-" + testName;
					
			string TestNamespaceFile = TestNamespaceDir + TestFilenameExist + ".log";

			try 
			{
				Stream logStream = new FileStream (TestNamespaceFile, FileMode.Create);

				return logStream;
			}
			catch (Exception ex) 
			{
				throw ex;
			}
		}

		public void CloseCustomStream (Stream logStream)
		{
			logStream.Flush ();

			logStream.Close ();
		}

		#region IProcessConfigLogger implementation

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

			string TestNamespaceFile = TestNamespaceDir + TestFilenameExist + ".log";

			LogFileStream = new FileStream (TestNamespaceFile, fileOpenMode);
		}

		public void CloseLogStream ()
		{
			LogFileStream = null;
		}

		public void LogArticlesInConcept (IPayrollConcept concept, IPayrollArticle[] articles, string testName)
		{
			OpenLogStream(testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream) ) 
			{
				logWriter.WriteLine ("--- begin ---");

				string lineDefinition = ConceptRelatedArticlesLogger.LogConceptArticlesInfo (concept, articles);

				logWriter.WriteLine (lineDefinition);

				logWriter.WriteLine ("--- end ---");
			}
		}


		public void LogConceptsInModels (IDictionary<uint, IPayrollConcept> models, string testName)
		{
			Stream logStream = OpenCustomStream(testName);

			using (StreamWriter logWriter = new StreamWriter (logStream) ) 
			{
				logWriter.WriteLine ("--- begin ---");

				foreach (var conceptPair in models)
				{
					IPayrollConcept concept = conceptPair.Value;

					string lineDefinition = ModelConceptsLogger.LogConceptInfo(concept);

					logWriter.WriteLine(lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogRelatedArticlesInModels (IDictionary<uint, IPayrollConcept> models, string testName)
		{
			Stream logStream = OpenCustomStream(testName);

			using (StreamWriter logWriter = new StreamWriter (logStream) ) 
			{
				logWriter.WriteLine ("--- begin ---");

				foreach (var conceptPair in models)
				{
					IPayrollConcept concept = conceptPair.Value;
					string lineDefinition = ModelConceptsRelatedArticlesLogger.LogConceptInfo(concept);

					logWriter.WriteLine(lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogConceptArticlesCollection(IDictionary<uint, IPayrollArticle[]> collection, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				logWriter.WriteLine ("--- begin ---");

				string lineDefinition = "";

				foreach (var conceptPair in collection) 
				{
					lineDefinition += ConceptCodeArticlesLogger.LogConceptCodeArticlesInfo (conceptPair.Key, conceptPair.Value);
				}

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogConceptCodeArticles(uint concept, IPayrollArticle[] articles, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				logWriter.WriteLine ("--- begin ---");

				string lineDefinition = ConceptCodeArticlesLogger.LogConceptCodeArticlesInfo(concept, articles);

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogPendingArticles(IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				logWriter.WriteLine ("--- begin ---");

				string lineDefinition = ConceptCodeArticlesLogger.LogArticleInfo(article);

				lineDefinition += "--- PENDING ---\n";

				lineDefinition += ConceptCodeArticlesLogger.LogArrayOfArticles(articles);

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogRelatedArticles(IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				logWriter.WriteLine ("--- begin ---");

				string lineDefinition = ConceptCodeArticlesLogger.LogArticleInfo(article);

				lineDefinition += "--- RELATED ---\n";

				lineDefinition += ConceptCodeArticlesLogger.LogArrayOfArticles(articles);

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		#endregion

		private static class ConceptCodeArticlesLogger
		{
			public static string LogConceptCodeArticlesInfo(uint conceptCode, IPayrollArticle[] articles)
			{
				string lineDefinition = LogConceptCodeInfo(conceptCode);

				lineDefinition += "--- ARTICLES ---\n";

				lineDefinition += LogArrayOfArticles(articles);

				lineDefinition += "--- ARTICLES ---";

				return lineDefinition;
			}

			private static string LogConceptCodeInfo(uint conceptCode)
			{
				string conceptDescrip = Enum.ToObject (typeof(ConfigSetCzConceptCode), conceptCode).ToString ();

				string lineDefinition = string.Format("{0} - {1}\n", "CONCEPT", conceptDescrip);

				return lineDefinition;
			}

			public static string LogArticleInfo(IPayrollArticle article)
			{
				string lineDefinition = string.Format("{0} - {1} - {2}\n", article.ArticleName(), article.ConceptName(), article.ArticleCode());

				return lineDefinition;
			}

			public static string LogArrayOfArticles(IPayrollArticle[] articles)
			{
				string lineDefinition = "";
				if (articles == null)
				{
					lineDefinition = "empty\n";
					return lineDefinition;
				}
				else
				{
					lineDefinition = string.Format("count - {0}\n", articles.Length);
				}
				foreach (var article in articles)
				{
					lineDefinition += LogArticleInfo(article);
				}
				return lineDefinition;
			}
		}

		private static class ConceptRelatedArticlesLogger
		{
			public static string LogConceptArticlesInfo(IPayrollConcept concept, IPayrollArticle[] articles)
			{
				string lineDefinition = LogConceptInfo(concept);

				lineDefinition += "--- ARTICLES ---\n";

				lineDefinition += LogArrayOfArticles(articles);

				lineDefinition += "--- ARTICLES ---";

				return lineDefinition;
			}

			public static string LogConceptInfo(IPayrollConcept concept)
			{
				string lineDefinition = string.Format("{0} - {1}\n", concept.ConceptName(), concept.ConceptCode());

				return lineDefinition;
			}

			public static string LogArticleInfo(IPayrollArticle article)
			{
				string lineDefinition = string.Format("{0} - {1} - {2}\n", article.ArticleName(), article.ConceptName(), article.ArticleCode());

				return lineDefinition;
			}

			public static string LogArrayOfArticles(IPayrollArticle[] articles)
			{
				string lineDefinition = "";
				if (articles == null)
				{
					lineDefinition = "empty\n";
					return lineDefinition;
				}
				else
				{
					lineDefinition = string.Format("count - {0}\n", articles.Length);
				}
				foreach (var article in articles)
				{
					lineDefinition += LogArticleInfo(article);
				}
				return lineDefinition;
			}
		}

		private static class ModelConceptsLogger
		{
			public static string LogConceptInfo(IPayrollConcept concept)
			{
				string calcDefinition = Enum.ToObject(typeof(ProcessCategory), concept.Category()).ToString();

				string lineDefinition = string.Format("{0}\t{1}\t", concept.ConceptName(), calcDefinition);

				lineDefinition += LogPendingArticlesInfo(concept);

				lineDefinition += LogSummaryArticlesInfo(concept);

				lineDefinition += LogSpecValuesInfo(concept);

				return lineDefinition;
			}

			public static string LogPendingArticlesInfo(IPayrollConcept concept)
			{
				string lineDefinition = "";

				var articles = concept.PendingArticles();

				int articlesCount = articles.Length;

				foreach (var article in articles)
				{
					lineDefinition += string.Format("{0}\t", article.ArticleName());
				}
				for (int emptyColumn = articlesCount; emptyColumn < 5; emptyColumn++)
				{
					lineDefinition = string.Format("\t");
				}
				return lineDefinition;
			}

			public static string LogSummaryArticlesInfo(IPayrollConcept concept)
			{
				string lineDefinition = "";

				var articles = concept.SummaryArticles();

				int articlesCount = articles.Length;

				foreach (var article in articles)
				{
					lineDefinition = string.Format("{0}\t", article.ArticleName());
				}
				for (int emptyColumn = articlesCount; emptyColumn < 1; emptyColumn++)
				{
					lineDefinition = string.Format("\t");
				}
				return lineDefinition;
			}

			public static string LogSpecValuesInfo(IPayrollConcept concept)
			{
				string lineDefinition = string.Join(", ", concept.TargetValues());

				return lineDefinition;
			}
		}

		private static class ModelConceptsRelatedArticlesLogger
		{
			public static string LogConceptInfo(IPayrollConcept concept)
			{
				string relatedDescrip = concept.RelatedArticles ().Length.ToString ();

				string lineDefinition = string.Format("{0} - {1}\n", concept.ConceptName(), relatedDescrip);

				lineDefinition += LogRelatedArticlesInfo(concept);

				return lineDefinition;
			}

			public static string LogRelatedArticlesInfo(IPayrollConcept concept)
			{
				var articles = concept.RelatedArticles();

				string lineDefinition = ConceptRelatedArticlesLogger.LogArrayOfArticles(articles);

				return lineDefinition;
			}
		}

	}

}

