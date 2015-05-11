using NUnit.Framework;
using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Payroll.Articles;

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
			SymbolName testSpecName = ArticleSymbolName.REF_UNKNOWN;

			IPayrollArticle testArticle = PayrollArticleFactory.ArticleFor(testSpecName.Name);

			Type testTypeOfArticle = testArticle.GetType();

			Assert.AreSame (typeof(UnknownArticle), testTypeOfArticle);
		}
	}
}

