using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessConfig.Payroll.Articles;
using System.Reflection;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public class PayrollArticleCollection
	{
		public PayrollArticleCollection()
		{
			this.Models = new Dictionary<ArticleSymbolCode, IPayrollArticle>();

			this.Models[ArticleSymbolCode.ARTICLE_UNKNOWN] = new UnknownArticle();
		}

		public IDictionary<ArticleSymbolCode, IPayrollArticle> Models { get; private set; }

		#region Article Dictionary

		public IPayrollArticle ArticleFromModels(Assembly assemblyConfigSet, uint articleCode)
		{
			ArticleSymbolCode articleIndex = (ArticleSymbolCode)articleCode;

			IPayrollArticle baseArticle = null;

			if (!Models.ContainsKey(articleIndex))
			{
				baseArticle = EmptyArticleFor(assemblyConfigSet, articleCode);

				Models[articleIndex] = baseArticle;
			}
			else
			{
				baseArticle = Models[articleIndex];
			}
			return baseArticle;
		}

		public IPayrollArticle FindArticle(uint articleCode)
		{
			ArticleSymbolCode articleIndex = (ArticleSymbolCode)articleCode;

			IPayrollArticle baseArticle = null;

			if (Models.ContainsKey(articleIndex))
			{
				baseArticle = Models[articleIndex];
			}
			else
			{
				baseArticle = Models[ArticleSymbolCode.ARTICLE_UNKNOWN];
			}
			return baseArticle;
		}

		public IPayrollArticle EmptyArticleFor(Assembly assemblyConfigSet, uint articleCode)
		{
			ArticleSymbolCode articleIndex = (ArticleSymbolCode)articleCode;

			SymbolName articleSymbol = articleIndex.GetSymbol ();

			IPayrollArticle emptyArticle = PayrollArticleFactory.ArticleFor(assemblyConfigSet, articleSymbol.Name);

			return emptyArticle;
		}

		#endregion
	}
}

