using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Factories;
using System.Reflection;
using Payrollee.Common.Collection;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public abstract class PayrollArticleCollection<AIDX> : GeneralCollection<IPayrollArticle, AIDX>
	{
		public PayrollArticleCollection() : base()
		{
		}

		public IPayrollArticle ArticleFromModels(Assembly configAssembly, uint articleCode)
		{
			IPayrollArticle baseArticle = InstanceFromModels(configAssembly, articleCode);

			return baseArticle;
		}

		public IPayrollArticle FindArticle(uint articleCode)
		{
			IPayrollArticle baseArticle = FindInstanceForCode(articleCode);

			return baseArticle;
		}

		#region implemented abstract members of GeneralCollection

		protected override IPayrollArticle InstanceFor(Assembly configAssembly, SymbolName configSymbol)
		{
			IPayrollArticle emptyArticle = PayrollArticleFactory.ArticleFor(configAssembly, configSymbol.Name);

			return emptyArticle;
		}

		#endregion
	}
}

