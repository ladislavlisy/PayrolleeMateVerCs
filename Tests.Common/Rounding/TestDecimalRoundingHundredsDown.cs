using NUnit.Framework;
using System;
using PayrolleeMate.Common.Rounding;

namespace Tests.Common.Rounding
{
	[TestFixture ()]
	public class TestDecimalRoundingHundredsDown
	{
		private const decimal TEST_POS_RESULT_NUMBER = 1000m;

		private const int TEST_NEAREST_NUMBER = 100;

		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_1090_with_01_Cents()
		{
			decimal testInputs = 1090.01m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_1090_with_20_Cents()
		{
			decimal testInputs = 1090.20m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_1090_with_50_Cents()
		{
			decimal testInputs = 1090.50m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_1090_with_60_Cents()
		{
			decimal testInputs = 1090.60m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_1090_with_99_Cents()
		{
			decimal testInputs = 1090.99m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}

		private const decimal TEST_NEG_RESULT_NUMBER = -1000m;

		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_1090_with_01_Cents()
		{
			decimal testInputs = -1090.01m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_1090_with_20_Cents()
		{
			decimal testInputs = -1090.20m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_1090_with_50_Cents()
		{
			decimal testInputs = -1090.50m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_1090_with_60_Cents()
		{
			decimal testInputs = -1090.60m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_1090_with_99_Cents()
		{
			decimal testInputs = -1090.99m;
			decimal testResult = DecRounding.NearRoundDown(testInputs, TEST_NEAREST_NUMBER);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
	}
}

