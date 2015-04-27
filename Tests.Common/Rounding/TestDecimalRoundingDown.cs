﻿using NUnit.Framework;
using System;
using PayrolleeMate.Common.Rounding;

namespace Tests.Common.Rounding
{
	[TestFixture ()]
	public class TestDecimalRoundingDown
	{
		private readonly decimal TEST_POS_RESULT_NUMBER = 1000m;

		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_01_Cents()
		{
			decimal testInputs = 1000.01m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_20_Cents()
		{
			decimal testInputs = 1000.20m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_50_Cents()
		{
			decimal testInputs = 1000.50m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_60_Cents()
		{
			decimal testInputs = 1000.60m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_1000_for_Decimal_with_99_Cents()
		{
			decimal testInputs = 1000.99m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_POS_RESULT_NUMBER, testResult);
		}

		private readonly decimal TEST_NEG_RESULT_NUMBER = -1000m;

		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_01_Cents()
		{
			decimal testInputs = -1000.01m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_20_Cents()
		{
			decimal testInputs = -1000.20m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_50_Cents()
		{
			decimal testInputs = -1000.50m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_60_Cents()
		{
			decimal testInputs = -1000.60m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
		[Test()]
		public void Should_return_Rounded_Negative_1000_for_Decimal_with_99_Cents()
		{
			decimal testInputs = -1000.99m;
			decimal testResult = DecRounding.RoundDown(testInputs);
			Assert.AreEqual(TEST_NEG_RESULT_NUMBER, testResult);
		}
	}
}

