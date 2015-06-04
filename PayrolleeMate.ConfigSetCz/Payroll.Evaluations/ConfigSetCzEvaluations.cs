using System;
using PayrolleeMate.Common.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Patterns;

namespace PayrolleeMate.ProcessConfigSetCz.Evaluations
{
	public static class ConfigSetCzEvaluations
	{
		public static GeneralModule.EvaluateDelegate EmptyEvaluation = (config, engine, article, element, values, results) => {

			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate CloneEvaluation = (config, engine, article, element, values, results) => {

			IBookResult result = new EmptyBookResult(element, article);

			IBookResult[] evaluatedResults = new IBookResult[] { result };

			return evaluatedResults;
		};

		public static GeneralModule.EvaluateDelegate SalaryMonthlyEvaluation = (config, engine, article, element, values, results) => {

			IBookResult result = new EmptyBookResult(element, article);

			IBookResult[] evaluatedResults = new IBookResult[] { result };

			return evaluatedResults;
		};

	}
}

