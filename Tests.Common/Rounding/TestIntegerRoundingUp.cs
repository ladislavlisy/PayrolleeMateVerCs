using NUnit.Framework;
using System;
using PayrolleeMate.Common.Rounding;

namespace Tests.Common.Rounding
{
	[TestFixture ()]
	public class TestIntegerRoundingUp
	{
		private const int TEST_POS_RESULT_NUMBER = 1001;

		[Test()]
		public void Should_return_Rounded_1001_for_Decimal_with_01_Cents()
		{
			decimal testInputs = 1000.01m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1001_for_Decimal_with_20_Cents()
		{
			decimal testInputs = 1000.20m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1001_for_Decimal_with_50_Cents()
		{
			decimal testInputs = 1000.50m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1001_for_Decimal_with_60_Cents()
		{
			decimal testInputs = 1000.60m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1001_for_Decimal_with_99_Cents()
		{
			decimal testInputs = 1000.99m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}

		private const int TEST_NEG_RESULT_NUMBER = -1001;

		[Test()]
		public void Should_return_Rounded_Negative_1001_for_Decimal_with_01_Cents()
		{
			decimal testInputs = -1000.01m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1001_for_Decimal_with_20_Cents()
		{
			decimal testInputs = -1000.20m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1001_for_Decimal_with_50_Cents()
		{
			decimal testInputs = -1000.50m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1001_for_Decimal_with_60_Cents()
		{
			decimal testInputs = -1000.60m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1001_for_Decimal_with_99_Cents()
		{
			decimal testInputs = -1000.99m;
			long testResult = IntRounding.RoundUp(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
	}
}

