using System;
using PayrolleeMate.Common.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessService.Patterns;

namespace PayrolleeMate.ProcessConfigSetCz.Evaluations
{
	public static class ConfigSetCzEvaluations
	{
		public static GeneralModule.EvaluateDelegate EmptyEvaluation = (config, engine, article, element, values, results) => {

			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate CloneEvaluation = (config, engine, article, element, values, results) => {

			IBookResult result = new EmptyBookResult(element, article);

			IBookResult[] evaluatedResults = new IBookResult[] { result };

			return evaluatedResults;
		};

		public static GeneralModule.EvaluateDelegate ContractEmplTermArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate PositionEmplTermArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate UnknownArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate ScheduleWorkArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetScheduleArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetWorkingArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetAbsenceArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimehoursWorkingArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimehoursAbsenceArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SalaryBaseArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthIncomeSubjectArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialIncomeSubjectArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantIncomeSubjectArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthIncomeParticipArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialIncomeParticipArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantIncomeParticipArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisMandatoryArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisLegalcapArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisPensionArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisLegalcapArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantBasisPensionArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantBasisLegalcapArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthEmployeeGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthEmployeeMandatoryArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialEmployeeGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialEmployeePensionArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantEmployeePensionArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeSubjectArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeHealthArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeSocialArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesIncomeArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesHealthArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesSocialArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesBasisGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesBasisSolidaryArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesSolidaryArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesTotalArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowancePayerArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceChildArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceDisabilityArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceStudyingArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingRebatePayerArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingRebateChildArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingBonusChildArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdIncomeArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdHealthArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdSocialArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdBasisGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdGeneralArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate IncomeGrossArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate IncomeNettoArticleEvaluation = (config, engine, article, element, values, results) => {
			return BookResultBase.EMPTY_RESULT_LIST;
		};
	}
}

