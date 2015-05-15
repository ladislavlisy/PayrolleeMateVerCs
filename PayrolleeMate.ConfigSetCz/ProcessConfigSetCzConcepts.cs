using System;
using PayrolleeMate.ProcessConfigSetCz.Constants;

namespace PayrolleeMate.ProcessConfigSetCz
{
	public class ProcessConfigSetCzConcepts
	{
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

		private static void ConfigureContractTermConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_CONTRACT_EMPL_TERM, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM, 
				"", 
				"", 
				null); 
		}

		private static void ConfigurePositionTimeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureGrossIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SALARY_BASE, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureTotalIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_GROSS, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_NETTO, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureNettoDeductsConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_TOTAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_GENERAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOLIDARY, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_GENERAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_GENERAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_PENSION, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_EMPLOYEE_PENSION, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisHealthConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_SUBJECT, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_PARTICIP, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_GENERAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_MANDATORY, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_LEGALCAP, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisSocialConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_SUBJECT, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_PARTICIP, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_GENERAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_PENSION, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_LEGALCAP, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisGarantConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_SUBJECT, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_PARTICIP, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_PENSION, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_LEGALCAP, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisTaxingConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SUBJECT, 
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_HEALTH, 
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SOCIAL, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisAdvancesConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_INCOME, 
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_HEALTH, 
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOCIAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisWithholdConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_INCOME, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_HEALTH, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_SOCIAL, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureAllowanceTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_PAYER, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_DISABILITY, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_STUDYING, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_CHILD, 
				"", 
				"", 
				null); 
		}

		private static void ConfigureRebateTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_PAYER, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_CHILD, 
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_BONUS_CHILD, 
				"", 
				"", 
				null); 
		}
	}
}

