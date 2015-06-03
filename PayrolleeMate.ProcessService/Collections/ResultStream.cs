using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;

namespace PayrolleeMate.ProcessService
{
	public class ResultStream : IResultStream
	{
		public static IResultStream CreateEmptyStream()
		{
			var results = new Dictionary<IBookIndex, IBookResult>();

			return new ResultStream(results);
		}

		public ResultStream(IDictionary<IBookIndex, IBookResult> results)
		{
			this.__results = results;
		}
			
		private IDictionary<IBookIndex, IBookResult> __results = null;

		#region IResultStream implementation

		public IDictionary<IBookIndex, IBookResult> Results ()
		{
			return __results;
		}

		public IBookResult GetResultBy (uint articleCode)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

