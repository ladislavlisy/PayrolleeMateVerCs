using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using System.Reflection;
using System.Text.RegularExpressions;
using PayrolleeMate.Common.Libs;

namespace PayrolleeMate.ProcessConfig.Factories
{
	public static class PayrollConceptFactory
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.ProcessConfig.Payroll.Concepts";

		#region Dynamic Creation

		public static IPayrollConcept ConceptFor(Assembly configAssembly, string conceptName)
		{
			string conceptClass = ClassNameFor(conceptName);

			return GeneralFactory<IPayrollConcept>.InstanceFor (configAssembly, NAME_SPACE_PREFIX, conceptClass);
		}

		public static string ClassNameFor(string conceptName)
		{
			Regex regexObj = new Regex("CONCEPT_(.*)", RegexOptions.Singleline);
			Match matchResult = regexObj.Match(conceptName);
			string matchResultName = "";
			if (matchResult.Success)
			{
				GroupCollection regexCol = matchResult.Groups;
				if (regexCol.Count == 2)
				{
					matchResultName = regexCol[1].Value;
				}
			}
			string className = matchResultName.Underscore().Camelize() + "Concept";

			return className;
		}

		#endregion

	}
}

