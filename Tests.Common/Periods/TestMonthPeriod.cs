using NUnit.Framework;
using System;
using PayrolleeMate.Common.Periods;

namespace Tests.Common.Rounding
{
	[TestFixture ()]
	public class TestMonthPeriod
	{
		UInt32 testPeriodCodeJan = 201401u;
		UInt32 testPeriodCodeFeb = 201402u;
		UInt32 testPeriodCode501 = 201501u;
		UInt32 testPeriodCode402 = 201402u;

		[Test]
		public void Should_Compare_Different_Periods_AsEqual_When_2014_01()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCodeJan);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCodeJan);

			Assert.AreEqual(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_AsEqual_When_2014_02()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCodeFeb);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCodeFeb);

			Assert.AreEqual(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameYear_AsGreater()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCodeJan);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCodeFeb);

			Assert.AreNotEqual(testPeriodTwo, testPeriodOne);

			Assert.Greater(testPeriodTwo, testPeriodOne);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameYear_AsLess()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCodeJan);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCodeFeb);

			Assert.AreNotEqual(testPeriodOne, testPeriodTwo);

			Assert.Less(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameMonth_AsGreater()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCodeJan);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCode501);

			Assert.AreNotEqual(testPeriodTwo, testPeriodOne);

			Assert.Greater(testPeriodTwo, testPeriodOne);
		}
		[Test]
		public void Should_Compare_Different_Periods_SameMonth_AsLess()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCodeJan);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCode501);

			Assert.AreNotEqual(testPeriodOne, testPeriodTwo);

			Assert.Less(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Compare_Different_Periods_DifferentYear_AsGreater()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCode402);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCode501);

			Assert.AreNotEqual(testPeriodTwo, testPeriodOne);

			Assert.Greater(testPeriodTwo, testPeriodOne);
		}
		[Test]
		public void Should_Compare_Different_Periods_DifferentYear_AsLess()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCode402);

			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCode501);

			Assert.AreNotEqual(testPeriodOne, testPeriodTwo);

			Assert.Less(testPeriodOne, testPeriodTwo);
		}
		[Test]
		public void Should_Return_Periods_Year_And_Month_2014_01()
		{
			MonthPeriod testPeriodOne = new MonthPeriod (testPeriodCodeJan);

			Assert.AreEqual(testPeriodOne.Year(), 2014u);
			Assert.AreEqual(testPeriodOne.Month(), 1u);

			Assert.AreEqual(testPeriodOne.YearInt(), 2014);
			Assert.AreEqual(testPeriodOne.MonthInt(), 1);
		}
		public void Should_Return_Periods_Year_And_Month_2014_02()
		{
			MonthPeriod testPeriodTwo = new MonthPeriod (testPeriodCodeFeb);

			Assert.AreEqual(testPeriodTwo.Year(), 2014u);
			Assert.AreEqual(testPeriodTwo.Month(), 2u);

			Assert.AreEqual(testPeriodTwo.YearInt(), 2014);
			Assert.AreEqual(testPeriodTwo.MonthInt(), 2);
		}
	}
}

