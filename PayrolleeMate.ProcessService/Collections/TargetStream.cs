using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Interfaces;
using Payrollee.Common;

namespace PayrolleeMate.ProcessService
{
	public class TargetStream : ITargetStream
	{
		private static class BookIndexConparator
		{
			static public uint GetFirstIndex(IEnumerable<IBookIndex> targets, IBookParty party, uint code)
			{
				IEnumerable<IBookIndex> selectedBooks = SelectEquals(targets, party, code);

				IEnumerable<uint> selectedOrders = ExtractCodeOrders(selectedBooks);

				return GetFirstIndexFrom(selectedOrders.OrderBy(x => x).ToArray());
			}

			static public uint GetNewOrder(IEnumerable<IBookIndex> targets, IBookParty party, uint code)
			{
				IEnumerable<IBookIndex> selectedBooks = SelectEquals(targets, party, code);

				IEnumerable<uint> selectedOrders = ExtractCodeOrders(selectedBooks);

				return GetNewIndexFrom(selectedOrders.OrderBy(x => x).ToArray());
			}

			#region Support Members

			static private IEnumerable<IBookIndex> SelectEquals(IEnumerable<IBookIndex> targets, IBookParty party, uint code)
			{
				return targets.Where(x => (x.isEqualToParty(party) && x.Code() == code)).ToArray();
			}

			static private IEnumerable<uint> ExtractCodeOrders(IEnumerable<IBookIndex> termCollection)
			{
				return termCollection.Select(x => x.CodeOrder()).ToArray();
			}

			static private uint GetFirstIndexFrom(ICollection<uint> sortedOrders)
			{
				uint firstCodeOrder = sortedOrders.DefaultIfEmpty((uint)1).First();
				return firstCodeOrder;
			}

			static private uint GetNewIndexFrom(ICollection<uint> sortedOrders)
			{
				uint lastCodeOrder = sortedOrders.Aggregate((uint)0, (agr, x) => (((x > agr) && (x - agr) > 1) ? agr : x));
				return (lastCodeOrder + 1);
			}

			#endregion
		}

		static class TargetsTupleComposer
		{
			public static Tuple<IBookIndex, IDictionary<IBookIndex, IBookTarget>> AddTargetBySymbol(
				IDictionary<IBookIndex, IBookTarget> targets, 
				IBookParty party, SymbolName articleName, ITargetValues values, IProcessConfig config)
			{
				uint newCodeOrder = BookIndexConparator.GetNewOrder(targets.Keys, party, articleName.Code);

				KeyValuePair<IBookIndex, IBookTarget> pairToMerge = BookKeyValuePairComposer
					.ComposeTargetWithArticleAndOrder(party, articleName, newCodeOrder, values, config);

				var targetIndex = pairToMerge.Key;

				var targetValue = pairToMerge.Value;

				var bookTargets = TargetsDictComposer.MergeDictWithTokenAndValue(targets, targetIndex, targetValue);

				return Tuple.Create<IBookIndex, IDictionary<IBookIndex, IBookTarget>>(targetIndex, bookTargets);
			}
		}

		static class BookKeyValuePairComposer
		{
			static public KeyValuePair<IBookIndex, IBookTarget> ComposeTargetWithArticleAndOrder(IBookParty party, 
				SymbolName articleName, uint codeOrder, ITargetValues values, IProcessConfig config)
			{
				IBookTarget target = BuildTargetFromArticleCode(articleName.Code, values, config);

				IBookIndex index = BuildIndexFromTargetAndOrder(party, target.ArticleCode(), codeOrder);

				return new KeyValuePair<IBookIndex, IBookTarget>(index, target);
			}

			#region Support Members

			static public IBookTarget BuildTargetFromArticleCode(uint articleCode, ITargetValues values, IProcessConfig config)
			{
				IPayrollArticle targetArticle = config.FindArticle(articleCode);

				IPayrollConcept targetConcept = config.FindConcept(targetArticle.ConceptCode());

				IBookTarget bookTarget = TargetFactory.BuildTargetWithValues(targetConcept, targetArticle, values);

				return bookTarget;
			}

			static private IBookIndex BuildIndexFromTargetAndOrder(IBookParty party, uint articleCode, uint codeOrder)
			{
				IBookIndex targetIndex = new BookIndex(party, articleCode, codeOrder);

				return targetIndex;
			}

			#endregion
		}

		static class TargetsDictComposer
		{
			public static IDictionary<IBookIndex, IBookTarget> MergeDictWithTokenAndValue(IDictionary<IBookIndex, IBookTarget> targets,
				IBookIndex targetIndex, IBookTarget targetValue)
			{
				var evalFacts = new Dictionary<IBookIndex, IBookTarget>(targets);

				if (!evalFacts.ContainsKey(targetIndex))
				{
					evalFacts.Add(targetIndex, targetValue);
				}
				return evalFacts;
			}
		}

		static class TargetFactory
		{
			public static IBookTarget BuildTargetWithValues(IPayrollConcept concept, IPayrollArticle article, ITargetValues values)
			{
				return null;
			}
		}

		public static ITargetStream CreateFacts()
		{
			var targets = new Dictionary<IBookIndex, IBookTarget>();

			var lastParty = BookParty.GetEmpty();

			var lastToken = BookIndex.GetEmpty();

			return new TargetStream(targets, lastParty, lastToken);
		}

		public TargetStream(IDictionary<IBookIndex, IBookTarget> targets, IBookParty lastParty, IBookIndex lastToken)
		{
			this.__targets = targets;

			this.__lastParty = lastParty;

			this.__lastToken = lastToken;
		}

		public ITargetStream AddNewContractTarget(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextToken = retTuple.Item1;

			var nextParty = nextToken.GetNewContractParty(nextToken.CodeOrder());

			return new TargetStream(nextFacts, nextParty, nextToken);
		}

		public ITargetStream AddNewPositionTarget(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonPositionParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextToken = retTuple.Item1;

			var nextParty = nextToken.GetNewPositionParty(nextToken.CodeOrder());

			return new TargetStream(nextFacts, nextParty, nextToken);
		}

		public ITargetStream AddTargetIntoContract(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextToken = retTuple.Item1;

			var nextParty = nextToken.GetParty();

			return new TargetStream(nextFacts, nextParty, nextToken);
		}

		public ITargetStream AddTargetIntoPosition(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetPositionParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextToken = retTuple.Item1;

			var nextParty = nextToken.GetParty();

			return new TargetStream(nextFacts, nextParty, nextToken);
		}

		public ITargetStream AddTargetIntoGeneral(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextToken = retTuple.Item1;

			var nextParty = nextToken.GetParty();

			return new TargetStream(nextFacts, nextParty, nextToken);
		}

		private IDictionary<IBookIndex, IBookTarget> __targets = null;

		private IBookParty __lastParty = null;

		private IBookIndex __lastToken = null;

		#region ITargetStream implementation

		public IDictionary<IBookIndex, IBookTarget> Targets ()
		{
			return __targets;
		}

		public IBookParty LastParty () 
		{
			return __lastParty; 
		}

		public IBookIndex LastToken () 
		{
			return __lastToken; 
		}

		#endregion
	}
}

