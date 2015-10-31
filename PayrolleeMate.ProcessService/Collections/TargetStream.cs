using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.Common.Core;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.ProcessService.Comparers;

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
				IBookIndex newIndex = TargetElementBuilder.BuildIndexWithFirst(targets.Keys, party, articleName.Code);

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

		public static class TargetStreamBuilder
		{
			public static IDictionary<IBookIndex, IBookTarget> BuildStreamCopy(IDictionary<IBookIndex, IBookTarget> targets)
			{
				var targetsCopy = targets.ToDictionary(key => key.Key, val => val.Value);

				return targetsCopy;
			}

			public static IPayrollArticle[] BuildArticleStream (IDictionary<IBookIndex, IBookTarget> targets)
			{
				var initialStream = new IPayrollArticle[0];

				var articleStream = targets.Aggregate(initialStream,
					(agr, targetPair) => ConcatArticles(agr, targetPair.Value).ToArray());

				var articleUnique = articleStream.Distinct().ToArray();

				return articleUnique;
			}

			private static IPayrollArticle[] ConcatArticles(IPayrollArticle[] initialStream, IBookTarget target)
			{
				var relatedStream = target.Article().RelatedArticles();

				if (relatedStream == null)
				{
					return initialStream.ToArray();
				}
				return initialStream.Concat(relatedStream).ToArray();
			}

			public static IDictionary<IBookIndex, IBookTarget> BuildEvaluationStream (IDictionary<IBookIndex, IBookTarget> initialStream, 
				IBookParty[] contracts, IBookParty[] positions, IPayrollArticle article, IProcessConfig configModule)
			{
				ITargetValues emptyValues = null;

				IPayrollConcept concept = configModule.FindConcept (article.ConceptCode ());

				IBookParty[] parties = concept.GetTargetParties(BookParty.GetEmpty(), contracts, positions);

				var targets = parties.Aggregate(initialStream,
					(agr, party) => BuildArticleTarget(initialStream, party, article, emptyValues, configModule));

				return targets;
			}

			private static IDictionary<IBookIndex, IBookTarget>  BuildArticleTarget(
				IDictionary<IBookIndex, IBookTarget> initialStream, IBookParty addParty, IPayrollArticle article,
				ITargetValues addValues, IProcessConfig configModule)
			{
				var results = TargetsTupleComposer.AddTargetBySymbol(initialStream,
					addParty, article.ArticleSymbol(), addValues, configModule);

				var targets = results.Item2;

				return targets;
			}

		}

		class ResultsStreamBuilder
		{
			public static IResultStream EvaluateTargetsToResults(IDictionary<IBookIndex, IBookTarget> targets, IProcessConfig config, IEngineProfile engine)
			{
				IResultStream emptyResults = ResultStream.CreateEmptyStream();

				var results = targets.Aggregate(emptyResults,
					(agr, target) => EvaluateTarget(agr, target.Value, config, engine));
				
				return results;
			}

			private static IResultStream EvaluateTarget(
				IResultStream resultStream, IBookTarget target, IProcessConfig config, IEngineProfile engine)
			{
				var targetResults = target.Evaluate(config, engine, resultStream);

				var results = resultStream.AggregateResultList(targetResults);

				return results;
			}
		}

		public static ITargetStream CreateEmptyStream()
		{
			var targets = new Dictionary<IBookIndex, IBookTarget>();

			var lastParty = BookParty.GetEmpty();

			var lastIndex = BookIndex.GetEmpty();

			return new TargetStream(targets, lastParty, lastIndex);
		}

		private TargetStream(IDictionary<IBookIndex, IBookTarget> targets, IBookParty lastParty, IBookIndex lastIndex)
		{
			this.__targets = targets;

			this.__lastParty = lastParty;

			this.__lastIndex = lastIndex;
		}

		public ITargetStream AddNewContractsTarget(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetNewContractParty(nextIndex.Code(), nextIndex.CodeOrder());

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		public ITargetStream AddNewPositionsTarget(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonPositionParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetNewPositionParty(nextIndex.Code(), nextIndex.CodeOrder());

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		public ITargetStream AddTargetIntoSubLevel(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			uint articleCode = article.Code;

			IPayrollArticle targetArticle = config.FindArticle (articleCode);

			uint conceptCode = targetArticle.ConceptCode ();

			IPayrollConcept targetConcept = config.FindConcept (conceptCode);

			IBookParty addParty = targetConcept.GetTargetParty (LastParty ());

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = targetConcept.GetNextTargetParty (nextIndex);

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

		public ITargetStream AddTargetIntoSumLevel(SymbolName article, ITargetValues values, IProcessConfig config)
		{
			var addParty = LastParty().GetNonContractParty();

			var retTuple = TargetsTupleComposer.AddTargetBySymbol(Targets(),
				addParty, article, values, config);

			var nextFacts = retTuple.Item2;

			var nextIndex = retTuple.Item1;

			var nextParty = nextIndex.GetParty();

			return new TargetStream(nextFacts, nextParty, nextIndex);
		}

		public ITargetStream CreateEvaluationStream (IProcessConfig configModule)
		{
			IBookParty[] contracts = CollectPartiesForContracts ();

			IBookParty[] positions = CollectPartiesForPositions ();

			var targetsInit = TargetStreamBuilder.BuildStreamCopy (__targets);

			var articleList = TargetStreamBuilder.BuildArticleStream (__targets);

			var targetsDict = articleList.Aggregate(targetsInit,
				(agr, article) => TargetStreamBuilder.BuildEvaluationStream(agr, contracts, positions, article, configModule));

			var targetsEval = targetsDict.OrderBy(x => x.Value.Article()).
				ToDictionary(key => key.Key, val => val.Value);

			var lastParty = BookParty.GetEmpty();

			var lastIndex = BookIndex.GetEmpty();

			return new TargetStream(targetsEval, lastParty, lastIndex);
		}

		public IResultStream EvaluateToResultStream (IProcessConfig config, IEngineProfile engine)
		{
			var targets = __targets;

			var results = ResultsStreamBuilder.EvaluateTargetsToResults (targets, config, engine);

			return results;
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


		private IBookParty[] CollectPartiesForContracts ()
		{
			var initaialParties = EMPTY_PARTY_LIST;

			var contractParties = __targets.Aggregate(initaialParties,
				(agr, factorPair) => GetContractParties(agr, factorPair.Value).ToArray());
			return contractParties;
		}

		private IBookParty[] CollectPartiesForPositions ()
		{
			var initaialParties = EMPTY_PARTY_LIST;

			var contractParties = __targets.Aggregate(initaialParties,
				(agr, factorPair) => GetPositionParties(agr, factorPair.Value).ToArray());
			return contractParties;
		}

		private static IBookParty[] GetContractParties(IBookParty[] contractParties, IBookTarget targetToken)
		{
			IBookParty contractParty = targetToken.GetContractParty();

			if (contractParty == null)
			{
				return contractParties.ToArray();
			}
			var contractPartyArry = new IBookParty[] { contractParty };

			return contractParties.Concat(contractPartyArry).ToArray();
		}


		private static IBookParty[] GetPositionParties(IBookParty[] positionParties, IBookTarget targetToken)
		{
			IBookParty posotionParty = targetToken.GetPositionParty();

			if (posotionParty == null)
			{
				return positionParties.ToArray();
			}
			var contractPartyArry = new IBookParty[] { posotionParty };

			return positionParties.Concat(contractPartyArry).ToArray();
		}
	}
}

