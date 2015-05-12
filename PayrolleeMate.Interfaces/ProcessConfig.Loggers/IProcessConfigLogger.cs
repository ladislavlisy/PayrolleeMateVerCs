using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Collections.Generic;

namespace PayrolleeMate.ProcessConfig.Interfaces.Loggers
{
	public interface IProcessConfigLogger
	{
		void LogArticlesInConcept(IPayrollConcept concept, IPayrollArticle[] articles, string testName);

		void LogConceptsInModels (IDictionary<uint, IPayrollConcept> models, string testName);

		void LogRelatedArticlesInModels (IDictionary<uint, IPayrollConcept> models, string testName);
	}
}

