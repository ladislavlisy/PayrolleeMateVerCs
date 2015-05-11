using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService.Collections
{
	public class TargetStream : ITargetStream
	{
		public static class BookIndexBuilder
		{
			static public IBookIndex BuildIndexWithFirst(IEnumerable<IBookIndex> unitCollection, IBookParty party, uint code)
			{
				uint codeOrder = SelectFirst (unitCollection, party, code);

				return new BookIndex(party, code, codeOrder);
			}

			static public IBookIndex BuildIndexWithDefault(IEnumerable<IBookIndex> unitCollection, IBookParty party, uint code)
			{
				uint codeOrder = SelectDefault (unitCollection, party, code);

				return new BookIndex(party, code, codeOrder);
			}

			#region Support Members

			static private uint SelectFirst(IEnumerable<IBookIndex> unitCollection, IBookParty party, uint code)
			{
				IEnumerable<IBookIndex> selectedUnits = SelectEquals(unitCollection, party, code);

				IEnumerable<uint> oneCodeOrders = ExtractCodeOrders(selectedUnits);

				return FirstOrderFrom(oneCodeOrders.OrderBy(x => x).ToArray());
			}

			static private uint SelectDefault(IEnumerable<IBookIndex> unitCollection, IBookParty party, uint code)
			{
				IEnumerable<IBookIndex> selectedUnits = SelectEquals(unitCollection, party, code);

				IEnumerable<uint> oneCodeOrders = ExtractCodeOrders(selectedUnits);

				return DefaultOrderFrom(oneCodeOrders.OrderBy(x => x).ToArray());
			}

			static private IEnumerable<IBookIndex> SelectEquals(IEnumerable<IBookIndex> unitCollection, IBookParty party, uint code)
			{
				return unitCollection.Where(x => (x.isEqualToParty(party) && x.Code() == code)).ToArray();
			}

			static private IEnumerable<uint> ExtractCodeOrders(IEnumerable<IBookIndex> unitCollection)
			{
				return unitCollection.Select(x => x.CodeOrder()).ToArray();
			}

			static private uint FirstOrderFrom(ICollection<uint> sortedCodeOrders)
			{
				uint firstCodeOrder = sortedCodeOrders.DefaultIfEmpty((uint)1).First();
				return firstCodeOrder;
			}

			static private uint DefaultOrderFrom(ICollection<uint> sortedCodeOrders)
			{
				uint lastCodeOrder = sortedCodeOrders.Aggregate((uint)0, (agr, x) => (((x > agr) && (x - agr) > 1) ? agr : x));
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
				IBookIndex newIndex = BookIndexBuilder.BuildIndexWithDefault(targets.Keys, party, articleName.Code);

				KeyValuePair<IBookIndex, IBookTarget> pairToMerge = BookKeyValuePairComposer
					.ComposeTargetWithArticleAndIndex(party, articleName, newIndex, values, config);

				var targetIndex = pairToMerge.Key;

				var targetValue = pairToMerge.Value;

				var bookTargets = TargetsDictComposer.MergeDictWithTokenAndValue(targets, targetIndex, targetValue);

				return Tuple.Create<IBookIndex, IDictionary<IBookIndex, IBookTarget>>(targetIndex, bookTargets);
			}
		}

		static class BookKeyValuePairComposer
		{
			static public KeyValuePair<IBookIndex, IBookTarget> ComposeTargetWithArticleAndIndex(IBookParty party, 
				SymbolName articleName, IBookIndex index, ITargetValues values, IProcessConfig config)
			{
				IBookTarget target = BuildTargetFromArticleCode(articleName.Code, values, config);

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

