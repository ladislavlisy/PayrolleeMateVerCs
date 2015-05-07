using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Constants;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestBookPartyEquality
	{
		BookParty partyOne { get; set; }
		BookParty partyTwo { get; set; }

		[TestFixtureSetUp]
		public void TestSetup()
		{
			uint contractOrderOne = 1;
			uint contractOrderTwo = 1;

			uint positionOrderOne = 1;
			uint positionOrderTwo = 1;

			partyOne = new BookParty(contractOrderOne, positionOrderOne);
			partyTwo = new BookParty(contractOrderTwo, positionOrderTwo);
		}

		[Test]
		public void Should_Equal_TwoInstances_With_Same_ContractOrder_And_PositionOrder()
		{
			Assert.AreEqual(partyOne, partyTwo);
		}
	}
}

