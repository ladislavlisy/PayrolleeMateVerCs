using System;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.Common.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Interfaces;
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
				"contract_type|health_work|social_work|date_from|date_ends", 
				"day_ordinal_from|day_ordinal_ends", 
				ConfigSetCzEvaluations.ContractEmplTermEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_POSITION_EMPL_TERM, 
				DEFAULTS_CONCEPT, POSITION_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"date_from|date_ends", 
				"day_ordinal_from|day_ordinal_ends", 
				ConfigSetCzEvaluations.PositionEmplTermEvaluation); 
		}

		private static void ConfigurePositionTimeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SCHEDULE_WORK, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"timesheet_weekly|workdays_weekly", 
				"shift_timetable", 
				ConfigSetCzEvaluations.ScheduleWorkEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_SCHEDULE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				NO_TARGET_VALUES, 
				"shift_timetable", 
				ConfigSetCzEvaluations.TimesheetScheduleEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_WORKING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				NO_TARGET_VALUES, 
				"work_timetable", 
				ConfigSetCzEvaluations.TimesheetWorkingEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMESHEET_ABSENCE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				NO_TARGET_VALUES, 
				"absence_timetable", 
				ConfigSetCzEvaluations.TimesheetAbsenceEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_WORKING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"timesheet_worked", 
				"worktime_counts", 
				ConfigSetCzEvaluations.TimehoursWorkingEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TIMEHOURS_ABSENCE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"timesheet_absent", 
				"absence_counts", 
				ConfigSetCzEvaluations.TimehoursAbsenceEvaluation); 
		}

		private static void ConfigureGrossIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SALARY_BASE, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, POSITION_QUALIFIED,
				"amount_monthly", 
				"record_time|amount_payments", 
				ConfigSetCzEvaluations.SalaryBaseEvaluation); 
		}

		private static void ConfigureTotalIncomeConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_GROSS, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"record_income", 
				ConfigSetCzEvaluations.IncomeGrossEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_INCOME_NETTO, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"record_income", 
				ConfigSetCzEvaluations.IncomeNettoEvaluation); 
		}

		private static void ConfigureNettoDeductsConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_TOTAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.TaxingAdvancesTotalEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.TaxingAdvancesGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOLIDARY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.TaxingAdvancesSolidaryEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.TaxingWithholdGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.HealthEmployeeGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_EMPLOYEE_MANDATORY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.HealthEmployeeMandatoryEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.SocialEmployeeGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_EMPLOYEE_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.SocialEmployeePensionEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_EMPLOYEE_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES, 
				"amount_deducted", 
				ConfigSetCzEvaluations.GarantEmployeePensionEvaluation); 
		}

		private static void ConfigureBasisHealthConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_residency|code_mandatory", 
				"record_income", 
				ConfigSetCzEvaluations.HealthIncomeSubjectEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.HealthIncomeParticipEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.HealthBasisGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_MANDATORY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.HealthBasisMandatoryEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_HEALTH_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.HealthBasisLegalcapEvaluation); 
		}

		private static void ConfigureBasisSocialConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_residency", 
				"record_income", 
				ConfigSetCzEvaluations.SocialIncomeSubjectEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.SocialIncomeParticipEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.SocialBasisGeneralEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.SocialBasisPensionEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_SOCIAL_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.SocialBasisLegalcapEvaluation); 
		}

		private static void ConfigureBasisGarantConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests", 
				"record_income", 
				ConfigSetCzEvaluations.GarantIncomeSubjectEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_INCOME_PARTICIP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.GarantIncomeParticipEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_PENSION, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.GarantBasisPensionEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_GARANT_BASIS_LEGALCAP, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.GarantBasisLegalcapEvaluation); 
		}

		private static void ConfigureBasisTaxingConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SUBJECT, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_residency|code_statement", 
				"record_income", 
				ConfigSetCzEvaluations.TaxingIncomeSubjectEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingIncomeHealthEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_INCOME_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				CONTRACT_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingIncomeSocialEvaluation); 
		}

		private static void ConfigureBasisAdvancesConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_INCOME, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingAdvancesIncomeEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingAdvancesHealthEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingAdvancesSocialEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingAdvancesBasisGeneralEvaluation); 
			
			module.ConfigureConcept (
				ConfigSetCzConceptName.REF_TAXING_ADVANCES_BASIS_SOLIDARY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingAdvancesBasisSolidaryEvaluation); 
		}

		private static void ConfigureBasisWithholdConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_INCOME, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingWithholdIncomeEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_HEALTH, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingWithholdHealthEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_SOCIAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingWithholdSocialEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_WITHHOLD_BASIS_GENERAL, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"record_income", 
				ConfigSetCzEvaluations.TaxingWithholdBasisGeneralEvaluation); 
		}

		private static void ConfigureAllowanceTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_PAYER, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests", 
				"record_amount", 
				ConfigSetCzEvaluations.TaxingAllowancePayerEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_DISABILITY, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_handicaps", 
				"record_amount", 
				ConfigSetCzEvaluations.TaxingAllowanceDisabilityEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_STUDYING, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests", 
				"record_amount", 
				ConfigSetCzEvaluations.TaxingAllowanceStudyingEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_ALLOWANCE_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				"code_interests|code_cardinals|code_handicaps", 
				"record_amount", 
				ConfigSetCzEvaluations.TaxingAllowanceChildEvaluation); 
		}

		private static void ConfigureRebateTaxisConcepts (ProcessConfigSetCzModule module)
		{
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_PAYER, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"amount_payments", 
				ConfigSetCzEvaluations.TaxingRebatePayerEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_REBATE_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"amount_payments", 
				ConfigSetCzEvaluations.TaxingRebateChildEvaluation); 
			
			module.ConfigureConcept(
				ConfigSetCzConceptName.REF_TAXING_BONUS_CHILD, 
				DEFAULTS_CONCEPT, DEFAULTS_CONCEPT,
				DEFAULTS_QUALIFIED, DEFAULTS_QUALIFIED,
				NO_TARGET_VALUES,  
				"amount_payments", 
				ConfigSetCzEvaluations.TaxingBonusChildEvaluation); 
		}
	}
}

