using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Interfaces.Loggers;
using Tests.ProcessService.Loggers;
using PayrolleeMate.ProcessService;
using PayrolleeMate.ProcessConfigSetCz;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessService.Collections;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.EngineService;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.ProcessConfigSetCz.Evaluations;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestEvaluateLogger
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		IProcessConfig testConfig = null;

		IEngineService testEngine = null;

		IProcessServiceLogger serviceLog = null; 
		
		[TestFixtureSetUp]
		public void TestSetup()
		{
			serviceLog = new TestTargetsLogger ("TestTargetsCollection");

			testConfig = ProcessConfigSetCzModule.CreateModule(null);

			testEngine = EngineServiceModule.CreateModule ();

			testConfig.InitModule ();
		}

		[Test ()]
		public void Should_Return_Valid_Result_Stream ()
		{
			ITargetValues contractValues = TargetValues.CreateContractEmplTermValues(null, null);

			ITargetValues positionValues = TargetValues.CreatePositionEmplTermValues(null, null);

			ITargetValues salaryValues = TargetValues.CreateSalaryBaseValues(10000m);

			ITargetValues emptyValues = null;

			ITargetStream targets = TargetStream.CreateEmptyStream ().
				AddNewContractsTarget(ConfigSetCzArticleName.REF_CONTRACT_EMPL_TERM, contractValues, testConfig).
				AddNewPositionsTarget(ConfigSetCzArticleName.REF_POSITION_EMPL_TERM, positionValues, testConfig).
				AddTargetIntoPosition(ConfigSetCzArticleName.REF_SALARY_BASE, salaryValues, testConfig).
				AddTargetIntoPosition(ConfigSetCzArticleName.REF_INCOME_GROSS, emptyValues, testConfig);

			IEngineProfile testProfile = testEngine.BuildEngineProfile (testPeriod);

			IProcessService testModule = ProcessServiceModule.CreateModule(targets, testConfig, testProfile, serviceLog);

			IResultStream results = testModule.EvaluateTargetsToResults ();

			serviceLog.CloseLogStream ();

			Assert.AreEqual (0, results.Results ().Keys.Count);
		}
	}
}

