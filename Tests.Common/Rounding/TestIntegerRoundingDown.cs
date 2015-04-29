using NUnit.Framework;
using System;
using PayrolleeMate.Common.Rounding;

namespace Tests.Common.Rounding
{
	[TestFixture ()]
	public class TestIntegerRoundingDown
	{
		private const Int32 TEST_POS_RESULT_NUMBER = 1000;

		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_01_Cents()
		{
			decimal testInputs = 1000.01m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_20_Cents()
		{
			decimal testInputs = 1000.20m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_50_Cents()
		{
			decimal testInputs = 1000.50m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_60_Cents()
		{
			decimal testInputs = 1000.60m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_99_Cents()
		{
			decimal testInputs = 1000.99m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}

		private const Int32 TEST_NEG_RESULT_NUMBER = -1000;

		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_01_Cents()
		{
			decimal testInputs = -1000.01m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_20_Cents()
		{
			decimal testInputs = -1000.20m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_50_Cents()
		{
			decimal testInputs = -1000.50m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_60_Cents()
		{
			decimal testInputs = -1000.60m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_99_Cents()
		{
			decimal testInputs = -1000.99m;
			Int32 testResult = IntRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
	}
}

