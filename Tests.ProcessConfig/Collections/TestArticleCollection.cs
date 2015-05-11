﻿using NUnit.Framework;
using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfigSetCz;
using PayrolleeMate.ProcessConfig.Payroll.Articles;

namespace Tests.ProcessConfig.Collections
{
	[TestFixture ()]
	public class TestArticleCollection
	{
		IProcessConfig testConfig = null;

		[TestFixtureSetUp]
		public void TestSetup()
		{
			testConfig = ProcessConfigSetCzModule.CreateModule();

			testConfig.InitModule ();
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
	}
}

