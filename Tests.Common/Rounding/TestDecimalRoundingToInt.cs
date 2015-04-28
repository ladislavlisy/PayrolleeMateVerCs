using NUnit.Framework;
using System;
using PayrolleeMate.Common.Rounding;

namespace Tests.Common.Rounding
{
	[TestFixture ()]
	public class TestDecimalRoundingToInt
	{
		private const int TEST_POS_RESULT_NUMBER_DOWN = 1000;

		private const int TEST_POS_RESULT_NUMBER_UP = 1001;

		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_01_Cents()
		{
			decimal testInputs = 1000.01m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER_DOWN, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_20_Cents()
		{
			decimal testInputs = 1000.20m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER_DOWN, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_49_Cents()
		{
			decimal testInputs = 1000.49m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER_DOWN, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_50_Cents()
		{
			decimal testInputs = 1000.50m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER_UP, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_51_Cents()
		{
			decimal testInputs = 1000.51m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER_UP, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_60_Cents()
		{
			decimal testInputs = 1000.60m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER_UP, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_99_Cents()
		{
			decimal testInputs = 1000.99m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER_UP, testResult);
		}

		private const int TEST_NEG_RESULT_NUMBER_DOWN = -1000;

		private const int TEST_NEG_RESULT_NUMBER_UP = -1001;

		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_01_Cents()
		{
			decimal testInputs = -1000.01m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER_DOWN, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_20_Cents()
		{
			decimal testInputs = -1000.20m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER_DOWN, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_49_Cents()
		{
			decimal testInputs = -1000.49m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER_DOWN, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_50_Cents()
		{
			decimal testInputs = -1000.50m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER_UP, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_51_Cents()
		{
			decimal testInputs = -1000.51m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER_UP, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_60_Cents()
		{
			decimal testInputs = -1000.60m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER_UP, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_99_Cents()
		{
			decimal testInputs = -1000.99m;
			int testResult = IntRounding.RoundToInt(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER_UP, testResult);
		}
	}
}

