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
	}
}

