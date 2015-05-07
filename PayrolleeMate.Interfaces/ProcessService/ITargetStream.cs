using System;
using System.Collections.Generic;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface ITargetStream
	{
		IDictionary<IBookIndex, IBookTarget> Targets ();
	}
}

