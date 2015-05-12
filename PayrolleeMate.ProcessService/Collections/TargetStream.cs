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
		public static class TargetElementBuilder
		{
			static public IBookIndex BuildIndexWithFirst(IEnumerable<IBookIndex> elements, IBookParty party, uint code)
			{
				uint codeOrder = SelectFirst (elements, party, code);

				return new BookIndex(party, code, codeOrder);
			}

			static public IBookIndex BuildIndexWithDefault(IEnumerable<IBookIndex> elements, IBookParty party, uint code)
			{
				uint codeOrder = SelectDefault (elements, party, code);

				return new BookIndex(party, code, codeOrder);
			}

			#region Support Members

			static private uint SelectFirst(IEnumerable<IBookIndex> elements, IBookParty party, uint code)
			{
				IEnumerable<IBookIndex> selectedUnits = SelectEquals(elements, party, code);

				IEnumerable<uint> oneCodeOrders = ExtractCodeOrders(selectedUnits);

				return FirstOrderFrom(oneCodeOrders.OrderBy(x => x).ToArray());
			}

			static private uint SelectDefault(IEnumerable<IBookIndex> elements, IBookParty party, uint code)
			{
				IEnumerable<IBookIndex> selectedUnits = SelectEquals(elements, party, code);

				IEnumerable<uint> oneCodeOrders = ExtractCodeOrders(selectedUnits);

				return DefaultOrderFrom(oneCodeOrders.OrderBy(x => x).ToArray());
			}

			static private IEnumerable<IBookIndex> SelectEquals(IEnumerable<IBookIndex> elements, IBookParty party, uint code)
			{
				return elements.Where(x => (x.isEqualToParty(party) && x.Code() == code)).ToArray();
			}

			static private IEnumerable<uint> ExtractCodeOrders(IEnumerable<IBookIndex> elements)
			{
				return elements.Select(x => x.CodeOrder()).ToArray();
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
				IBookIndex newIndex = TargetElementBuilder.BuildIndexWithDefault(targets.Keys, party, articleName.Code);

				KeyValuePair<IBookIndex, IBookTarget> pairToMerge = TargetPairComposer
					.ComposeTarget(party, articleName, newIndex, values, config);

				var targetIndex = pairToMerge.Key;

				var targetValue = pairToMerge.Value;

				var bookTargets = TargetsDictComposer.MergeDictWithTargetPair(targets, targetIndex, targetValue);

				return Tuple.Create<IBookIndex, IDictionary<IBookIndex, IBookTarget>>(targetIndex, bookTargets);
			}
		}

		static class TargetPairComposer
		{
			static public KeyValuePair<IBookIndex, IBookTarget> ComposeTarget(IBookParty party, 
				SymbolName articleName, IBookIndex element, ITargetValues values, IProcessConfig config)
			{
				IBookTarget target = BuildTargetFromElement(element, values, config);

				return new KeyValuePair<IBookIndex, IBookTarget>(element, target);
			}

			#region Support Members

			static public IBookTarget BuildTargetFromElement(IBookIndex element, ITargetValues values, IProcessConfig config)
			{
				uint articleCode = element.Code ();

				IPayrollArticle targetArticle = config.FindArticle(articleCode);

				IPayrollConcept targetConcept = config.FindConcept(targetArticle.ConceptCode());

				IBookTarget target = TargetFactory.BuildTargetWithValues(element, targetArticle, targetConcept, values);

				return target;
			}

			#endregion
		}

		static class TargetsDictComposer
		{
			public static IDictionary<IBookIndex, IBookTarget> MergeDictWithTargetPair(IDictionary<IBookIndex, IBookTarget> targets,
				IBookIndex targetIndex, IBookTarget targetValue)
			{
				var mergedTargets = new Dictionary<IBookIndex, IBookTarget>(targets);

				if (!mergedTargets.ContainsKey(targetIndex))
				{
					mergedTargets.Add(targetIndex, targetValue);
				}
				return mergedTargets;
			}
		}

		static class TargetFactory
		{
			public static IBookTarget BuildTargetWithValues(IBookIndex element, IPayrollArticle article, IPayrollConcept concept, ITargetValues values)
			{
				return new BookTarget(element, article, concept, values);
			}
		}

		public static ITargetStream CreateStream()
		{
			var targets = new Dictionary<IBookIndex, IBookTarget>();

			var lastParty = BookParty.GetEmpty();

			var lastIndex = BookIndex.GetEmpty();

			return new TargetStream(targets, lastParty, lastIndex);
		}

		public TargetStream(IDictionary<IBookIndex, IBookTarget> targets, IBookParty lastParty, IBookIndex lastIndex)
		{
			this.__targets = targets;

			this.__lastParty = lastParty;

			this.__lastIndex = lastIndex;
		}

		public ITargetStream AddNewContractTarget(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetNewContractParty(nextIndex.CodeOrder());

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		public ITargetStream AddNewPositionTarget(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonPositionParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetNewPositionParty(nextIndex.CodeOrder());

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		public ITargetStream AddTargetIntoContract(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetParty();

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		public ITargetStream AddTargetIntoPosition(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetPositionParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetParty();

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		public ITargetStream AddTargetIntoGeneral(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetParty();

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		private IDictionary<IBookIndex, IBookTarget> __targets = null;

		private IBookParty __lastParty = null;

		private IBookIndex __lastIndex = null;

		#region ITargetStream implementation

		public IDictionary<IBookIndex, IBookTarget> Targets ()
		{
			return __targets;
		}

		public IBookParty LastParty () 
		{
			return __lastParty; 
		}

		public IBookIndex LastIndex () 
		{
			return __lastIndex; 
		}

		#endregion
	}
}

