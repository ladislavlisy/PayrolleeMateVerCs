using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace PayrolleeMate.ProcessConfig.Interfaces.Loggers
{
	public interface IProcessConfigLogger
	{
		void OpenLogStream (string testName);

		void CloseLogStream ();

		void LogConceptsInModels (IDictionary<uint, IPayrollArticle> articles, IDictionary<uint, IPayrollConcept> concepts, string testName);

		void LogArticlesInConcept(IPayrollArticle article, IPayrollArticle[] articles, string testName);

		void LogRelatedArticlesInModels (IDictionary<uint, IPayrollArticle> models, string testName);

		void LogConceptArticlesCollection (IDictionary<uint, IPayrollArticle[]> collection, string testName);

		void LogConceptCodeArticles (uint concept, IPayrollArticle[] articles, string testName);

		void LogPendingArticles (IPayrollArticle article, IPayrollArticle[] articles, string testName);

		void LogRelatedArticles (IPayrollArticle article, IPayrollArticle[] articles, string testName);
	}
}

