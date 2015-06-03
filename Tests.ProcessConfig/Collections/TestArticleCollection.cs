using NUnit.Framework;
using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfigSetCz;
using PayrolleeMate.ProcessConfig.Payroll.Articles;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using Tests.ProcessConfig.Logers;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.ProcessConfig.Comparers;

namespace Tests.ProcessConfig.Collections
{
	[TestFixture ()]
	public class TestArticleCollection
	{
		IProcessConfig testConfig = null;

		[TestFixtureSetUp]
		public void TestSetup()
		{
			IProcessConfigLogger logger = new TestConfigLogger ("TestArticleCollection");

			testConfig = ProcessConfigSetCzModule.CreateModule(logger);

			testConfig.InitModule ();

			logger.CloseLogStream ();
		}

		[Test ()]
		public void Should_Return_UnknownArticle_From_Models ()
		{
			SymbolName testSpecName = ArticleSymbolName.REF_UNKNOWN;

			IPayrollArticle testArticle = testConfig.FindArticle (testSpecName.Code);

			Type testTypeOfArticle = testArticle.GetType();

			Assert.AreSame (typeof(UnknownArticle), testTypeOfArticle);

			Assert.AreEqual (testArticle.ArticleCode(), testSpecName.Code);
		}

		[Test ()]
		public void Should_Compare_AmountConcept_After_TSheetConcept ()
		{
			SymbolName testAmountName = ConfigSetCzArticleName.REF_SALARY_BASE;

			SymbolName testTSheetName = ConfigSetCzArticleName.REF_TIMEHOURS_ABSENCE;

			IPayrollArticle testAmountArticle = testConfig.FindArticle (testAmountName.Code);

			IPayrollArticle testTSheetArticle = testConfig.FindArticle (testTSheetName.Code);

			int compareResult = ArticleDependencyComparer.CompareArticles (testAmountArticle, testTSheetArticle);

			Assert.IsTrue (compareResult > 0);
		}
	}
}

