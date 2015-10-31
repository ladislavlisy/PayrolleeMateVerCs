using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Comparers;
using System.Linq;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Items;
using PayrolleeMate.Common.Core;

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
			var resultsList = __results.Where(x => ResultListUtils.IsEqualToContractArticle(contract, x.Key)).
				Select(c => c.Value.Values()).ToArray();

			var partyResult = resultsList.DefaultIfEmpty(ResultValues.GetEmpty()).FirstOrDefault();

			return partyResult;
		}

		public IResultValues GetPositionResult (IBookParty position)
		{
			var resultsList = __results.Where(x => ResultListUtils.IsEqualToPositionArticle(position, x.Key)).
				Select(c => c.Value.Values()).ToArray();

			var partyResult = resultsList.DefaultIfEmpty(ResultValues.GetEmpty()).FirstOrDefault();

			return partyResult;
		}

		public IList<IResultValues> GetContractPartyResultList (ICodeIndex contract, uint articleCode)
		{
			var resultsList = __results.Where(x => ResultListUtils.IsEqualToContractParty(contract, x.Key) && 
				x.Key.Code()==articleCode).
				Select(c => c.Value.Values()).ToList();

			return resultsList;
		}

		public IList<IResultValues> GetPositionPartyResultList (IBookParty position, uint articleCode)
		{
			var resultsList = __results.Where(x => ResultListUtils.IsEqualToPositionParty(position, x.Key) && 
				x.Key.Code()==articleCode).
				Select(c => c.Value.Values()).ToArray();

			return resultsList;
		}

		public IList<IResultValues> GetContractPartySummaryList (ICodeIndex contract, uint summaryCode)
		{
			var resultsList = __results.Where(x => ResultListUtils.IsEqualToContractParty(contract, x.Key) && 
				ResultListUtils.SummaryArticlesFilter(x.Value.Article(), summaryCode)).
				Select(c => c.Value.Values()).ToArray();

			return resultsList;
		}

		public IList<IResultValues> GetPositionPartySummaryList (IBookParty position, uint summaryCode)
		{
			var resultsList = __results.Where(x => ResultListUtils.IsEqualToPositionParty(position, x.Key) && 
				ResultListUtils.SummaryArticlesFilter(x.Value.Article(), summaryCode)).
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

		private static class ResultListUtils
		{
			public static bool IsEqualToContractArticle(ICodeIndex contract, IBookIndex element)
			{
				return element.GetIndex().Equals(contract);
			}

			public static bool IsEqualToPositionArticle(IBookParty position, IBookIndex element)
			{
				return element.ContractIndex().Equals(position.ContractIndex()) && 
					element.GetIndex().Equals(position.PositionIndex());
			}

			public static bool IsEqualToContractParty(ICodeIndex contract, IBookIndex element)
			{
				return element.ContractIndex().Equals(contract);
			}

			public static bool IsEqualToPositionParty(IBookParty position, IBookIndex element)
			{
				return element.ContractIndex().Equals(position.ContractIndex()) && 
					element.PositionIndex().Equals(position.PositionIndex());
			}

			public static bool SummaryArticlesFilter(IPayrollArticle article, uint summaryCode)
			{
				return CountSummaryArticles(article.SummaryArticleNames(), summaryCode) != 0;
			}

			private static int CountSummaryArticles(SymbolName[] articles, uint articleCode)
			{
				if (articles == null)
				{
					return 0;
				}
				SymbolName[] _articles = articles.Where(x => x.Code == articleCode).ToArray<SymbolName>();

				return _articles.Length;
			}		
		}
	}
}

