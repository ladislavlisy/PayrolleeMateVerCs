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
				true, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM, 
				false, true,
				"", 
				"", 
				null); 
		}

		private static void ConfigurePositionTimeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureGrossIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SALARY_BASE, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureTotalIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_GROSS, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_NETTO, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureNettoDeductsConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_TOTAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOLIDARY, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_PENSION, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_EMPLOYEE_PENSION, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisHealthConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_SUBJECT, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_PARTICIP, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_MANDATORY, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_LEGALCAP, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisSocialConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_SUBJECT, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_PARTICIP, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_PENSION, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_LEGALCAP, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisGarantConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_SUBJECT, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_PARTICIP, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_PENSION, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_LEGALCAP, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisTaxingConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SUBJECT, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_HEALTH, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SOCIAL, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisAdvancesConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_INCOME, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_HEALTH, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOCIAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureBasisWithholdConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_INCOME, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_HEALTH, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_SOCIAL, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureAllowanceTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_PAYER, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_DISABILITY, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_STUDYING, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_CHILD, 
				false, false,
				"", 
				"", 
				null); 
		}

		private static void ConfigureRebateTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_PAYER, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_CHILD, 
				false, false,
				"", 
				"", 
				null); 
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_BONUS_CHILD, 
				false, false,
				"", 
				"", 
				null); 
		}
	}
}

