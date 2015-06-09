using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IResultStream
	{
		IDictionary<IBookIndex, IBookResult> Results ();

		IBookResult GetResultBy(uint articleCode);

		IResultStream AggregateResultList (IBookResult[] resultList);

		IResultValues GetContractResult (ICodeIndex contract);

		IResultValues GetPositionResult (IBookParty position);

		IList<IResultValues> GetContractPartyResultList (ICodeIndex contract, uint articleCode);

		IList<IResultValues> GetPositionPartyResultList (IBookParty position, uint articleCode);

		IList<IResultValues> GetContractPartySummaryList (ICodeIndex contract, uint summaryCode);

		IList<IResultValues> GetPositionPartySummaryList (IBookParty position, uint summaryCode);
	}
}

