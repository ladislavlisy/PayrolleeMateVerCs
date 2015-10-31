using NUnit.Framework;
using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common.Core;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfigSetCz;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using Tests.ProcessConfig.Logers;

namespace Tests.ProcessConfig.Collections
{
	[TestFixture ()]
	public class TestConceptCollection
	{
		IProcessConfig testConfig = null;

		[TestFixtureSetUp]
		public void TestSetup()
		{
			IProcessConfigLogger logger = new TestEmptyLogger ("TestConceptCollection");

			testConfig = ProcessConfigSetCzModule.CreateModule(logger);

			testConfig.InitModule ();

			logger.CloseLogStream ();
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

