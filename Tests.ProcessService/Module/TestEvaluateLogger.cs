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

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestEvaluateLogger
	{
		IProcessConfig testConfig = null;

		IProcessServiceLogger serviceLog = null; 
		
		[TestFixtureSetUp]
		public void TestSetup()
		{
			serviceLog = new TestTargetsLogger ("TestTargetsCollection");

			testConfig = ProcessConfigSetCzModule.CreateModule(null);

			testConfig.InitModule ();
		}

		[Test ()]
		public void Should_Return_Valid_Result_Stream ()
		{
			ITargetValues emptyValues = null;

			ITargetStream targets = TargetStream.CreateEmptyStream ().
				AddNewContractsTarget(ConfigSetCzArticleName.REF_CONTRACT_EMPL_TERM, emptyValues, testConfig).
				AddNewPositionsTarget(ConfigSetCzArticleName.REF_POSITION_EMPL_TERM, emptyValues, testConfig).
				AddTargetIntoPosition(ConfigSetCzArticleName.REF_SALARY_BASE, emptyValues, testConfig).
				AddTargetIntoSumLevel(ConfigSetCzArticleName.REF_INCOME_GROSS, emptyValues, testConfig);

			IProcessService testModule = ProcessServiceModule.CreateModule(targets, testConfig, serviceLog);

			IResultStream results = testModule.EvaluateTargetsToResults ();

			serviceLog.CloseLogStream ();

			Assert.AreEqual (0, results.Results ().Keys.Count);
		}
	}
}

