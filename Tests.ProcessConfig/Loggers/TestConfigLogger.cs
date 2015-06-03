using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfig.Payroll.Articles;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfigSetCz;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.ProcessConfigSetCz.Collections;

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
					
			string TestNamespaceFile = TestNamespaceDir + TestFilenameExist + ".txt";

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

		#region IProcessConfigLogger implementation

		public void LogConceptsInModels (IDictionary<uint, IPayrollArticle> articles, IDictionary<uint, IPayrollConcept> concepts, string testName)
		{
			Stream logStream = OpenCustomStream(testName);

			using (StreamWriter logWriter = new StreamWriter (logStream) ) 
			{
				logWriter.WriteLine ("\n--- begin ---");

				foreach (var articlePair in articles)
				{
					IPayrollArticle article = articlePair.Value;

					IPayrollConcept concept = ModelConceptsLogger.FindConceptForCode(concepts, article.ConceptCode());

					string lineDefinition = ModelConceptsLogger.LogConceptInfo(concept, article);

					logWriter.WriteLine(lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogListArticlesUnderArticle (IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
			OpenLogStream(testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream) ) 
			{
				//logWriter.WriteLine ("\n--- begin ---");

				string lineDefinition = ArticlesRelatedListLogger.LogArticleListInfo (article, articles);

				logWriter.WriteLine (lineDefinition);

				//logWriter.WriteLine ("--- end ---");
			}
		}


		public void LogRelatedArticlesInModels (IDictionary<uint, IPayrollArticle> models, string testName)
		{
			Stream logStream = OpenCustomStream(testName);

			using (StreamWriter logWriter = new StreamWriter (logStream) ) 
			{
				logWriter.WriteLine ("\n--- begin ---");

				foreach (var articlePair in models)
				{
					IPayrollArticle article = articlePair.Value;

					string lineDefinition = ModelArticlesRelatedListLogger.LogArticleInfo(article);

					logWriter.WriteLine(lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogDependentArticlesCollection(IDictionary<uint, IPayrollArticle[]> collection, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				foreach (var articlePair in collection) 
				{
					lineDefinition += ArticleListCodesLogger.LogDependentCodeArticlesInfo (articlePair.Key, articlePair.Value);
				}

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}
				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogDependentCodeArticlesInfo(uint article, IPayrollArticle[] articles, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += ArticleListCodesLogger.LogDependentCodeArticlesInfo(article, articles);

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		public void LogPendingArticles(IPayrollArticle article, SymbolName[] callings, IPayrollArticle[] articles, string testName)
		{
			OpenLogStream (testName);

			using (StreamWriter logWriter = new StreamWriter (LogFileStream)) 
			{
				string lineDefinition = "\n--- begin ---";

				lineDefinition += ArticleListCodesLogger.LogArticleInfo(article);

				lineDefinition += "\n--- CALLING PATH ---";

				lineDefinition += ArticleListCodesLogger.LogArrayOfSymbols(callings);

				lineDefinition += "\n--- CALCULATED ---";

				lineDefinition += ArticleListCodesLogger.LogArrayOfArticles(article.ArticleCode(), articles);

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
				string lineDefinition = "\n--- begin ---";

				lineDefinition += ArticleListCodesLogger.LogArticleInfo(article);

				lineDefinition += "\n--- EXISTS IN RELATED ---";

				lineDefinition += ArticleListCodesLogger.LogArrayOfArticles(article.ArticleCode(), articles);

				if (lineDefinition.Length > 0) 
				{
					logWriter.WriteLine (lineDefinition);
				}

				logWriter.WriteLine ("--- end ---");
			}
		}

		#endregion

		private static class ArticleListCodesLogger
		{
			public static string LogDependentCodeArticlesInfo(uint articleCode, IPayrollArticle[] articles)
			{
				string lineDefinition = LogArticleCodeInfo(articleCode);

				lineDefinition += "----------------------------";

				lineDefinition += LogArrayOfArticles(articleCode, articles);

				lineDefinition += "----------------------------";

				return lineDefinition;
			}

			private static string LogArticleCodeInfo(uint articleCode)
			{
				string articleDescrip = Enum.ToObject (typeof(ConfigSetCzArticleCode), articleCode).ToString ();

				string lineDefinition = string.Format("{0} - {1}\n", "ARTICLE", articleDescrip);

				return lineDefinition;
			}

			public static string LogArticleInfo(IPayrollArticle article)
			{
				string lineDefinition = string.Format("\n--- {0} - {1} - {2}", article.ArticleName(), article.ConceptName(), article.ArticleCode());

				return lineDefinition;
			}

			public static string LogArticleName(SymbolName article)
			{
				string lineDefinition = string.Format("\n--- {0} - {1}", article.Name, article.Code);

				return lineDefinition;
			}

			public static string LogArrayOfArticles(uint articleCode, IPayrollArticle[] articles)
			{
				string lineDefinition = "";
				if (articles == null)
				{
					lineDefinition = "\nempty";
					return lineDefinition;
				}
				foreach (var article in articles)
				{
					if (articleCode != article.ArticleCode ()) 
					{
						lineDefinition += LogArticleInfo (article);
					}
				}
				lineDefinition += "\n";
				return lineDefinition;
			}

			public static string LogArrayOfSymbols(SymbolName[] articles)
			{
				string lineDefinition = "";
				if (articles == null)
				{
					lineDefinition = "\nempty";
					return lineDefinition;
				}
				foreach (var article in articles)
				{
					lineDefinition += LogArticleName (article);
				}
				lineDefinition += "\n";
				return lineDefinition;
			}
		}

		private static class ArticlesRelatedListLogger
		{
			public static string LogArticleListInfo(IPayrollArticle article, IPayrollArticle[] articles)
			{
				string lineDefinition = LogHeaderInfo(article, articles);

				//lineDefinition += "----------------------------";

				lineDefinition += LogBodyOfArticles(articles);

				//lineDefinition += "----------------------------";

				return lineDefinition;
			}

			public static string LogHeaderInfo(IPayrollArticle article, IPayrollArticle[] articles)
			{
				string lineCountInfo = "";
				if (articles == null)
				{
					lineCountInfo = "empty";
				}
				else
				{
					lineCountInfo = string.Format("{0}", articles.Length);
				}
				string lineDefinition = string.Format("count - {0} - {1} - {2} - {3}", lineCountInfo, article.ArticleName(), article.ConceptName(), article.ConceptCode());

				return lineDefinition;
			}

			public static string LogConceptInfo(IPayrollArticle article)
			{
				string lineDefinition = string.Format("{0} - {1} - {2}\n", article.ArticleName(), article.ConceptName(), article.ConceptCode());

				return lineDefinition;
			}

			public static string LogArticleInfo(IPayrollArticle article)
			{
				string lineDefinition = string.Format("\n\t{0} - {1} - {2}", article.ArticleName(), article.ConceptName(), article.ArticleCode());

				return lineDefinition;
			}

			public static string LogArrayOfArticles(IPayrollArticle[] articles)
			{
				string lineDefinition = "";
				if (articles == null)
				{
					lineDefinition = "\nempty";
					return lineDefinition;
				}
				else
				{
					lineDefinition = string.Format("\ncount - {0}", articles.Length);
				}
				foreach (var article in articles)
				{
					lineDefinition += LogArticleInfo(article);
				}
				lineDefinition += "\n";
				return lineDefinition;
			}

			public static string LogBodyOfArticles(IPayrollArticle[] articles)
			{
				string lineDefinition = "";
				foreach (var article in articles)
				{
					lineDefinition += LogArticleInfo(article);
				}
				lineDefinition += "\n";
				return lineDefinition;
			}
		}

		private static class ModelConceptsLogger
		{
			public static IPayrollConcept FindConceptForCode(IDictionary<uint, IPayrollConcept> models, uint conceptCode)
			{
				IPayrollConcept baseInstance = null;

				if (models.ContainsKey(conceptCode))
				{
					baseInstance = models[conceptCode];
				}
				return baseInstance;
			}

			public static string LogConceptInfo(IPayrollConcept concept, IPayrollArticle article)
			{
				string calcDefinition = Enum.ToObject(typeof(ProcessCategory), article.Category()).ToString();

				string lineDefinition = string.Format("{0}\t{1}\t{2}\t", article.ArticleName(), concept.ConceptName(), calcDefinition);

				lineDefinition += LogPendingArticlesInfo(article);

				lineDefinition += LogSummaryArticlesInfo(article);

				lineDefinition += LogSpecValuesInfo(concept);

				return lineDefinition;
			}

			public static string LogPendingArticlesInfo(IPayrollArticle parentArticle)
			{
				string lineDefinition = "";

				var articles = parentArticle.PendingArticleNames();

				int articlesCount = articles.Length;

				foreach (var article in articles)
				{
					lineDefinition += string.Format("{0}\t", article.Name);
				}
				for (int emptyColumn = articlesCount; emptyColumn < 10; emptyColumn++)
				{
					lineDefinition = string.Format("\t");
				}
				return lineDefinition;
			}

			public static string LogSummaryArticlesInfo(IPayrollArticle parentArticle)
			{
				string lineDefinition = "";

				var articles = parentArticle.SummaryArticleNames();

				int articlesCount = articles.Length;

				foreach (var article in articles)
				{
					lineDefinition = string.Format("{0}\t", article.Name);
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

		private static class ModelArticlesRelatedListLogger
		{
			public static string LogArticleInfo(IPayrollArticle article)
			{
				string relatedDescrip = article.RelatedArticles ().Length.ToString ();

				string lineDefinition = string.Format("{0} - {1}\n", article.ConceptName(), relatedDescrip);

				lineDefinition += LogRelatedArticlesInfo(article);

				return lineDefinition;
			}

			public static string LogRelatedArticlesInfo(IPayrollArticle article)
			{
				var articles = article.RelatedArticles();

				string lineDefinition = ArticlesRelatedListLogger.LogArrayOfArticles(articles);

				return lineDefinition;
			}
		}

	}

}

