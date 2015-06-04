using System;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.Common.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessService.Patterns;

namespace PayrolleeMate.ProcessConfigSetCz
{
	public class ProcessConfigSetCzConcepts
	{
		public const bool CONTRACT_CONCEPT = true;

		public const bool POSITION_CONCEPT = true;

		public const bool DEFAULTS_CONCEPT = false;

		public const bool CONTRACT_QUALIFIED = true;

		public const bool POSITION_QUALIFIED = true;

		public const bool DEFAULTS_QUALIFIED = false;

		public static void ConfigureConcepts(ProcessConfigSetCzModule module)
		{
			ConfigureContractTermConcepts (module);

			ConfigurePositionTimeConcepts (module);

			ConfigureGrossIncomeConcepts (module);

			ConfigureTotalIncomeConcepts (module);

			ConfigureNettoDeductsConcepts (module);

			ConfigureBasisHealthConcepts (module);

			ConfigureBasisSocialConcepts (module);

			ConfigureBasisGarantConcepts (module);

			ConfigureBasisTaxingConcepts (module);

			ConfigureBasisAdvancesConcepts (module);

			ConfigureBasisWithholdConcepts (module);

			ConfigureAllowanceTaxisConcepts (module);

			ConfigureRebateTaxisConcepts (module);
		}

		private static GeneralModule.EvaluateDelegate dummyEvaluation = (config, engine, article, element, values, results) => {

			IBookResult result = new EmptyBookResult(article);

			IDictionary<IBookIndex, IBookResult> defaultResults = new Dictionary<IBookIndex, IBookResult>() { {element, result} };

			return results.BuildResultStream(defaultResults);
		};
			
		private static void ConfigureContractTermConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_CONTRACT_EMPL_TERM, 
				CONTRACT_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				dummyEvaluation); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM, 
				DEFAULTS_CONCEPT, POSITION_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigurePositionTimeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureGrossIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SALARY_BASE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureTotalIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_GROSS, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_NETTO, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureNettoDeductsConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_TOTAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOLIDARY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_EMPLOYEE_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisHealthConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_MANDATORY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisSocialConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisGarantConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisTaxingConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisAdvancesConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_INCOME, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisWithholdConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_INCOME, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureAllowanceTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_PAYER, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_DISABILITY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_STUDYING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}

		private static void ConfigureRebateTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_PAYER, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_BONUS_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"", 
				"", 
				null); 
		}
	}
}

