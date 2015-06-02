using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface ITargetStream
	{
		IDictionary<IBookIndex, IBookTarget> Targets ();

		IBookParty[] CollectPartiesForContracts ();

		IBookParty[] CollectPartiesForPositions ();

		ITargetStream CreateStreamCopy ();

		IPayrollArticle[] BookTargetToEvaluate ();

		ITargetStream MergeRealtedArticle (IBookParty[] contractParties, IBookParty[] positionParties, 
			IPayrollArticle article, IProcessConfig configModule);
	}
}

