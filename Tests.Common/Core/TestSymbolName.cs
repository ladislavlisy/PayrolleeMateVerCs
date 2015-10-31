using NUnit.Framework;
using System;
using PayrolleeMate.Common.Core;

namespace Tests.Common.Core
{
	[TestFixture ()]
	public class TestSymbolName
	{
		UInt32 testSymbolCode1001 = 1001u;
		UInt32 testSymbolCode2001 = 2001u;
		UInt32 testSymbolCode3001 = 3001u;
		UInt32 testSymbolCode4001 = 4001u;
		UInt32 testSymbolCode5001 = 5001u;

		[Test]
		public void Should_Compare_Different_Symbols_AsEqual()
		{
			SymbolName testSymbolOne = new SymbolName(testSymbolCode1001, "Begining Symbol");

			SymbolName testSymbolTwo = new SymbolName(testSymbolCode1001, "Terminal Symbol");

			Assert.AreEqual(testSymbolOne, testSymbolTwo);
		}
		[Test]
		public void Should_Compare_Different_Symbols_AsGreater()
		{
			SymbolName testSymbolOne = new SymbolName(testSymbolCode1001, "Begining Symbol");

			SymbolName testSymbolTwo = new SymbolName(testSymbolCode5001, "Terminal Symbol");

			Assert.AreNotEqual(testSymbolTwo, testSymbolOne);

			Assert.Greater(testSymbolTwo, testSymbolOne);
		}
		[Test]
		public void Should_Compare_Different_Symbols_AsLess()
		{
			SymbolName testSymbolOne = new SymbolName(testSymbolCode1001, "Begining Symbol");

			SymbolName testSymbolTwo = new SymbolName(testSymbolCode5001, "Terminal Symbol");

			Assert.AreNotEqual(testSymbolOne, testSymbolTwo);

			Assert.Less(testSymbolOne, testSymbolTwo);
		}
	}
}
