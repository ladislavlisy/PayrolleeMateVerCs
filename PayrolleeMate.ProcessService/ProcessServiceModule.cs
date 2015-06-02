using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessService
{
	public class ProcessServiceModule : IProcessService
	{
		public static IProcessService CreateModule(ITargetStream targets, IProcessConfig configModule, IProcessServiceLogger logger)
		{
			IProcessService module = new ProcessServiceModule (targets, configModule, logger);

			return module;
		}

		private ProcessServiceModule (ITargetStream targets, IProcessConfig configModule, IProcessServiceLogger logger)
		{
			Targets = targets;

			ConfigModule = configModule;

			Logger = logger;
		}

		protected ITargetStream Targets { get; private set; }

		protected IProcessConfig ConfigModule { get; private set; }

		protected IProcessServiceLogger Logger { get; private set; }

		#region IProcessService implementation

		public IResultStream EvaluateTargetsToResults ()
		{
			var results = ResultStream.CreateStream ();

			IBookParty[] contractParties = Targets.CollectPartiesForContracts ();

			IBookParty[] positionParties = Targets.CollectPartiesForPositions ();

			ITargetStream evalCollection = CreateCalculationStream (Targets, contractParties, positionParties, ConfigModule);

			return results;
		}

		#endregion
		
		private ITargetStream CreateCalculationStream (ITargetStream targets, IBookParty[] contractParties, IBookParty[] positionParties, IProcessConfig configModule)
		{
			ITargetStream calculationStream = ProcessStreamBuilder.BuildCalculationStream (targets, contractParties, positionParties, configModule);

			return calculationStream;
		}

	}
}

