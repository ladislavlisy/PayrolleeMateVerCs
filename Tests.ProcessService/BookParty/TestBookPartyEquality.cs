using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessService.Interfaces;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestBookPartyEquality
	{
		const uint PARTY_CODE_DEFAULT = 101;

		BookParty partyOne { get; set; }
		BookParty partyTwo { get; set; }

		[TestFixtureSetUp]
		public void TestSetup()
		{
			ICodeIndex contractOrderOne = new CodeIndex (PARTY_CODE_DEFAULT, 1);
			ICodeIndex contractOrderTwo = new CodeIndex (PARTY_CODE_DEFAULT, 1);

			ICodeIndex positionOrderOne = new CodeIndex (PARTY_CODE_DEFAULT, 1);
			ICodeIndex positionOrderTwo = new CodeIndex (PARTY_CODE_DEFAULT, 1);

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

