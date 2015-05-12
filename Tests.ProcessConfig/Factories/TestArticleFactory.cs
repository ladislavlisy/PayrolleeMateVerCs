using NUnit.Framework;
using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Payroll.Articles;
using System.Reflection;
using PayrolleeMate.ConfigSetCz.Constants;
using PayrolleeMate.ProcessConfigSetCz;

namespace Tests.ProcessConfig.Factories
{
	[TestFixture ()]
	public class TestArticleFactory
	{
		[Test ()]
		public void Should_Return_ContractTaskTermArticle_As_ClassName ()
		{
			SymbolName testSpecName = ArticleSymbolName.REF_INCOME_GROSS;

			string testClassName = PayrollArticleFactory.ClassNameFor (testSpecName.Name);

			Assert.AreEqual (testClassName, "IncomeGrossArticle");
		}

		[Test ()]
		public void Should_Return_UnknownArticle_As_TypeOf ()
		{
			SymbolName testSpecName = ConfigSetCzArticleName.REF_UNKNOWN;

			Assembly configAssembly = typeof(ProcessConfigSetCzModule).Assembly;
				
			IPayrollArticle testArticle = PayrollArticleFactory.ArticleFor(configAssembly, testSpecName.Name);

			Type testTypeOfArticle = testArticle.GetType();

			Assert.AreSame (typeof(UnknownArticle), testTypeOfArticle);
		}
	}
}

