using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;

namespace Tests.ProcessConfig.Logers
{
	public class TestEmptyLogger : IProcessConfigLogger
	{
		public TestEmptyLogger (string testNamespace)
		{
		}

		#region IProcessConfigLogger implementation

		public void OpenLogStream (string testName)
		{
		}

		public void CloseLogStream ()
		{
		}

		public void LogAppendMessageInfo (string message, string testName)
		{
		}

		public void LogConceptsInModels (IDictionary<uint, IPayrollArticle> articles, IDictionary<uint, IPayrollConcept> concepts, string testName)
		{
		}

		public void LogListArticlesUnderArticle (IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
		}

		public void LogRelatedArticlesInModels (IDictionary<uint, IPayrollArticle> models, string testName)
		{
		}

		public void LogDependentArticlesCollection (IDictionary<uint, IPayrollArticle[]> collection, string testName)
		{
		}

		public void LogDependentCodeArticlesInfo (uint articleCode, IPayrollArticle[] articles, string testName)
		{
		}

		public void LogPendingArticles (IPayrollArticle article, SymbolName[] callings, IPayrollArticle[] articles, string testName)
		{
		}

		public void LogRelatedArticles (IPayrollArticle article, IPayrollArticle[] articles, string testName)
		{
		}

		#endregion
	}
}

