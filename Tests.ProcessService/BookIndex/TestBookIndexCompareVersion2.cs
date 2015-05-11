using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Constants;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestBookIndexCompareVersion2
	{
		BookIndex orderOne { get; set; }
		BookIndex orderTwo { get; set; }

		[TestFixtureSetUp]
		public void TestSetup()
		{
			uint codeOrderOne = 1;
			uint codeOrderTwo = 2;
			BookParty partyOne = new BookParty(BookParty.UNKNOWN_CONTRACT, BookParty.UNKNOWN_POSITION);
			BookParty partyTwo = new BookParty(BookParty.UNKNOWN_CONTRACT, BookParty.UNKNOWN_POSITION);
			orderOne = new BookIndex(partyOne, (uint)ArticleSymbolCode.ARTICLE_INCOME_GROSS, codeOrderOne);
			orderTwo = new BookIndex(partyTwo, (uint)ArticleSymbolCode.ARTICLE_INCOME_GROSS, codeOrderTwo);
		}

		[Test]
		public void Should_Compare_TwoInstancesWith_Same_Code_And_Different_CodeOrder_AsGreater()
		{
			Assert.Greater(orderTwo, orderOne);
		}
		[Test]
		public void Should_Compare_TwoInstancesWith_Same_Code_And_Different_CodeOrder_AsLess()
		{
			Assert.Less(orderOne, orderTwo);
		}
	}
}

