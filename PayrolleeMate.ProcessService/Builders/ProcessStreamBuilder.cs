using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Collections;
using System.Linq;

namespace PayrolleeMate.ProcessService
{
	public static class ProcessStreamBuilder
	{
		public static ITargetStream BuildCalculationStream (ITargetStream targets, IBookParty[] contractParties, IBookParty[] positionParties, IProcessConfig configModule)
		{
			ITargetStream targetsInit = targets.CreateStreamCopy();

			IPayrollArticle[] relatedList = targetsInit.BookTargetToEvaluate ();

			ITargetStream processCalc = relatedList.Aggregate(targetsInit,
				(agr, article) => agr.MergeRealtedArticle(contractParties, positionParties, article, configModule));

			return processCalc;
		}
	}
}

