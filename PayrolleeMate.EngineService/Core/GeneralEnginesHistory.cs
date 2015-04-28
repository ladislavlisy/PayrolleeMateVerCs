using System;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Core
{
	public abstract class GeneralEnginesHistory<T> : IEnginesHistory<T>
	{
		public GeneralEnginesHistory ()
		{
			DefaultInstance = default(T);
		}

		public void InitEngines ()
		{
			SeqOfYears history = new SeqOfYears (History());

			InitWithHistory (history.ToArray());

			MonthPeriod defaultPeriod =  MonthPeriod.BeginYear(DefaultYear());

			DefaultInstance = FindEngine (defaultPeriod);
		}

		protected abstract ushort DefaultYear ();

		protected abstract ushort[] History ();

		protected abstract string NamespacePrefix ();

		protected abstract string ClassnamePrefix ();

		protected T DefaultInstance { get; set;}

		protected IDictionary<SpanOfYears, T> Engines { get; private set; }

		public void InitWithHistory(SpanOfYears[] setupHistory)
		{
			var initProfiles = new Dictionary<SpanOfYears, T>();

			Engines = setupHistory.Aggregate(initProfiles, (agr, x) => (MergeEngineToDict(agr, x)));
		}

		public T FindEngine(MonthPeriod period)
		{
			SpanOfYears periodSpan = SpanFromEngines(period);
			if (periodSpan == null)
			{
				return DefaultInstance;
			}
			T baseEngine;
			if (Engines.ContainsKey(periodSpan))
			{
				baseEngine = Engines[periodSpan];
			}
			else
			{
				baseEngine = DefaultInstance;
			}
			return baseEngine;
		}

		public T DefaultEngine ()
		{
			return DefaultInstance;
		}

		private T CreateEngineFor(SpanOfYears span)
		{
			T engine = EngineFactory<T>.InstanceFor(NamespacePrefix(), ClassnamePrefix(), span);

			return engine;
		}

		private Dictionary<SpanOfYears, T> MergeEngineToDict(IDictionary<SpanOfYears, T> agr, SpanOfYears span)
		{
			var returnAgr = new Dictionary<SpanOfYears, T>(agr);

			returnAgr.Add(span, CreateEngineFor(span));

			return returnAgr;
		}

		private SpanOfYears SpanFromEngines(MonthPeriod period)
		{
			ICollection<SpanOfYears> sortedHistory = Engines.Keys.OrderBy (x => x).ToArray ();

			SpanOfYears validSpan = sortedHistory.FirstOrDefault((x) => (period.Year() >= x.YearFrom && period.Year() <= x.YearUpto));

			return validSpan;
		}

	}
}

