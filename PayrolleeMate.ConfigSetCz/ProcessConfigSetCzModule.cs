using System;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ConfigSetCz.Constants;
using System.Reflection;
using PayrolleeMate.ProcessConfigSetCz.Collections;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;

namespace PayrolleeMate.ProcessConfigSetCz
{
	public class ProcessConfigSetCzModule : ProcessConfigModule<ConfigSetCzArticleCode, ConfigSetCzConceptCode>
	{
		public static IProcessConfig CreateModule(IProcessConfigLogger logger)
		{
			IProcessConfig config = new ProcessConfigSetCzModule (logger);

			return config;
		}

		private ProcessConfigSetCzModule (IProcessConfigLogger logger) : base(logger)
		{
			ArticlesCollection = new ConfigSetCzArticleCollection();

			ConceptsCollection = new ConfigSetCzConceptCollection();
		}

		void InitArticlesFromDirectCode ()
		{
			ConfigureArticle (
				ConfigSetCzArticleName.REF_CONTRACT_EMPL_TERM, 
				ConfigSetCzConceptName.REF_CONTRACT_EMPL_TERM,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_POSITION_EMPL_TERM, 
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_SCHEDULE_WORK, 
				ConfigSetCzConceptName.REF_SCHEDULE_WORK,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMESHEET_SCHEDULE, 
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMESHEET_WORKING, 
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMESHEET_ABSENCE, 
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMEHOURS_WORKING, 
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMEHOURS_ABSENCE, 
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_SALARY_BASE, 
				ConfigSetCzConceptName.REF_SALARY_BASE,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_INCOME_GROSS, 
				ConfigSetCzConceptName.REF_INCOME_GROSS,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_INCOME_NETTO, 
				ConfigSetCzConceptName.REF_INCOME_NETTO,
				false, 
				false, 
				false, 
				false, 
				false, 
				false);
		}

		void ConfigureContractTermConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_CONTRACT_EMPL_TERM, 
				ProcessCategory.CATEGORY_TERMS, 
				EMPTY_PENDING_CODES, 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM, 
				ProcessCategory.CATEGORY_TERMS, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_CONTRACT_EMPL_TERM
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigurePositionTimeConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, 
				ProcessCategory.CATEGORY_TIMES, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_POSITION_EMPL_TERM
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, 
				ProcessCategory.CATEGORY_TIMES, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_SCHEDULE_WORK
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, 
				ProcessCategory.CATEGORY_TIMES, 
				PendingArticleCodes2(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_SCHEDULE,
					ConfigSetCzArticleCode.ARTICLE_POSITION_EMPL_TERM
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, 
				ProcessCategory.CATEGORY_TIMES, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_WORKING
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, 
				ProcessCategory.CATEGORY_TIMES, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_WORKING
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, 
				ProcessCategory.CATEGORY_TIMES, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_ABSENCE
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureGrossIncomeConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SALARY_BASE, 
				ProcessCategory.CATEGORY_AMOUNT, 
				PendingArticleCodes2(
					ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_WORKING,
					ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_ABSENCE
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_GROSS
				), 
				"", 
				"", 
				null); 
		}

		void ConfigureTotalIncomeConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_GROSS, 
				ProcessCategory.CATEGORY_FINAL, 
				EMPTY_PENDING_CODES, 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_NETTO, 
				ProcessCategory.CATEGORY_START, 
				PendingArticleCodes9(
					ConfigSetCzArticleCode.ARTICLE_INCOME_GROSS,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_BONUS_CHILD,
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_HEALTH_EMPLOYEE_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_HEALTH_EMPLOYEE_MANDATORY,
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_EMPLOYEE_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_EMPLOYEE_PENSION,
					ConfigSetCzArticleCode.ARTICLE_GARANT_EMPLOYEE_PENSION
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureNettoDeductsConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_TOTAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes2(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_SOLIDARY
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_GENERAL
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOLIDARY, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_SOLIDARY
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_BASIS_GENERAL
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_GENERAL
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_MANDATORY
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_BASIS_GENERAL
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_PENSION, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_BASIS_PENSION
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_EMPLOYEE_PENSION, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_BASIS_PENSION
				), 
				SummaryArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				"", 
				"", 
				null); 
		}

		void ConfigureBasisHealthConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_PARTICIP, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_MANDATORY, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes2(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_LEGALCAP, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes2(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureBasisSocialConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_PARTICIP, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_PENSION, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_LEGALCAP, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureBasisGarantConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_PARTICIP, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_PENSION, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_LEGALCAP, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureBasisAdvancesConcepts ()
		{
			ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_INCOME, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_HEALTH, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_HEALTH
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOCIAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SOCIAL
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes3 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_HEALTH,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_SOCIAL
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_GENERAL
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureBasisWithholdConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_INCOME, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_HEALTH, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_HEALTH
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_SOCIAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SOCIAL
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes3(
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_INCOME,
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_HEALTH,
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_SOCIAL
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureAllowanceTaxisConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_PAYER, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_DISABILITY, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_STUDYING, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_CHILD, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void ConfigureRebateTaxisConcepts ()
		{
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_PAYER, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes4(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_PAYER,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_DISABILITY,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_STUDYING
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_CHILD, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes3(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_CHILD,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_REBATE_PAYER
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_BONUS_CHILD, 
				ProcessCategory.CATEGORY_NETTO, 
				PendingArticleCodes3(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_REBATE_PAYER,
					ConfigSetCzArticleCode.ARTICLE_TAXING_REBATE_CHILD
				), 
				EMPTY_SUMMARY_CODES, 
				"", 
				"", 
				null); 
		}

		void InitConceptsFromDirectCode ()
		{
			ConfigureContractTermConcepts ();

			ConfigurePositionTimeConcepts ();

			ConfigureGrossIncomeConcepts ();

			ConfigureTotalIncomeConcepts ();

			ConfigureNettoDeductsConcepts ();

			ConfigureBasisHealthConcepts ();

			ConfigureBasisSocialConcepts ();

			ConfigureBasisGarantConcepts ();

			ConfigureBasisAdvancesConcepts ();

			ConfigureBasisWithholdConcepts ();

			ConfigureAllowanceTaxisConcepts ();

			ConfigureRebateTaxisConcepts ();
		}

		#region implemented abstract members of ProcessConfigModule

		public override void InitArticles ()
		{
			#if (CONFIGURE_ARTICLE_GENERAL)
			InitArticlesFromAssembly ();
			#else
			InitArticlesFromDirectCode ();
			#endif
		}

		public override void InitConcepts ()
		{
			#if (CONFIGURE_CONCEPT_GENERAL)
			InitConceptsFromAssembly ();
			#else
			InitConceptsFromDirectCode ();
			#endif
		}

		#endregion

		void InitArticlesFromAssembly ()
		{
			Assembly configAssembly = typeof(ProcessConfigSetCzModule).Assembly;

			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_CONTRACT_EMPL_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_CONTRACT_WORK_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_CONTRACT_TASK_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_POSITION_EMPL_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_SCHEDULE_WORK);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_SALARY_BASE);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMESHEET_SCHEDULE);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMESHEET_WORKING);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMESHEET_ABSENCE);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_WORKING);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_ABSENCE);

			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_INCOME_GROSS);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO);
		}

		void InitConceptsFromAssembly ()
		{
			Assembly configAssembly = typeof(ProcessConfigSetCzModule).Assembly;

			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_CONTRACT_EMPL_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_CONTRACT_WORK_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_CONTRACT_TASK_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_POSITION_EMPL_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_SCHEDULE_WORK);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_SALARY_BASE);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMESHEET_SCHEDULE);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMESHEET_WORKING);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMESHEET_ABSENCE);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMEHOURS_WORKING);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMEHOURS_ABSENCE);

			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_INCOME_GROSS);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_INCOME_NETTO);
		}

		public static uint[] PendingArticleCodes1(ConfigSetCzArticleCode code1)
		{
			return new uint[] {(uint)code1};
		}

		public static uint[] SummaryArticleCodes1(ConfigSetCzArticleCode code1)
		{
			return new uint[] {(uint)code1};
		}

		public static uint[] PendingArticleCodes2(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2)
		{
			return new uint[] {(uint)code1, (uint)code2};
		}

		public static uint[] SummaryArticleCodes2(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2)
		{
			return new uint[] {(uint)code1, (uint)code2};
		}

		public static uint[] PendingArticleCodes3(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3)
		{
			return new uint[] {(uint)code1, (uint)code2, (uint)code3};
		}

		public static uint[] SummaryArticleCodes3(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3)
		{
			return new uint[] {(uint)code1, (uint)code2, (uint)code3};
		}

		public static uint[] PendingArticleCodes4(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3, ConfigSetCzArticleCode code4)
		{
			return new uint[] {(uint)code1, (uint)code2, (uint)code3, (uint)code4};
		}

		public static uint[] SummaryArticleCodes4(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3, ConfigSetCzArticleCode code4)
		{
			return new uint[] {(uint)code1, (uint)code2, (uint)code3, (uint)code4};
		}

		public static uint[] PendingArticleCodes5(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3, ConfigSetCzArticleCode code4, ConfigSetCzArticleCode code5)
		{
			return new uint[] {(uint)code1, (uint)code2, (uint)code3, (uint)code4, (uint)code5};
		}

		public static uint[] PendingArticleCodes9(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3, ConfigSetCzArticleCode code4, 
			ConfigSetCzArticleCode code5, ConfigSetCzArticleCode code6, ConfigSetCzArticleCode code7, ConfigSetCzArticleCode code8, ConfigSetCzArticleCode code9)
		{
			return new uint[] {(uint)code1, (uint)code2, (uint)code3, (uint)code4, (uint)code5, (uint)code6, (uint)code7, (uint)code8, (uint)code9};
		}
	}
}

