using System;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.Common;
using PayrolleeMate.Common.Periods;
using System.Reflection;

namespace PayrolleeMate.EngineService.Core
{
	public static class EngineFactory<T>
	{
		public static T InstanceFor (string namespacePrefix, string classnamePrefix, SpanOfYears span)
		{
			Assembly assembly = typeof(EngineServiceModule).Assembly;

			return GeneralFactory<T>.InstanceFor(assembly, namespacePrefix, ClassNameFor(classnamePrefix, span));
		}

		public static string ClassNameFor(string classnamePrefix, SpanOfYears span)
		{
			string className = classnamePrefix + span.ClassName();

			return className;
		}
		}

}

