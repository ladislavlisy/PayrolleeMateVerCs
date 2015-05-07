using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Constants;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestBookPartyCompareVersion4
	{
		BookParty partyOne { get; set; }
		BookParty partyTwo { get; set; }

		[TestFixtureSetUp]
		public void TestSetup()
		{
			uint contractOrderOne = 1;
			uint positionOrderOne = 2;

			uint contractOrderTwo = 2;
			uint positionOrderTwo = 1;

			partyOne = new BookParty(contractOrderOne, positionOrderOne);
			partyTwo = new BookParty(contractOrderTwo, positionOrderTwo);
		}

		[Test]
		public void Should_Compare_TwoInstancesWith_Different_ContractOrder_And_PositionOrder_AsGreater()
		{
			Assert.Greater(partyTwo, partyOne);
		}
		[Test]
		public void Should_Compare_TwoInstancesWith_Different_ContractOrder_And_PositionOrder_AsLess()
		{
			Assert.Less(partyOne, partyTwo);
		}
	}
}

