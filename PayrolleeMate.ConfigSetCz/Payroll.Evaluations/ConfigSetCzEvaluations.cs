using System;
using PayrolleeMate.Common.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Builders;

namespace PayrolleeMate.ProcessConfigSetCz.Evaluations
{
	public static class ConfigSetCzEvaluations
	{
		public static GeneralModule.EvaluateDelegate EmptyEvaluation = (config, engine, article, element, values, results) => {

			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate CloneEvaluation = (config, engine, article, element, values, results) => {

			IBookResult[] evaluatedResults = ResultListBuilder.BuildListWithEmptyResult(element, article);

			return evaluatedResults;
		};

		public static GeneralModule.EvaluateDelegate ContractEmplTermEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate PositionEmplTermEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate ScheduleWorkEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetScheduleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetWorkingEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetAbsenceEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimehoursWorkingEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimehoursAbsenceEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SalaryBaseEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthIncomeSubjectEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialIncomeSubjectEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantIncomeSubjectEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthIncomeParticipEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialIncomeParticipEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantIncomeParticipEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisMandatoryEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisLegalcapEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisPensionEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisLegalcapEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantBasisPensionEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantBasisLegalcapEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthEmployeeGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthEmployeeMandatoryEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialEmployeeGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialEmployeePensionEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantEmployeePensionEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeSubjectEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeHealthEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeSocialEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesIncomeEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesHealthEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesSocialEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesBasisGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesBasisSolidaryEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesSolidaryEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesTotalEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowancePayerEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceChildEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceDisabilityEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceStudyingEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingRebatePayerEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingRebateChildEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingBonusChildEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdIncomeEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdHealthEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdSocialEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdBasisGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdGeneralEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate IncomeGrossEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate IncomeNettoEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBuilder.EMPTY_RESULT_LIST;
		};
	}

	static class ResultListBuilder
	{
		public static IBookResult[] BuildListWithEmptyResult(IBookIndex element, IPayrollArticle article)
		{
			IBookResult result = BookResultBuilder.CreateEmptyResult(element, article);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildListWithResult(IBookResult result)
		{
			IBookResult[] evaluatedResults = new IBookResult[] { result };

			return evaluatedResults;
		}
	}
}

