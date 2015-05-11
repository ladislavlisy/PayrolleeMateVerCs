using NUnit.Framework;
using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfig;

namespace Tests.ProcessConfig.Collections
{
	[TestFixture ()]
	public class TestConceptCollection
	{
		IProcessConfig testConfig = null;

		[TestFixtureSetUp]
		public void TestSetup()
		{
			testConfig = ProcessConfigModule.CreateModule();

			testConfig.InitModule ();
		}

		[Test ()]
		public void Should_Return_UnknownConcept_From_Models ()
		{
			SymbolName testSpecName = ConceptSymbolName.REF_UNKNOWN;

			IPayrollConcept testConcept = testConfig.FindConcept (testSpecName.Code);

			Type testTypeOfConcept = testConcept.GetType();

			Assert.AreSame (typeof(UnknownConcept), testTypeOfConcept);

			Assert.AreEqual (testConcept.ConceptCode(), testSpecName.Code);
		}
	}
}

