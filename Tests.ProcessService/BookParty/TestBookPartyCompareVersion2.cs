﻿using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessService.Interfaces;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestBookPartyCompareVersion2
	{
		const uint PARTY_CODE_DEFAULT = 101;

		BookParty partyOne { get; set; }
		BookParty partyTwo { get; set; }

		[TestFixtureSetUp]
		public void TestSetup()
		{
			ICodeIndex contractOrderOne = new CodeIndex (PARTY_CODE_DEFAULT, 1);
			ICodeIndex positionOrderOne = new CodeIndex (PARTY_CODE_DEFAULT, 1);

			ICodeIndex contractOrderTwo = new CodeIndex (PARTY_CODE_DEFAULT, 1);
			ICodeIndex positionOrderTwo = new CodeIndex (PARTY_CODE_DEFAULT, 2);

			partyOne = new BookParty(contractOrderOne, positionOrderOne);
			partyTwo = new BookParty(contractOrderTwo, positionOrderTwo);
		}

		[Test]
		public void Should_Compare_TwoInstancesWith_Same_ContractOrderAnd_Different_PositionOrder_AsGreater()
		{
			Assert.Greater(partyTwo, partyOne);
		}
		[Test]
		public void Should_Compare_TwoInstancesWith_Same_ContractOrderAnd_Different_PositionOrder_AsLess()
		{
			Assert.Less(partyOne, partyTwo);
		}
	}
}

