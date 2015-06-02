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
		public static readonly IBookParty[] EMPTY_PARTY_LIST = {};

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

		public IBookParty[] CollectPartiesForContracts ()
		{
			var initaialParties = EMPTY_PARTY_LIST;

			var contractParties = __targets.Aggregate(initaialParties,
				(agr, factorPair) => GetContractParties(agr, factorPair.Key, factorPair.Value).ToArray());
			return contractParties;
		}

		public IBookParty[] CollectPartiesForPositions ()
		{
			var initaialParties = EMPTY_PARTY_LIST;

			var contractParties = __targets.Aggregate(initaialParties,
				(agr, factorPair) => GetPositionParties(agr, factorPair.Key, factorPair.Value).ToArray());
			return contractParties;
		}

		public ITargetStream CreateStreamCopy()
		{
			var targets = Targets().ToDictionary(key => key.Key, val => val.Value);

			var lastParty = BookParty.GetEmpty();

			var lastIndex = BookIndex.GetEmpty();

			return new TargetStream(targets, lastParty, lastIndex);
		}

		public IPayrollArticle[] BookTargetToEvaluate ()
		{
			var initaialToEvaluate = new IPayrollArticle[0];

			var articlesToEvaluate = __targets.Aggregate(initaialToEvaluate,
				(agr, targetPair) => TargetsToEvaluate(agr, targetPair.Value).ToArray());

			var uniquelyToEvaluate = articlesToEvaluate.Distinct().ToArray();

			return uniquelyToEvaluate;
		}

		public ITargetStream MergeRealtedArticle (IBookParty[] contractParties, IBookParty[] positionParties, IPayrollArticle article, IProcessConfig configModule)
		{
			ITargetValues emptyValues = null;

			IPayrollConcept targetConcept = configModule.FindConcept (article.ConceptCode ());

			IBookParty[] targetParties = targetConcept.GetTargetParties(contractParties, positionParties);

			var targets = targetParties.Aggregate(Targets(),
				(agr, party) => BuildArticleTarget(Targets(), party, article, emptyValues, configModule));

			var lastParty = BookParty.GetEmpty();

			var lastIndex = BookIndex.GetEmpty();

			return new TargetStream(targets, lastParty, lastIndex);
		}

		#endregion


		private static IDictionary<IBookIndex, IBookTarget>  BuildArticleTarget(
			IDictionary<IBookIndex, IBookTarget> targets, IBookParty addParty, IPayrollArticle article,
			ITargetValues targetValues, IProcessConfig configModule)
		{
			var targetTuple = TargetsTupleComposer.AddTargetBySymbol(targets,
				addParty, article.ArticleSymbol(), targetValues, configModule);

			var targetToken = targetTuple.Item2;

			return targetToken;
		}

		private static IPayrollArticle[] TargetsToEvaluate(IPayrollArticle[] targetsEvaluate, IBookTarget target)
		{
			var relatedList = target.Article().RelatedArticles();

			if (relatedList == null)
			{
				return targetsEvaluate.ToArray();
			}
			return targetsEvaluate.Concat(relatedList).ToArray();
		}

		private static IBookParty[] GetContractParties(IBookParty[] contractParties, IBookIndex targetIndex, IBookTarget targetToken)
		{
			IBookParty contractParty = targetToken.GetContractParty(targetIndex);

			if (contractParty == null)
			{
				return contractParties.ToArray();
			}
			var contractPartyArry = new IBookParty[] { contractParty };

			return contractParties.Concat(contractPartyArry).ToArray();
		}


		private static IBookParty[] GetPositionParties(IBookParty[] positionParties, IBookIndex targetIndex, IBookTarget targetToken)
		{
			IBookParty posotionParty = targetToken.GetPositionParty(targetIndex);

			if (posotionParty == null)
			{
				return positionParties.ToArray();
			}
			var contractPartyArry = new IBookParty[] { posotionParty };

			return positionParties.Concat(contractPartyArry).ToArray();
		}
	}
}

