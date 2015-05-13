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

		void LogArticlesInConcept(IPayrollConcept concept, IPayrollArticle[] articles, string testName);

		void LogConceptsInModels (IDictionary<uint, IPayrollConcept> models, string testName);

		void LogRelatedArticlesInModels (IDictionary<uint, IPayrollConcept> models, string testName);

		void LogConceptArticlesCollection (IDictionary<uint, IPayrollArticle[]> collection, string testName);

		void LogConceptCodeArticles (uint concept, IPayrollArticle[] articles, string testName);

		void LogPendingArticles (IPayrollArticle article, IPayrollArticle[] articles, string testName);

		void LogRelatedArticles (IPayrollArticle article, IPayrollArticle[] articles, string testName);
	}
}

