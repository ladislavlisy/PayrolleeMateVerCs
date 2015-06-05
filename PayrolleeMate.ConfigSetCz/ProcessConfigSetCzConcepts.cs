using System;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.Common.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessService.Patterns;
using PayrolleeMate.ProcessConfigSetCz.Evaluations;

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

		public const string NO_TARGET_VALUES = "";

		#if __TEST_EVALUATION__
		private static GeneralModule.EvaluateDelegate DEFAULT_EVALUATION = ConfigSetCzEvaluations.CloneEvaluation;
		#endif

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
				CONTRACT_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"date_from|date_ends", 
				"", 
				ConfigSetCzEvaluations.ContractEmplTermEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM, 
				DEFAULTS_CONCEPT, POSITION_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"date_from|date_ends", 
				"", 
				ConfigSetCzEvaluations.PositionEmplTermEvaluation); 
		}

		private static void ConfigurePositionTimeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"timesheet_weekly", 
				"", 
				ConfigSetCzEvaluations.ScheduleWorkEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.TimesheetScheduleEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.TimesheetWorkingEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.TimesheetAbsenceEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"timesheet_worked", 
				"", 
				ConfigSetCzEvaluations.TimehoursWorkingEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"timesheet_missed", 
				"", 
				ConfigSetCzEvaluations.TimehoursAbsenceEvaluation); 
		}

		private static void ConfigureGrossIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SALARY_BASE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"amount_monthly", 
				"", 
				ConfigSetCzEvaluations.SalaryBaseEvaluation); 
		}

		private static void ConfigureTotalIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_GROSS, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.IncomeGrossEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_NETTO, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.IncomeNettoEvaluation); 
		}

		private static void ConfigureNettoDeductsConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_TOTAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesTotalEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOLIDARY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesSolidaryEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.TaxingWithholdGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.HealthEmployeeGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.HealthEmployeeMandatoryEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.SocialEmployeeGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.SocialEmployeePensionEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_EMPLOYEE_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"", 
				ConfigSetCzEvaluations.GarantEmployeePensionEvaluation); 
		}

		private static void ConfigureBasisHealthConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_residency|code_mandatory", 
				"", 
				ConfigSetCzEvaluations.HealthIncomeSubjectEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.HealthIncomeParticipEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.HealthBasisGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_MANDATORY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.HealthBasisMandatoryEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.HealthBasisLegalcapEvaluation); 
		}

		private static void ConfigureBasisSocialConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_residency", 
				"", 
				ConfigSetCzEvaluations.SocialIncomeSubjectEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.SocialIncomeParticipEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.SocialBasisGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.SocialBasisPensionEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.SocialBasisLegalcapEvaluation); 
		}

		private static void ConfigureBasisGarantConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests", 
				"", 
				ConfigSetCzEvaluations.GarantIncomeSubjectEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.GarantIncomeParticipEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.GarantBasisPensionEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.GarantBasisLegalcapEvaluation); 
		}

		private static void ConfigureBasisTaxingConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_residency|code_statement", 
				"", 
				ConfigSetCzEvaluations.TaxingIncomeSubjectEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingIncomeHealthEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingIncomeSocialEvaluation); 
		}

		private static void ConfigureBasisAdvancesConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_INCOME, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesIncomeEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesHealthEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesSocialEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesBasisGeneralEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingAdvancesBasisSolidaryEvaluation); 
		}

		private static void ConfigureBasisWithholdConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_INCOME, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingWithholdIncomeEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingWithholdHealthEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingWithholdSocialEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingWithholdBasisGeneralEvaluation); 
		}

		private static void ConfigureAllowanceTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_PAYER, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests", 
				"", 
				ConfigSetCzEvaluations.TaxingAllowancePayerEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_DISABILITY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_handicaps", 
				"", 
				ConfigSetCzEvaluations.TaxingAllowanceDisabilityEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_STUDYING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests", 
				"", 
				ConfigSetCzEvaluations.TaxingAllowanceStudyingEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_cardinals|code_handicaps", 
				"", 
				ConfigSetCzEvaluations.TaxingAllowanceChildEvaluation); 
		}

		private static void ConfigureRebateTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_PAYER, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingRebatePayerEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingRebateChildEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_BONUS_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"", 
				ConfigSetCzEvaluations.TaxingBonusChildEvaluation); 
		}
	}
}

