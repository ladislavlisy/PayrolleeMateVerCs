using System;
using PayrolleeMate.Common.Core;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfigSetCz
{
	public class ProcessConfigSetCzArticles
	{
		protected static readonly SymbolName[] EMPTY_PENDING_NAMES = GeneralPayrollArticle.EMPTY_ARTICLE_NAMES;

		protected static readonly SymbolName[] EMPTY_SUMMARY_NAMES = GeneralPayrollArticle.EMPTY_ARTICLE_NAMES;

		protected const bool IGNORE_TAXING_INCOME = false;

		protected const bool IGNORE_HEALTH_INCOME = false;

		protected const bool IGNORE_SOCIAL_INCOME = false;

		protected const bool IGNORE_GROSS_SUMMARY = false;

		protected const bool IGNORE_NETTO_SUMMARY = false;

		protected const bool IGNORE_NETTO_DEDUCTS = false;

		protected const bool ACCEPT_TAXING_INCOME = true;

		protected const bool ACCEPT_HEALTH_INCOME = true;

		protected const bool ACCEPT_SOCIAL_INCOME = true;

		protected const bool ACCEPT_GROSS_SUMMARY = true;

		protected const bool ACCEPT_NETTO_SUMMARY = true;

		protected const bool ACCEPT_NETTO_DEDUCTS = true;

		public static void ConfigureArticles(ProcessConfigSetCzModule module)
		{
			ConfigureContractTermArticles (module);

			ConfigurePositionTimeArticles (module);

			ConfigureGrossIncomeArticles (module);

			ConfigureTotalIncomeArticles (module);

			ConfigureNettoDeductsArticles (module);

			ConfigureBasisHealthArticles (module);

			ConfigureBasisSocialArticles (module);

			ConfigureBasisGarantArticles (module);

			ConfigureBasisTaxingArticles (module);

			ConfigureBasisAdvancesArticles (module);

			ConfigureBasisWithholdArticles (module);

			ConfigureAllowanceTaxisArticles (module);

			ConfigureRebateTaxisArticles (module);
		}

		private static void ConfigureContractTermArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_TERMS;

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_CONTRACT_EMPL_TERM, 
				ConfigSetCzConceptName.REF_CONTRACT_EMPL_TERM, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_POSITION_EMPL_TERM, 
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_CONTRACT_EMPL_TERM
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigurePositionTimeArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_TIMES; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SCHEDULE_WORK, 
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_POSITION_EMPL_TERM
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TIMESHEET_SCHEDULE, 
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_SCHEDULE_WORK
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TIMESHEET_WORKING, 
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, 
				configCategory,
				PendingArticleNames2(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_SCHEDULE,
					ConfigSetCzArticleCode.ARTICLE_POSITION_EMPL_TERM
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TIMESHEET_ABSENCE, 
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_WORKING
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TIMEHOURS_WORKING, 
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_WORKING
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TIMEHOURS_ABSENCE, 
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TIMESHEET_ABSENCE
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureGrossIncomeArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_AMOUNT; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SALARY_BASE, 
				ConfigSetCzConceptName.REF_SALARY_BASE, 
				configCategory,
				PendingArticleNames2(
					ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_WORKING,
					ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_ABSENCE
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_GROSS
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureTotalIncomeArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_FINAL; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_INCOME_GROSS, 
				ConfigSetCzConceptName.REF_INCOME_GROSS, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_INCOME_NETTO, 
				ConfigSetCzConceptName.REF_INCOME_NETTO, 
				configCategory,
				PendingArticleNames9(
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
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureNettoDeductsArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_TOTAL, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_TOTAL, 
				configCategory,
				PendingArticleNames2(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_SOLIDARY
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_GENERAL, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_GENERAL, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_GENERAL
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_SOLIDARY, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOLIDARY, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_SOLIDARY
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_WITHHOLD_GENERAL, 
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_GENERAL, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_BASIS_GENERAL
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_HEALTH_EMPLOYEE_GENERAL, 
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_GENERAL, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_GENERAL
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_MANDATORY
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_BASIS_GENERAL
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SOCIAL_EMPLOYEE_PENSION, 
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_PENSION, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_BASIS_PENSION
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_GARANT_EMPLOYEE_PENSION, 
				ConfigSetCzConceptName.REF_GARANT_EMPLOYEE_PENSION, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_BASIS_PENSION
				), 
				SummaryArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_INCOME_NETTO
				), 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureBasisHealthArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_HEALTH_INCOME_SUBJECT, 
				ConfigSetCzConceptName.REF_HEALTH_INCOME_SUBJECT, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_HEALTH_INCOME_PARTICIP, 
				ConfigSetCzConceptName.REF_HEALTH_INCOME_PARTICIP, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_HEALTH_BASIS_GENERAL, 
				ConfigSetCzConceptName.REF_HEALTH_BASIS_GENERAL, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_HEALTH_BASIS_MANDATORY, 
				ConfigSetCzConceptName.REF_HEALTH_BASIS_MANDATORY, 
				configCategory,
				PendingArticleNames2(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_HEALTH_BASIS_LEGALCAP, 
				ConfigSetCzConceptName.REF_HEALTH_BASIS_LEGALCAP, 
				configCategory,
				PendingArticleNames2(
					ConfigSetCzArticleCode.ARTICLE_HEALTH_BASIS_GENERAL,
					ConfigSetCzArticleCode.ARTICLE_HEALTH_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureBasisSocialArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SOCIAL_INCOME_SUBJECT, 
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_SUBJECT, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SOCIAL_INCOME_PARTICIP, 
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_PARTICIP, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SOCIAL_BASIS_GENERAL, 
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_GENERAL, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SOCIAL_BASIS_PENSION, 
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_PENSION, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_SOCIAL_BASIS_LEGALCAP, 
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_LEGALCAP, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_SOCIAL_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureBasisGarantArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_GARANT_INCOME_SUBJECT, 
				ConfigSetCzConceptName.REF_GARANT_INCOME_SUBJECT, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_GARANT_INCOME_PARTICIP, 
				ConfigSetCzConceptName.REF_GARANT_INCOME_PARTICIP, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_GARANT_BASIS_PENSION, 
				ConfigSetCzConceptName.REF_GARANT_BASIS_PENSION, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_GARANT_BASIS_LEGALCAP, 
				ConfigSetCzConceptName.REF_GARANT_BASIS_LEGALCAP, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_GARANT_INCOME_PARTICIP
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureBasisTaxingArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_INCOME_SUBJECT, 
				ConfigSetCzConceptName.REF_TAXING_INCOME_SUBJECT, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_INCOME_HEALTH, 
				ConfigSetCzConceptName.REF_TAXING_INCOME_HEALTH, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_INCOME_SOCIAL, 
				ConfigSetCzConceptName.REF_TAXING_INCOME_SOCIAL, 
				configCategory,
				EMPTY_PENDING_NAMES, 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureBasisAdvancesArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_INCOME, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_INCOME, 
				configCategory,
				PendingArticleNames1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_HEALTH, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_HEALTH, 
				configCategory,
				PendingArticleNames1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_HEALTH
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_SOCIAL, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOCIAL, 
				configCategory,
				PendingArticleNames1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SOCIAL
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				configCategory,
				PendingArticleNames3 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_HEALTH,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_SOCIAL
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				configCategory,
				PendingArticleNames1 (
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_GENERAL
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureBasisWithholdArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_WITHHOLD_INCOME, 
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_INCOME, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SUBJECT
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_WITHHOLD_HEALTH, 
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_HEALTH, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_HEALTH
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_WITHHOLD_SOCIAL, 
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_SOCIAL, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_INCOME_SOCIAL
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				configCategory,
				PendingArticleNames3(
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_INCOME,
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_HEALTH,
					ConfigSetCzArticleCode.ARTICLE_TAXING_WITHHOLD_SOCIAL
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureAllowanceTaxisArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ALLOWANCE_PAYER, 
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_PAYER, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ALLOWANCE_DISABILITY, 
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_DISABILITY, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ALLOWANCE_STUDYING, 
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_STUDYING, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_ALLOWANCE_CHILD, 
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_CHILD, 
				configCategory,
				PendingArticleNames1(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_INCOME
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		private static void ConfigureRebateTaxisArticles (ProcessConfigSetCzModule module)
		{
			ProcessCategory configCategory = ProcessCategory.CATEGORY_NETTO; 

			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_REBATE_PAYER, 
				ConfigSetCzConceptName.REF_TAXING_REBATE_PAYER, 
				configCategory,
				PendingArticleNames4(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_PAYER,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_DISABILITY,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_STUDYING
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_REBATE_CHILD, 
				ConfigSetCzConceptName.REF_TAXING_REBATE_CHILD, 
				configCategory,
				PendingArticleNames3(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ALLOWANCE_CHILD,
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_REBATE_PAYER
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
			module.ConfigureArticle(
				ConfigSetCzArticleName.REF_TAXING_BONUS_CHILD, 
				ConfigSetCzConceptName.REF_TAXING_BONUS_CHILD, 
				configCategory,
				PendingArticleNames3(
					ConfigSetCzArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL,
					ConfigSetCzArticleCode.ARTICLE_TAXING_REBATE_PAYER,
					ConfigSetCzArticleCode.ARTICLE_TAXING_REBATE_CHILD
				), 
				EMPTY_SUMMARY_NAMES, 
				IGNORE_TAXING_INCOME,
				IGNORE_HEALTH_INCOME,
				IGNORE_SOCIAL_INCOME,
				IGNORE_GROSS_SUMMARY,
				IGNORE_NETTO_SUMMARY,
				IGNORE_NETTO_DEDUCTS);
		}

		public static SymbolName[] PendingArticleNames1(ConfigSetCzArticleCode code1)
		{
			return new SymbolName[] {
				code1.GetSymbol()
			};
		}

		public static SymbolName[] SummaryArticleNames1(ConfigSetCzArticleCode code1)
		{
			return new SymbolName[] {
				code1.GetSymbol()
			};
		}

		public static SymbolName[] PendingArticleNames2(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2)
		{
			return new SymbolName[] {
				code1.GetSymbol(), code2.GetSymbol()
			};
		}

		public static SymbolName[] SummaryArticleNames2(ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2)
		{
			return new SymbolName[] {
				code1.GetSymbol(), code2.GetSymbol()
			};
		}

		public static SymbolName[] PendingArticleNames3(
			ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3)
		{
			return new SymbolName[] {
				code1.GetSymbol(), code2.GetSymbol(), code3.GetSymbol()
			};
		}

		public static SymbolName[] PendingArticleNames4(
			ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, 
			ConfigSetCzArticleCode code3, ConfigSetCzArticleCode code4)
		{
			return new SymbolName[] {
				code1.GetSymbol(), code2.GetSymbol(), 
				code3.GetSymbol(), code4.GetSymbol()
			};
		}

		public static SymbolName[] PendingArticleNames5(
			ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, 
			ConfigSetCzArticleCode code3, ConfigSetCzArticleCode code4, ConfigSetCzArticleCode code5)
		{
			return new SymbolName[] {
				code1.GetSymbol(), code2.GetSymbol(), 
				code3.GetSymbol(), code4.GetSymbol(), code5.GetSymbol()
			};
		}

		public static SymbolName[] PendingArticleNames9(
			ConfigSetCzArticleCode code1, ConfigSetCzArticleCode code2, ConfigSetCzArticleCode code3, 
			ConfigSetCzArticleCode code4, ConfigSetCzArticleCode code5, ConfigSetCzArticleCode code6, 
			ConfigSetCzArticleCode code7, ConfigSetCzArticleCode code8, ConfigSetCzArticleCode code9)
		{
			return new SymbolName[] {
				code1.GetSymbol(), code2.GetSymbol(), code3.GetSymbol(), 
				code4.GetSymbol(), code5.GetSymbol(), code6.GetSymbol(), 
				code7.GetSymbol(), code8.GetSymbol(), code9.GetSymbol()
			};
		}
	}
}

