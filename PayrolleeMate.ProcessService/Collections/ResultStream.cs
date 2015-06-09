using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Comparers;
using System.Linq;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Items;

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

		public IResultValues GetContractResult (ICodeIndex contract)
		{
			var resultsList = __results.Where(x => x.Key.GetIndex().Equals(contract)).
				Select(c => c.Value.Values()).ToArray();

			var partyResult = resultsList.DefaultIfEmpty(ResultValues.GetEmpty()).FirstOrDefault();

			return partyResult;
		}

		public IResultValues GetPositionResult (IBookParty position)
		{
			var resultsList = __results.Where(x => x.Key.ContractIndex().Equals(position.ContractIndex()) && 
				x.Key.GetIndex().Equals(position.PositionIndex())).
				Select(c => c.Value.Values()).ToArray();

			var partyResult = resultsList.DefaultIfEmpty(ResultValues.GetEmpty()).FirstOrDefault();

			return partyResult;
		}

		public IList<IResultValues> GetContractPartyResultList (ICodeIndex contract, uint articleCode)
		{
			var resultsList = __results.Where(x => x.Key.ContractIndex().Equals(contract) && x.Key.Code()==articleCode).
				Select(c => c.Value.Values()).ToList();

			return resultsList;
		}

		public IList<IResultValues> GetPositionPartyResultList (IBookParty position, uint articleCode)
		{
			var resultsList = __results.Where(x => x.Key.ContractIndex().Equals(position.ContractIndex()) && 
				x.Key.PositionIndex().Equals(position.PositionIndex()) && x.Key.Code()==articleCode).
				Select(c => c.Value.Values()).ToArray();

			return resultsList;
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

