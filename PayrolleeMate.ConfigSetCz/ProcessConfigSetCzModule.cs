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

		#region implemented abstract members of ProcessConfigModule

		public override void InitArticles ()
		{
			#if (CONFIGURE_ARTICLE_GENERAL)
			Assembly configAssembly = typeof(ProcessConfigSetCzModule).Assembly;

			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_CONTRACT_EMPL_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_CONTRACT_WORK_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_CONTRACT_TASK_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_POSITION_TERM);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_SCHEDULE_WORK);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_SALARY_BASE);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMESHEET_SCHEDULE);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMESHEET_WORKING);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMESHEET_ABSENCE);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_WORKING);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_ABSENCE);

			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_INCOME_GROSS);
			ArticleFromModels(configAssembly, (uint)ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO);
			#else
			ConfigureArticle (
				ConfigSetCzArticleName.REF_CONTRACT_EMPL_TERM, 
				ConfigSetCzConceptName.REF_CONTRACT_EMPL_TERM,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_CONTRACT_WORK_TERM, 
				ConfigSetCzConceptName.REF_CONTRACT_WORK_TERM,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_CONTRACT_TASK_TERM, 
				ConfigSetCzConceptName.REF_CONTRACT_TASK_TERM,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_POSITION_TERM, 
				ConfigSetCzConceptName.REF_POSITION_TERM,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_SCHEDULE_WORK, 
				ConfigSetCzConceptName.REF_SCHEDULE_WORK,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_SALARY_BASE, 
				ConfigSetCzConceptName.REF_SALARY_BASE,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMESHEET_SCHEDULE, 
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMESHEET_WORKING, 
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMEHOURS_WORKING, 
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_TIMEHOURS_ABSENCE, 
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_INCOME_GROSS, 
				ConfigSetCzConceptName.REF_INCOME_GROSS,
				false, false, false, false, false, false);
			ConfigureArticle (
				ConfigSetCzArticleName.REF_INCOME_NETTO, 
				ConfigSetCzConceptName.REF_INCOME_NETTO,
				false, false, false, false, false, false);
			#endif
		}

		public override void InitConcepts ()
		{
			#if (CONFIGURE_CONCEPT_GENERAL)
			Assembly configAssembly = typeof(ProcessConfigSetCzModule).Assembly;

			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_CONTRACT_EMPL_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_CONTRACT_WORK_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_CONTRACT_TASK_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_POSITION_TERM);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_SCHEDULE_WORK);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_SALARY_BASE);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMESHEET_SCHEDULE);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMESHEET_WORKING);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMESHEET_ABSENCE);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMEHOURS_WORKING);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_TIMEHOURS_ABSENCE);

			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_INCOME_GROSS);
			ConceptFromModels(configAssembly, (uint)ConfigSetCzConceptCode.CONCEPT_INCOME_NETTO);
			#else
			ConfigureConcept(
				ConfigSetCzConceptName.REF_CONTRACT_EMPL_TERM, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_CONTRACT_WORK_TERM, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_CONTRACT_TASK_TERM, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_POSITION_TERM, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_SALARY_BASE, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_GROSS, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_NETTO, ProcessCategory.CATEGORY_START, 
				GeneralPayrollConcept.EMPTY_ARTICLES, GeneralPayrollConcept.EMPTY_ARTICLES, "", "", null); 
			#endif
		}

		#endregion
	}
}

