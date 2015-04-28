using System;
using System.Collections.Generic;
using PayrolleeMate.Common.Periods;
using System.Linq;
using Payrollee.Common;

namespace PayrolleeMate.EngineService.Core
{
	public static class EngineFactory<T>
	{
		public static T InstanceFor (string namespacePrefix, SpanOfYears span)
		{
			return GeneralFactory<T>.InstanceFor(namespacePrefix, span.ToString());
		}
	}

}

