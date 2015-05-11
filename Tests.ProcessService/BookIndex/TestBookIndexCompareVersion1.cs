using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Constants;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestBookIndexCompareVersion1
	{
		BookIndex orderOne { get; set; }
		BookIndex orderTwo { get; set; }

		[TestFixtureSetUp]
		public void TestSetup()
		{
			uint codeOrderOne = 1;
			uint codeOrderTwo = 1;
			BookParty partyOne = new BookParty(BookParty.UNKNOWN_CONTRACT, BookParty.UNKNOWN_POSITION);
			BookParty partyTwo = new BookParty(BookParty.UNKNOWN_CONTRACT, BookParty.UNKNOWN_POSITION);
			orderOne = new BookIndex(partyOne, (uint)ArticleCode.ARTICLE_INCOME_GROSS, codeOrderOne);
			orderTwo = new BookIndex(partyTwo, (uint)ArticleCode.ARTICLE_INCOME_NETTO, codeOrderTwo);
		}

		[Test]
		public void Should_Compare_TwoInstancesWith_Different_Code_And_Same_CodeOrder_AsGreater()
		{
			Assert.Greater(orderTwo, orderOne);
		}
		[Test]
		public void Should_Compare_TwoInstancesWith_Different_Code_And_Same_CodeOrder_AsLess()
		{
			Assert.Less(orderOne, orderTwo);
		}
	}
}

