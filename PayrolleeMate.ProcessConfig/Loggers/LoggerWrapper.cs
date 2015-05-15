using System;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Collections.Generic;

namespace PayrolleeMate.ProcessConfig.Logers
{
	static class LoggerWrapper
	{
		public static void OpenLogStream (IProcessConfigLogger logger, string testName)
		{
			if (logger != null) 
			{
				logger.OpenLogStream (testName);
			}
		}

		public static void CloseLogStream (IProcessConfigLogger logger)
		{
			if (logger != null) 
			{
				logger.CloseLogStream ();
			}
		}

		public static void LogArticlesInConcept(IProcessConfigLogger logger, IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
			if (logger != null) 
			{
				logger.LogArticlesInConcept (article, articles, testName);
			}
		}

		public static void LogConceptsInModels (IProcessConfigLogger logger, IDictionary<uint, IPayrollArticle> articles, IDictionary<uint, IPayrollConcept> concepts, string testName)
		{
			if (logger != null) 
			{
				logger.LogConceptsInModels (articles, concepts, testName);
			}
		}

		public static void LogRelatedArticlesInModels (IProcessConfigLogger logger, IDictionary<uint, IPayrollArticle> models, string testName)
		{
			if (logger != null) 
			{
				logger.LogRelatedArticlesInModels (models, testName);
			}
		}

		public static void LogConceptArticlesCollection (IProcessConfigLogger logger, IDictionary<uint, IPayrollArticle[]> collection, string testName)
		{
			if (logger != null) 
			{
				logger.LogConceptArticlesCollection (collection, testName);
			}
		}

		public static void LogConceptCodeArticles (IProcessConfigLogger logger, uint concept, IPayrollArticle[] articles, string testName)
		{
			if (logger != null) 
			{
				logger.LogConceptCodeArticles (concept, articles, testName);
			}
		}

		public static void LogPendingArticles (IProcessConfigLogger logger, IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
			if (logger != null) 
			{
				logger.LogPendingArticles (article, articles, testName);
			}
		}

		public static void LogRelatedArticles (IProcessConfigLogger logger, IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
			if (logger != null) 
			{
				logger.LogRelatedArticles (article, articles, testName);
			}
		}
	}
}

