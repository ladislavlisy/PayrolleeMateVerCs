using System;
using System.Collections.Generic;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IResultStream
	{
		IDictionary<IBookIndex, IBookResult> Results ();

		IBookResult GetResultBy(uint articleCode);
	}
}

