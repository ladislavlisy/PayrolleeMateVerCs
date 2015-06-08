using System;
using PayrolleeMate.Common.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Builders;
using System.Linq;

namespace PayrolleeMate.ProcessConfigSetCz.Evaluations
{
	public static class ConfigSetCzEvaluations
	{
		public static GeneralModule.EvaluateDelegate EmptyEvaluation = (concept, config, engine, article, element, targets, results) => {

			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate CloneEvaluation = (concept, config, engine, article, element, values, results) => {

			IBookResult[] evalResults = ResultListBuilder.BuildListWithEmptyResult(element, article);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate ContractEmplTermEvaluation = (concept, config, engine, article, element, targets, results) => {
			uint resultDayFromOrdinal = engine.Period().DayFromOrdinal(engine.PayrunPeriod(), targets.DateFrom());

			uint resultDayEndsOrdinal = engine.Period().DayEndsOrdinal(engine.PayrunPeriod(), targets.DateEnds());

			IBookResult[] evalResults = ResultListBuilder.BuildContractEmplTermResults(concept, element, article, targets, 
				resultDayFromOrdinal, resultDayEndsOrdinal);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate PositionEmplTermEvaluation = (concept, config, engine, article, element, targets, results) => {
			var listOfDayFromOrdinal = results.Results().Where(x => x.Key.CodeOrder()==element.ContractOrder()).
				Select(c => c.Value.Values().PeriodDayFromOrdinal()).ToArray();
			
			var listOfDayEndsOrdinal = results.Results().Where(x => x.Key.CodeOrder()==element.ContractOrder()).
				Select(c => c.Value.Values().PeriodDayEndsOrdinal()).ToArray();
			
			var contractDayFromOrdinal = listOfDayFromOrdinal.Aggregate(0u, (agr, c) => agr > 0u ? agr : c);

			var contractDayEndsOrdinal = listOfDayEndsOrdinal.Aggregate(0u, (agr, c) => agr > 0u ? agr : c);

			uint dayFromOrdinal = engine.Period().DayFromOrdinal(engine.PayrunPeriod(), targets.DateFrom());

			uint dayEndsOrdinal = engine.Period().DayEndsOrdinal(engine.PayrunPeriod(), targets.DateEnds());

			uint resultDayFromOrdinal = Math.Max(contractDayFromOrdinal, dayFromOrdinal);

			uint resultDayEndsOrdinal = Math.Min(contractDayEndsOrdinal, dayEndsOrdinal);


			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate ScheduleWorkEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetScheduleEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetWorkingEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimesheetAbsenceEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimehoursWorkingEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TimehoursAbsenceEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SalaryBaseEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthIncomeSubjectEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialIncomeSubjectEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantIncomeSubjectEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthIncomeParticipEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialIncomeParticipEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantIncomeParticipEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisMandatoryEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthBasisLegalcapEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisPensionEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialBasisLegalcapEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantBasisPensionEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantBasisLegalcapEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthEmployeeGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate HealthEmployeeMandatoryEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialEmployeeGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate SocialEmployeePensionEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate GarantEmployeePensionEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeSubjectEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeHealthEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingIncomeSocialEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesIncomeEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesHealthEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesSocialEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesBasisGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesBasisSolidaryEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesSolidaryEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAdvancesTotalEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowancePayerEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceChildEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceDisabilityEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingAllowanceStudyingEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingRebatePayerEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingRebateChildEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingBonusChildEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdIncomeEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdHealthEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdSocialEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdBasisGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate TaxingWithholdGeneralEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate IncomeGrossEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};

		public static GeneralModule.EvaluateDelegate IncomeNettoEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
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

		public static IBookResult[] BuildContractEmplTermResults (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, uint dayFromOrdinal, uint dayEndsOrdinal)
		{
			IBookResult result = BookResultBuilder.CreateContractEmplTermResult(concept, element, article, targets, dayFromOrdinal, dayEndsOrdinal);

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

