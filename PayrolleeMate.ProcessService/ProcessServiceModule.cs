using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Logers;
using System.Linq;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.ProcessService
{
	public class ProcessServiceModule : IProcessService
	{
		public static IProcessService CreateModule(ITargetStream targets, IProcessConfig configModule, IEngineProfile engineModule, IProcessServiceLogger logger)
		{
			IProcessService module = new ProcessServiceModule (targets, configModule, engineModule, logger);

			return module;
		}

		private ProcessServiceModule (ITargetStream targets, IProcessConfig configModule, IEngineProfile engineModule, IProcessServiceLogger logger)
		{
			Targets = targets;

			ConfigModule = configModule;

			EngineModule = engineModule;

			Logger = logger;
		}

		protected ITargetStream Targets { get; private set; }

		protected IProcessConfig ConfigModule { get; private set; }

		protected IEngineProfile EngineModule { get; private set; }

		protected IProcessServiceLogger Logger { get; private set; }

		#region IProcessService implementation

		public IResultStream EvaluateTargetsToResults ()
		{
			//var results = ResultStream.CreateEmptyStream ();

			var targets = Targets.CreateEvaluationStream (ConfigModule);

			LoggerWrapper.LogEvaluationStream (Logger, targets, "EvaluateTargets");

			var results = targets.EvaluateToResultStream (ConfigModule, EngineModule);

			return results;
		}

		#endregion
		
	}
}

