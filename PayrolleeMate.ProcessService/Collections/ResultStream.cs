using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Comparers;
using System.Linq;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService
{
	public class ResultStream : IResultStream
	{
		public static IResultStream CreateEmptyStream()
		{
			var results = new Dictionary<IBookIndex, IBookResult>();

			return new ResultStream(results);
		}

		private ResultStream(IDictionary<IBookIndex, IBookResult> results)
		{
			this.__results = results;
		}
			
		private IDictionary<IBookIndex, IBookResult> __results = null;

		#region IResultStream implementation

		public IDictionary<IBookIndex, IBookResult> Results ()
		{
			return __results;
		}

		public IResultStream AggregateResultList (IBookResult[] resultList)
		{
			var results = resultList.Select(x => x).
				ToDictionary(key => key.Element(), val => val);

			return BuildResultStream(results);
		}

		public IBookResult GetResultBy (uint articleCode)
		{
			throw new NotImplementedException ();
		}

		#endregion

		private IResultStream BuildResultStream (IDictionary<IBookIndex, IBookResult> resultDict)
		{
			var results = __results.Union(resultDict, new BookIndexComparer()).
				ToDictionary(key => key.Key, val => val.Value);

			return new ResultStream(results);
		}

	}
}

