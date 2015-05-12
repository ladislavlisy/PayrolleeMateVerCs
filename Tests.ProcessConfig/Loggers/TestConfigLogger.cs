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

namespace Tests.ProcessConfig.Logers
{
	public class TestConfigLogger : IProcessConfigLogger
	{
		public TestConfigLogger(string testNamespace)
		{
			TestNamespaceDir = "LoggFiles/" + testNamespace + "/";
		}

		private string TestNamespaceDir { get; set; }

		#region IProcessConfigLogger implementation

		public void LogArticlesInConcept (IPayrollConcept concept, IPayrollArticle[] articles, string testName)
		{
			string TestNamespaceFile = TestNamespaceDir + testName + ".log";

			Console.WriteLine(TestNamespaceFile);

			Console.WriteLine("--- begin ---");

			string lineDefinition = ConceptRelatedArticlesLogger.LogConceptArticlesInfo(concept, articles);

			Console.WriteLine(lineDefinition);

			Console.WriteLine("--- end ---");
		}


		public void LogConceptsInModels (IDictionary<uint, IPayrollConcept> models, string testName)
		{
			string TestNamespaceFile = TestNamespaceDir + testName + ".log";

			Console.WriteLine(TestNamespaceFile);

			Console.WriteLine("--- begin ---");

			foreach (var conceptPair in models)
			{
				IPayrollConcept concept = conceptPair.Value;

				string lineDefinition = ModelConceptsLogger.LogConceptInfo(concept);

				Console.WriteLine(lineDefinition);
			}

			Console.WriteLine("--- end ---");
		}

		public void LogRelatedArticlesInModels (IDictionary<uint, IPayrollConcept> models, string testName)
		{
			string TestNamespaceFile = TestNamespaceDir + testName + ".log";

			Console.WriteLine(TestNamespaceFile);

			Console.WriteLine("--- begin ---");

			foreach (var conceptPair in models)
			{
				IPayrollConcept concept = conceptPair.Value;
				string lineDefinition = ModelConceptsRelatedArticlesLogger.LogConceptInfo(concept);

				Console.WriteLine(lineDefinition);
			}

			Console.WriteLine("--- end ---");
		}

		#endregion

		private static class ConceptRelatedArticlesLogger
		{
			public static string LogConceptArticlesInfo(IPayrollConcept concept, IPayrollArticle[] articles)
			{
				string lineDefinition = LogConceptInfo(concept);

				lineDefinition += "--- ARTICLES ---\n";

				lineDefinition += LogArrayOfArticles(articles);

				lineDefinition += "--- ARTICLES ---\n\n";

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

