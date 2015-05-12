using NUnit.Framework;
using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using System.Reflection;
using PayrolleeMate.ProcessConfigSetCz;

namespace Tests.ProcessConfig.Factories
{
	[TestFixture ()]
	public class TestConceptFactory
	{
		[Test ()]
		public void Should_Return_ContractTaskTermConcept_As_ClassName ()
		{
			SymbolName testSpecName = ConceptSymbolName.REF_INCOME_GROSS;

			string testClassName = PayrollConceptFactory.ClassNameFor (testSpecName.Name);

			Assert.AreEqual (testClassName, "IncomeGrossConcept");
		}

		[Test ()]
		public void Should_Return_UnknownConcept_As_TypeOf ()
		{
			SymbolName testSpecName = ConceptSymbolName.REF_UNKNOWN;

			Assembly configAssembly = typeof(ProcessConfigSetCzModule).Assembly;

			IPayrollConcept testConcept = PayrollConceptFactory.ConceptFor(configAssembly, testSpecName.Name);

			Type testTypeOfConcept = testConcept.GetType();

			Assert.AreSame (typeof(UnknownConcept), testTypeOfConcept);
		}
	}
}

