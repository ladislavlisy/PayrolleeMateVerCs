using NUnit.Framework;
using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfigSetCz;
using PayrolleeMate.ProcessConfig.Payroll.Articles;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using Tests.ProcessConfig.Logers;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.ProcessConfig.Comparers;

namespace Tests.ProcessConfig.Collections
{
	[TestFixture ()]
	public class TestArticleDependencySort
	{
		IProcessConfig testConfig = null;

		[TestFixtureSetUp]
		public void TestSetup()
		{
			IProcessConfigLogger logger = new TestConfigLogger ("TestArticleDependencySort");

			testConfig = ProcessConfigSetCzModule.CreateModule(logger);

			testConfig.InitModule ();

			logger.CloseLogStream ();
		}

		[Test ()]
		public void Should_Compare_SalaryBaseArticle_After_TimesheetWorkingArticle ()
		{
			SymbolName testNameCONTRACT_EMPL_TERM = ConfigSetCzArticleName.REF_CONTRACT_EMPL_TERM;
			SymbolName testNamePOSITION_EMPL_TERM = ConfigSetCzArticleName.REF_POSITION_EMPL_TERM;
			SymbolName testNameSCHEDULE_WORK = ConfigSetCzArticleName.REF_SCHEDULE_WORK;
			SymbolName testNameSALARY_BASE = ConfigSetCzArticleName.REF_SALARY_BASE;
			SymbolName testNameTIMESHEET_SCHEDULE = ConfigSetCzArticleName.REF_TIMESHEET_SCHEDULE;
			SymbolName testNameTIMESHEET_WORKING = ConfigSetCzArticleName.REF_TIMESHEET_WORKING;
			SymbolName testNameTIMESHEET_ABSENCE = ConfigSetCzArticleName.REF_TIMESHEET_ABSENCE;
			SymbolName testNameTIMEHOURS_WORKING = ConfigSetCzArticleName.REF_TIMEHOURS_WORKING;
			SymbolName testNameTIMEHOURS_ABSENCE = ConfigSetCzArticleName.REF_TIMEHOURS_ABSENCE;
			SymbolName testNameINCOME_GROSS = ConfigSetCzArticleName.REF_INCOME_GROSS;

			IPayrollArticle testArticleCONTRACT_EMPL_TERM = testConfig.FindArticle (testNameCONTRACT_EMPL_TERM.Code);
			IPayrollArticle testArticlePOSITION_EMPL_TERM = testConfig.FindArticle (testNamePOSITION_EMPL_TERM.Code);
			IPayrollArticle testArticleSCHEDULE_WORK = testConfig.FindArticle (testNameSCHEDULE_WORK.Code);
			IPayrollArticle testArticleSALARY_BASE = testConfig.FindArticle (testNameSALARY_BASE.Code);
			IPayrollArticle testArticleTIMESHEET_SCHEDULE = testConfig.FindArticle (testNameTIMESHEET_SCHEDULE.Code);
			IPayrollArticle testArticleTIMESHEET_WORKING = testConfig.FindArticle (testNameTIMESHEET_WORKING.Code);
			IPayrollArticle testArticleTIMESHEET_ABSENCE = testConfig.FindArticle (testNameTIMESHEET_ABSENCE.Code);
			IPayrollArticle testArticleTIMEHOURS_WORKING = testConfig.FindArticle (testNameTIMEHOURS_WORKING.Code);
			IPayrollArticle testArticleTIMEHOURS_ABSENCE = testConfig.FindArticle (testNameTIMEHOURS_ABSENCE.Code);
			IPayrollArticle testArticleINCOME_GROSS = testConfig.FindArticle (testNameINCOME_GROSS.Code);

			IPayrollArticle testCompareArticle = testArticleSALARY_BASE;

			int compareOneCONTRACT_EMPL_TERM = ArticleDependencyComparer.CompareArticles (testArticleCONTRACT_EMPL_TERM, testCompareArticle);
			int compareOnePOSITION_EMPL_TERM = ArticleDependencyComparer.CompareArticles (testArticlePOSITION_EMPL_TERM, testCompareArticle);
			int compareOneSCHEDULE_WORK      = ArticleDependencyComparer.CompareArticles (testArticleSCHEDULE_WORK     , testCompareArticle);
			int compareOneSALARY_BASE        = ArticleDependencyComparer.CompareArticles (testArticleSALARY_BASE       , testCompareArticle);
			int compareOneTIMESHEET_SCHEDULE = ArticleDependencyComparer.CompareArticles (testArticleTIMESHEET_SCHEDULE, testCompareArticle);
			int compareOneTIMESHEET_WORKING  = ArticleDependencyComparer.CompareArticles (testArticleTIMESHEET_WORKING , testCompareArticle);
			int compareOneTIMESHEET_ABSENCE  = ArticleDependencyComparer.CompareArticles (testArticleTIMESHEET_ABSENCE , testCompareArticle);
			int compareOneTIMEHOURS_WORKING  = ArticleDependencyComparer.CompareArticles (testArticleTIMEHOURS_WORKING , testCompareArticle);
			int compareOneTIMEHOURS_ABSENCE  = ArticleDependencyComparer.CompareArticles (testArticleTIMEHOURS_ABSENCE , testCompareArticle);
			int compareOneINCOME_GROSS       = ArticleDependencyComparer.CompareArticles (testArticleINCOME_GROSS      , testCompareArticle);

			int compareTwoCONTRACT_EMPL_TERM = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleCONTRACT_EMPL_TERM);
			int compareTwoPOSITION_EMPL_TERM = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticlePOSITION_EMPL_TERM);
			int compareTwoSCHEDULE_WORK      = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleSCHEDULE_WORK     );
			int compareTwoSALARY_BASE        = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleSALARY_BASE       );
			int compareTwoTIMESHEET_SCHEDULE = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleTIMESHEET_SCHEDULE);
			int compareTwoTIMESHEET_WORKING  = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleTIMESHEET_WORKING );
			int compareTwoTIMESHEET_ABSENCE  = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleTIMESHEET_ABSENCE );
			int compareTwoTIMEHOURS_WORKING  = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleTIMEHOURS_WORKING );
			int compareTwoTIMEHOURS_ABSENCE  = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleTIMEHOURS_ABSENCE );
			int compareTwoINCOME_GROSS       = ArticleDependencyComparer.CompareArticles (testCompareArticle, testArticleINCOME_GROSS      );

			Assert.AreEqual (compareOneSALARY_BASE        , compareTwoSALARY_BASE        );

			Assert.AreNotEqual (compareOneCONTRACT_EMPL_TERM , compareTwoCONTRACT_EMPL_TERM );
			Assert.AreNotEqual (compareOnePOSITION_EMPL_TERM , compareTwoPOSITION_EMPL_TERM );
			Assert.AreNotEqual (compareOneSCHEDULE_WORK      , compareTwoSCHEDULE_WORK      );
			Assert.AreNotEqual (compareOneTIMESHEET_SCHEDULE , compareTwoTIMESHEET_SCHEDULE );
			Assert.AreNotEqual (compareOneTIMESHEET_WORKING  , compareTwoTIMESHEET_WORKING  );
			Assert.AreNotEqual (compareOneTIMESHEET_ABSENCE  , compareTwoTIMESHEET_ABSENCE  );
			Assert.AreNotEqual (compareOneTIMEHOURS_WORKING  , compareTwoTIMEHOURS_WORKING  );
			Assert.AreNotEqual (compareOneTIMEHOURS_ABSENCE  , compareTwoTIMEHOURS_ABSENCE  );
			Assert.AreNotEqual (compareOneINCOME_GROSS       , compareTwoINCOME_GROSS       );

			Assert.AreEqual ( 0, compareOneSALARY_BASE);
			Assert.AreEqual (-1, compareOneCONTRACT_EMPL_TERM);
			Assert.AreEqual (-1, compareOnePOSITION_EMPL_TERM);
			Assert.AreEqual (-1, compareOneSCHEDULE_WORK     );
			Assert.AreEqual (-1, compareOneTIMESHEET_SCHEDULE);
			Assert.AreEqual (-1, compareOneTIMESHEET_WORKING );
			Assert.AreEqual (-1, compareOneTIMESHEET_ABSENCE );
			Assert.AreEqual (-1, compareOneTIMEHOURS_WORKING );
			Assert.AreEqual (-1, compareOneTIMEHOURS_ABSENCE );
			Assert.AreEqual ( 1, compareOneINCOME_GROSS      );
		}
	}
}

