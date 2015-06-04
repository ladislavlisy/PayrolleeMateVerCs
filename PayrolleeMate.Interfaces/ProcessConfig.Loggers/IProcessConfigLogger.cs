using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Collections.Generic;
using System.IO;
using PayrolleeMate.Common;
using PayrolleeMate.Common.Interfaces;

namespace PayrolleeMate.ProcessConfig.Interfaces.Loggers
{
	public interface IProcessConfigLogger : IGeneralLogger
	{
		void LogConceptsInModels (IDictionary<uint, IPayrollArticle> articles, IDictionary<uint, IPayrollConcept> concepts, string testName);

		void LogListArticlesUnderArticle(IPayrollArticle article, IPayrollArticle[] articles, string testName);

		void LogRelatedArticlesInModels (IDictionary<uint, IPayrollArticle> models, string testName);

		void LogDependentArticlesCollection (IDictionary<uint, IPayrollArticle[]> collection, string testName);

		void LogDependentCodeArticlesInfo (uint articleCode, IPayrollArticle[] articles, string testName);

		void LogPendingArticles (IPayrollArticle article, SymbolName[] callings, IPayrollArticle[] articles, string testName);

		void LogRelatedArticles (IPayrollArticle article, IPayrollArticle[] articles, string testName);

		void LogArticlesNames (IPayrollArticle[] articles, string testName);
	}
}

