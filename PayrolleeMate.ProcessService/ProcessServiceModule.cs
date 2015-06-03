using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Logers;

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
			var results = ResultStream.CreateEmptyStream ();

			var targets = Targets.CreateEvaluationStream (ConfigModule);

			LoggerWrapper.LogEvaluationStream (Logger, targets, "EvaluateTargets");

			return results;
		}

		#endregion
		
	}
}

