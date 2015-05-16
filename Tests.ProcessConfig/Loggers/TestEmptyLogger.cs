using System;
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

		public void LogConceptsInModels (System.Collections.Generic.IDictionary<uint, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle> articles, System.Collections.Generic.IDictionary<uint, PayrolleeMate.ProcessConfig.Interfaces.IPayrollConcept> concepts, string testName)
		{
		}

		public void LogArticlesInConcept (PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle article, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle[] articles, string testName)
		{
		}

		public void LogRelatedArticlesInModels (System.Collections.Generic.IDictionary<uint, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle> models, string testName)
		{
		}

		public void LogDependentArticlesCollection (System.Collections.Generic.IDictionary<uint, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle[]> collection, string testName)
		{
		}

		public void LogDependentCodeArticlesInfo (uint articleCode, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle[] articles, string testName)
		{
		}

		public void LogPendingArticles (PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle article, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle[] pendings, PayrolleeMate.Common.SymbolName[] callings, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle[] articles, string testName)
		{
		}

		public void LogRelatedArticles (PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle article, PayrolleeMate.ProcessConfig.Interfaces.IPayrollArticle[] articles, string testName)
		{
		}

		public void LogAppendMessageInfo (string message, string testName)
		{
		}

		#endregion
	}
}

