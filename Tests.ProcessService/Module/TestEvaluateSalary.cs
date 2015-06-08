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
using PayrolleeMate.ProcessConfig.Builders;
using PayrolleeMate.EngineService.Constants;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestEvaluateSalary
	{
		private static readonly MonthPeriod testPeriod = new MonthPeriod (2015, 1);

		IProcessConfig testConfig = null;

		IEngineService testEngine = null;

		IProcessServiceLogger serviceLog = null; 

		[TestFixtureSetUp]
		public void TestSetup()
		{
			serviceLog = new TestTargetsLogger ("TestEvaluteSalary");

			testConfig = ProcessConfigSetCzModule.CreateModule(null);

			testEngine = EngineServiceModule.CreateModule ();

			testConfig.InitModule ();
		}

		[Test ()]
		public void Should_Return_Valid_Result_Stream ()
		{
			WorkRelationTerms TEST_CONTRACT_TYPE = WorkRelationTerms.WORKTERM_EMPLOYMENT_1;

			WorkHealthTerms TEST_HEALTH_TYPE = WorkHealthTerms.HEALTH_TERM_EMPLOYMENT;

			WorkSocialTerms  TEST_SOCIAL_TYPE = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENT;

			ITargetValues contractValues = TargetValueBuilder.CreateContractEmplTermValues(
				TEST_CONTRACT_TYPE, TEST_HEALTH_TYPE, TEST_SOCIAL_TYPE, null, null);

			ITargetValues positionValues = TargetValueBuilder.CreatePositionEmplTermValues(null, null);

			ITargetValues positionSalary = TargetValueBuilder.CreateSalaryBaseValues(15000m);

			ITargetValues emptyValues = null;

			ITargetStream targets = TargetStream.CreateEmptyStream ().
				AddNewContractsTarget(ConfigSetCzArticleName.REF_CONTRACT_EMPL_TERM, contractValues, testConfig).
				AddNewPositionsTarget(ConfigSetCzArticleName.REF_POSITION_EMPL_TERM, positionValues, testConfig).
				AddTargetIntoPosition(ConfigSetCzArticleName.REF_SALARY_BASE, positionSalary, testConfig).
				AddTargetIntoPosition(ConfigSetCzArticleName.REF_INCOME_GROSS, emptyValues, testConfig);

			IEngineProfile testProfile = testEngine.BuildEngineProfile (testPeriod);

			IProcessService testModule = ProcessServiceModule.CreateModule(targets, testConfig, testProfile, serviceLog);

			IResultStream results = testModule.EvaluateTargetsToResults ();

			serviceLog.CloseLogStream ();

			Assert.AreEqual (0, results.Results ().Keys.Count);
		}
	}
}

