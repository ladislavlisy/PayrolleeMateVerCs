using System;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfig.Interfaces;
using System.Reflection;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Interfaces.Loggers;
using PayrolleeMate.ProcessConfigSetCz.Collections;
using PayrolleeMate.ProcessConfigSetCz.Constants;

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
			ProcessConfigSetCzArticles.ConfigureArticles (this);
		}


		void InitConceptsFromDirectCode ()
		{
			ProcessConfigSetCzConcepts.ConfigureConcepts (this);
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
	}
}

