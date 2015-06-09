using System;
using PayrolleeMate.Common.Interfaces;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Builders;
using System.Linq;
using PayrolleeMate.ProcessConfigSetCz.Constants;
using PayrolleeMate.ProcessConfig.Items;

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

		public static GeneralModule.EvaluateDelegate ContractEmplTermEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint dayFromContract = engine.Period().DayFromOrdinal(engine.PayrunPeriod(), targets.DateFrom());

			uint dayEndsContract = engine.Period().DayEndsOrdinal(engine.PayrunPeriod(), targets.DateEnds());

			IBookResult[] evalResults = ResultListBuilder.BuildContractEmplTermResults(concept, element, article, 
				targets, dayFromContract, dayEndsContract);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate PositionEmplTermEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint dayFromContract = ResultValuesExtractor.GetContractDayFrom(results, element.ContractIndex());

			uint dayEndsContract = ResultValuesExtractor.GetContractDayEnds(results, element.ContractIndex());

			uint dayFromPosition = engine.Period().DayFromOrdinal(engine.PayrunPeriod(), targets.DateFrom());

			uint dayEndsPosition = engine.Period().DayEndsOrdinal(engine.PayrunPeriod(), targets.DateEnds());

			uint dayFromResult = Math.Max(dayFromContract, dayFromPosition);

			uint dayEndsResult = Math.Min(dayEndsContract, dayEndsPosition);

			IBookResult[] evalResults = ResultListBuilder.BuildPositionEmplTermResults(concept, element, article, 
				targets, dayFromResult, dayEndsResult);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate ScheduleWorkEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			var scheduleTimeTable = engine.Period().WeekWorkSchedule(engine.PayrunPeriod(), targets.TimesheetWeekly(), targets.WorkdaysWeekly());

			IBookResult[] evalResults = ResultListBuilder.BuildScheduleWorkResults(concept, element, article, 
				targets, scheduleTimeTable);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate TimesheetScheduleEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint scheduleCode = ConfigSetCzArticleCode.ARTICLE_SCHEDULE_WORK.Code();

			var scheduleHours = ResultValuesExtractor.GetShiftTimetable(results, element.GetParty(), scheduleCode);

			var monthSchedule = engine.Period().MonthWorkSchedule(engine.PayrunPeriod(), scheduleHours);

			IBookResult[] evalResults = ResultListBuilder.BuildTimesheetScheduleResult(concept, element, article, 
				targets, monthSchedule);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate TimesheetWorkingEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint dayFromPosition = ResultValuesExtractor.GetPositionDayFrom(results, element.GetParty());

			uint dayEndsPosition = ResultValuesExtractor.GetPositionDayEnds(results, element.GetParty());

			uint timaeheetCode = ConfigSetCzArticleCode.ARTICLE_TIMESHEET_SCHEDULE.Code();

			var timesheetHours = ResultValuesExtractor.GetShiftTimetable(results, element.GetParty(), timaeheetCode);

			var monthSchedule = engine.Period().TimesheetWorkSchedule(engine.PayrunPeriod(), timesheetHours, dayFromPosition, dayEndsPosition);

			IBookResult[] evalResults = ResultListBuilder.BuildTimesheetWorkingResult(concept, element, article, 
				targets, monthSchedule);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate TimesheetAbsenceEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint dayFromPosition = ResultValuesExtractor.GetPositionDayFrom(results, element.GetParty());

			uint dayEndsPosition = ResultValuesExtractor.GetPositionDayEnds(results, element.GetParty());

			uint dayFromAbsence = Math.Max(32, dayFromPosition);

			uint dayEndsAbsence = Math.Min( 0, dayEndsPosition);

			Int32[] absenceHours = new Int32[] {};

			var monthSchedule = engine.Period().TimesheetAbsenceSchedule(engine.PayrunPeriod(), absenceHours, dayFromAbsence, dayEndsAbsence);

			IBookResult[] evalResults = ResultListBuilder.BuildTimesheetAbsenceResult(concept, element, article, 
				targets, monthSchedule);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate TimehoursWorkingEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint timaeheetCode = ConfigSetCzArticleCode.ARTICLE_TIMESHEET_WORKING.Code();

			var timesheetHours = ResultValuesExtractor.GetSumWorkingTimetable(results, element.GetParty(), timaeheetCode);

			IBookResult[] evalResults = ResultListBuilder.BuildTimehoursWorkingResult(concept, element, article, 
				targets, timesheetHours);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate TimehoursAbsenceEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint timaeheetCode = ConfigSetCzArticleCode.ARTICLE_TIMESHEET_ABSENCE.Code();

			var timesheetHours = ResultValuesExtractor.GetSumAbsenceTimetable(results, element.GetParty(), timaeheetCode);

			IBookResult[] evalResults = ResultListBuilder.BuildTimehoursAbsenceResult(concept, element, article, 
				targets, timesheetHours);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate SalaryBaseEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint sumtimeHoursCode = ConfigSetCzArticleCode.ARTICLE_TIMESHEET_SCHEDULE.Code();

			uint workingHoursCode = ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_WORKING.Code();

			uint absenceHoursCode = ConfigSetCzArticleCode.ARTICLE_TIMEHOURS_ABSENCE.Code();

			var sumtimeMonthHours = ResultValuesExtractor.GetSumShiftTimetable(results, element.GetParty(), sumtimeHoursCode);

			var workingMonthHours = ResultValuesExtractor.GetWorkingHours(results, element.GetParty(), workingHoursCode);

			var absenceMonthHours = ResultValuesExtractor.GetAbsenceHours(results, element.GetParty(), absenceHoursCode);

			var salaryAmountMonth = targets.AmountMonthly();

			var resultSalaryHours = engine.Period().TotalHoursForSalary(engine.PayrunPeriod(), 
				sumtimeMonthHours, workingMonthHours, absenceMonthHours);
			
			var factorMonthSalary = engine.Period().SalaryAmountWorkingTime(engine.PayrunPeriod(), salaryAmountMonth, 
				sumtimeMonthHours, workingMonthHours, absenceMonthHours);
			
			var resultMonthSalary = engine.Period().SalaryAmountWorkingTime(engine.PayrunPeriod(), salaryAmountMonth, 
				sumtimeMonthHours, workingMonthHours, absenceMonthHours);

			IBookResult[] evalResults = ResultListBuilder.BuildSalaryBaseResult(concept, element, article, 
				targets, factorMonthSalary, resultMonthSalary, resultSalaryHours);

			return evalResults;
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

		public static GeneralModule.EvaluateDelegate IncomeGrossEvaluation = (concept, config, engine, article, element, targets, results) => 
		{
			uint summaryCode = ConfigSetCzArticleCode.ARTICLE_INCOME_GROSS.Code();

			var summaryIncome = ResultValuesExtractor.GetSummaryPaymentAmount(results, element.ContractIndex(), summaryCode);

			IBookResult[] evalResults = ResultListBuilder.BuildIncomeGrossResult(concept, element, article, 
				targets, summaryIncome);

			return evalResults;
		};

		public static GeneralModule.EvaluateDelegate IncomeNettoEvaluation = (concept, config, engine, article, element, targets, results) => {
			return GeneralModule.EMPTY_RESULT_LIST;
		};
	}

	static class ResultValuesExtractor
	{
		public static uint GetContractDayFrom (IResultStream results, ICodeIndex contract)
		{
			var contractResult = results.GetContractResult(contract);

			return contractResult.PeriodDayFromOrdinal();
		}

		public static uint GetContractDayEnds (IResultStream results, ICodeIndex contract)
		{
			var contractResult = results.GetContractResult(contract);

			return contractResult.PeriodDayEndsOrdinal();
		}

		public static uint GetPositionDayFrom (IResultStream results, IBookParty position)
		{
			var positionResult = results.GetPositionResult(position);

			return positionResult.PeriodDayFromOrdinal();
		}

		public static uint GetPositionDayEnds (IResultStream results, IBookParty position)
		{
			var positionResult = results.GetPositionResult(position);

			return positionResult.PeriodDayEndsOrdinal();
		}

		public static Int32[] GetShiftTimetable (IResultStream results, IBookParty position, uint articleCode)
		{
			var resultList = results.GetPositionPartyResultList(position, articleCode);

			var resultValue = resultList.Select(x => x.ShiftTimetable()).DefaultIfEmpty(ResultValues.NULL_TIME_TABLE).FirstOrDefault();

			return resultValue;
		}

		public static Int32 GetSumShiftTimetable (IResultStream results, IBookParty position, uint articleCode)
		{
			var resultList = results.GetPositionPartyResultList(position, articleCode);

			var resultHours = resultList.Select(x => x.ShiftTimetable()).DefaultIfEmpty(ResultValues.NULL_TIME_TABLE).FirstOrDefault();

			var resultValue = resultHours.Aggregate (0, (agr, x) => (agr + x));

			return resultValue;
		}

		public static Int32 GetSumWorkingTimetable (IResultStream results, IBookParty position, uint articleCode)
		{
			var resultList = results.GetPositionPartyResultList(position, articleCode);

			var resultHours = resultList.Select(x => x.WorkTimetable()).DefaultIfEmpty(ResultValues.NULL_TIME_TABLE).FirstOrDefault();

			var resultValue = resultHours.Aggregate (0, (agr, x) => (agr + x));

			return resultValue;
		}

		public static Int32 GetSumAbsenceTimetable (IResultStream results, IBookParty position, uint articleCode)
		{
			var resultList = results.GetPositionPartyResultList(position, articleCode);

			var resultHours = resultList.Select(x => x.AbsenceTimetable()).DefaultIfEmpty(ResultValues.NULL_TIME_TABLE).FirstOrDefault();

			var resultValue = resultHours.Aggregate (0, (agr, x) => (agr + x));

			return resultValue;
		}

		public static Int32 GetWorkingHours (IResultStream results, IBookParty position, uint articleCode)
		{
			var resultList = results.GetPositionPartyResultList(position, articleCode);

			var resultValue = resultList.Select(x => x.WorktimeCount()).DefaultIfEmpty(ResultValues.NULL_TIME_COUNTS).FirstOrDefault();

			return resultValue;
		}
			
		public static Int32 GetAbsenceHours (IResultStream results, IBookParty position, uint articleCode)
		{
			var resultList = results.GetPositionPartyResultList(position, articleCode);

			var resultValue = resultList.Select(x => x.AbsenceCount()).DefaultIfEmpty(ResultValues.NULL_TIME_COUNTS).FirstOrDefault();

			return resultValue;
		}

		public static decimal GetSummaryPaymentAmount (IResultStream results, ICodeIndex contract, uint articleCode)
		{
			var resultList = results.GetContractPartySummaryList(contract, articleCode);

			var resultAmounts = resultList.Select(x => x.AmountPayments()).ToArray();

			var resultValue = resultAmounts.Aggregate (0m, (agr, x) => (decimal.Add(agr, x)));

			return resultValue;
		}

	}

	static class ResultListBuilder
	{
		public static IBookResult[] BuildListWithEmptyResult(IBookIndex element, IPayrollArticle article)
		{
			IBookResult result = BookResultBuilder.CreateEmptyResult(element, article);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildListWithCloneResult(IPayrollConcept concept, IBookIndex element, IPayrollArticle article, ITargetValues targets)
		{
			IBookResult result = BookResultBuilder.CreateCloneResult(concept, element, article, targets);

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

		public static IBookResult[] BuildPositionEmplTermResults (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, uint dayFromOrdinal, uint dayEndsOrdinal)
		{
			IBookResult result = BookResultBuilder.CreatePositionEmplTermResult(concept, element, article, targets, dayFromOrdinal, dayEndsOrdinal);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildScheduleWorkResults (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, Int32[] timeTable)
		{
			IBookResult result = BookResultBuilder.CreateScheduleWorkResult(concept, element, article, targets, timeTable);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildTimesheetScheduleResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, Int32[] timeTable)
		{
			IBookResult result = BookResultBuilder.CreateTimesheetScheduleResult(concept, element, article, targets, timeTable);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildTimesheetWorkingResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, Int32[] timeTable)
		{
			IBookResult result = BookResultBuilder.CreateWorkTimetableResult(concept, element, article, targets, timeTable);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildTimesheetAbsenceResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, Int32[] timeTable)
		{
			IBookResult result = BookResultBuilder.CreateAbsenceTimetableResult(concept, element, article, targets, timeTable);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildTimehoursWorkingResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, Int32 timeValue)
		{
			IBookResult result = BookResultBuilder.CreateWorktimeCountResult(concept, element, article, targets, timeValue);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildTimehoursAbsenceResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, Int32 timeValue)
		{
			IBookResult result = BookResultBuilder.CreateAbsenceCountResult(concept, element, article, targets, timeValue);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildSalaryBaseResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, decimal factorValue, decimal amountValue, Int32 recordWorking)
		{
			IBookResult result = BookResultBuilder.CreateMonthlyAmountPaymentsResult(concept, element, article, targets, 
				factorValue, amountValue, recordWorking);

			IBookResult[] resultList = BuildListWithResult(result);

			return resultList;
		}

		public static IBookResult[] BuildIncomeGrossResult (IPayrollConcept concept, IBookIndex element, IPayrollArticle article, 
			ITargetValues targets, decimal incomeValue)
		{
			IBookResult result = BookResultBuilder.CreateRecordIncomeResult(concept, element, article, targets, 
				incomeValue);

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

