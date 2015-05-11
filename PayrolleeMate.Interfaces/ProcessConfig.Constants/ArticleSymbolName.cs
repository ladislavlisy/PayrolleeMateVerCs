using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public class ArticleSymbolName
	{
		public static readonly SymbolName REF_UNKNOWN = ArticleCode.ARTICLE_UNKNOWN.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_EMPL_TERM = ArticleCode.ARTICLE_CONTRACT_EMPL_TERM.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_STAT_TERM = ArticleCode.ARTICLE_CONTRACT_STAT_TERM.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_WORK_TERM = ArticleCode.ARTICLE_CONTRACT_WORK_TERM.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_TASK_TERM = ArticleCode.ARTICLE_CONTRACT_TASK_TERM.GetSymbol();
		public static readonly SymbolName REF_POSITION_TERM = ArticleCode.ARTICLE_POSITION_TERM.GetSymbol();
		public static readonly SymbolName REF_SCHEDULE_WORK = ArticleCode.ARTICLE_SCHEDULE_WORK.GetSymbol();
		public static readonly SymbolName REF_SALARY_BASE = ArticleCode.ARTICLE_SALARY_BASE.GetSymbol();
		public static readonly SymbolName REF_TIMESHEET_SCHEDULE = ArticleCode.ARTICLE_TIMESHEET_SCHEDULE.GetSymbol();
		public static readonly SymbolName REF_TIMESHEET_WORKING = ArticleCode.ARTICLE_TIMESHEET_WORKING.GetSymbol();
		public static readonly SymbolName REF_TIMESHEET_ABSENCE = ArticleCode.ARTICLE_TIMESHEET_ABSENCE.GetSymbol();
		public static readonly SymbolName REF_TIMEHOURS_WORKING = ArticleCode.ARTICLE_TIMEHOURS_WORKING.GetSymbol();
		public static readonly SymbolName REF_TIMEHOURS_ABSENCE = ArticleCode.ARTICLE_TIMEHOURS_ABSENCE.GetSymbol();
		public static readonly SymbolName REF_HEALTH_INCOME_SUBJECT = ArticleCode.ARTICLE_HEALTH_INCOME_SUBJECT.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_INCOME_SUBJECT = ArticleCode.ARTICLE_SOCIAL_INCOME_SUBJECT.GetSymbol();
		public static readonly SymbolName REF_GARANT_INCOME_SUBJECT = ArticleCode.ARTICLE_GARANT_INCOME_SUBJECT.GetSymbol();
		public static readonly SymbolName REF_HEALTH_INCOME_PARTICIP = ArticleCode.ARTICLE_HEALTH_INCOME_PARTICIP.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_INCOME_PARTICIP = ArticleCode.ARTICLE_SOCIAL_INCOME_PARTICIP.GetSymbol();
		public static readonly SymbolName REF_GARANT_INCOME_PARTICIP = ArticleCode.ARTICLE_GARANT_INCOME_PARTICIP.GetSymbol();
		public static readonly SymbolName REF_HEALTH_BASIS_GENERAL = ArticleCode.ARTICLE_HEALTH_BASIS_GENERAL.GetSymbol();
		public static readonly SymbolName REF_HEALTH_BASIS_MANDATORY = ArticleCode.ARTICLE_HEALTH_BASIS_MANDATORY.GetSymbol();
		public static readonly SymbolName REF_HEALTH_BASIS_LEGALCAP = ArticleCode.ARTICLE_HEALTH_BASIS_LEGALCAP.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_BASIS_GENERAL = ArticleCode.ARTICLE_SOCIAL_BASIS_GENERAL.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_BASIS_PENSION = ArticleCode.ARTICLE_SOCIAL_BASIS_PENSION.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_BASIS_LEGALCAP = ArticleCode.ARTICLE_SOCIAL_BASIS_LEGALCAP.GetSymbol();
		public static readonly SymbolName REF_GARANT_BASIS_PENSION = ArticleCode.ARTICLE_GARANT_BASIS_PENSION.GetSymbol();
		public static readonly SymbolName REF_GARANT_BASIS_LEGALCAP = ArticleCode.ARTICLE_GARANT_BASIS_LEGALCAP.GetSymbol();
		public static readonly SymbolName REF_HEALTH_EMPLOYEE_GENERAL = ArticleCode.ARTICLE_HEALTH_EMPLOYEE_GENERAL.GetSymbol();
		public static readonly SymbolName REF_HEALTH_EMPLOYEE_MANDATORY = ArticleCode.ARTICLE_HEALTH_EMPLOYEE_MANDATORY.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_EMPLOYEE_GENERAL = ArticleCode.ARTICLE_SOCIAL_EMPLOYEE_GENERAL.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_EMPLOYEE_PENSION = ArticleCode.ARTICLE_SOCIAL_EMPLOYEE_PENSION.GetSymbol();
		public static readonly SymbolName REF_GARANT_EMPLOYEE_PENSION = ArticleCode.ARTICLE_GARANT_EMPLOYEE_PENSION.GetSymbol();
		public static readonly SymbolName REF_HEALTH_EMPLOYER_GEENRAL = ArticleCode.ARTICLE_HEALTH_EMPLOYER_GEENRAL.GetSymbol();
		public static readonly SymbolName REF_HEALTH_EMPLOYER_MANDATORY = ArticleCode.ARTICLE_HEALTH_EMPLOYER_MANDATORY.GetSymbol();
		public static readonly SymbolName REF_SOCIAL_EMPLOYER_GENERAL = ArticleCode.ARTICLE_SOCIAL_EMPLOYER_GENERAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_INCOME_SUBJECT = ArticleCode.ARTICLE_TAXING_INCOME_SUBJECT.GetSymbol();
		public static readonly SymbolName REF_TAXING_INCOME_HEALTH = ArticleCode.ARTICLE_TAXING_INCOME_HEALTH.GetSymbol();
		public static readonly SymbolName REF_TAXING_INCOME_SOCIAL = ArticleCode.ARTICLE_TAXING_INCOME_SOCIAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_INCOME = ArticleCode.ARTICLE_TAXING_ADVANCES_INCOME.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_HEALTH = ArticleCode.ARTICLE_TAXING_ADVANCES_HEALTH.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_SOCIAL = ArticleCode.ARTICLE_TAXING_ADVANCES_SOCIAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_BASIS_GENERAL = ArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_GENERAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_BASIS_SOLIDARY = ArticleCode.ARTICLE_TAXING_ADVANCES_BASIS_SOLIDARY.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_GENERAL = ArticleCode.ARTICLE_TAXING_ADVANCES_GENERAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_SOLIDARY = ArticleCode.ARTICLE_TAXING_ADVANCES_SOLIDARY.GetSymbol();
		public static readonly SymbolName REF_TAXING_ADVANCES_TOTAL = ArticleCode.ARTICLE_TAXING_ADVANCES_TOTAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_ALLOWANCE_PAYER = ArticleCode.ARTICLE_TAXING_ALLOWANCE_PAYER.GetSymbol();
		public static readonly SymbolName REF_TAXING_ALLOWANCE_CHILD = ArticleCode.ARTICLE_TAXING_ALLOWANCE_CHILD.GetSymbol();
		public static readonly SymbolName REF_TAXING_ALLOWANCE_DISABILITY = ArticleCode.ARTICLE_TAXING_ALLOWANCE_DISABILITY.GetSymbol();
		public static readonly SymbolName REF_TAXING_ALLOWNACE_STUDYING = ArticleCode.ARTICLE_TAXING_ALLOWNACE_STUDYING.GetSymbol();
		public static readonly SymbolName REF_TAXING_REBATE_PAYER = ArticleCode.ARTICLE_TAXING_REBATE_PAYER.GetSymbol();
		public static readonly SymbolName REF_TAXING_REBATE_CHILD = ArticleCode.ARTICLE_TAXING_REBATE_CHILD.GetSymbol();
		public static readonly SymbolName REF_TAXING_BONUS_CHILD = ArticleCode.ARTICLE_TAXING_BONUS_CHILD.GetSymbol();
		public static readonly SymbolName REF_TAXING_WITHHOLD_INCOME = ArticleCode.ARTICLE_TAXING_WITHHOLD_INCOME.GetSymbol();
		public static readonly SymbolName REF_TAXING_WITHHOLD_HEALTH = ArticleCode.ARTICLE_TAXING_WITHHOLD_HEALTH.GetSymbol();
		public static readonly SymbolName REF_TAXING_WITHHOLD_SOCIAL = ArticleCode.ARTICLE_TAXING_WITHHOLD_SOCIAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_WITHHOLD_BASIS_GENERAL = ArticleCode.ARTICLE_TAXING_WITHHOLD_BASIS_GENERAL.GetSymbol();
		public static readonly SymbolName REF_TAXING_WITHHOLD_GENERAL = ArticleCode.ARTICLE_TAXING_WITHHOLD_GENERAL.GetSymbol();
		public static readonly SymbolName REF_INCOME_GROSS = ArticleCode.ARTICLE_INCOME_GROSS.GetSymbol();
		public static readonly SymbolName REF_INCOME_NETTO = ArticleCode.ARTICLE_INCOME_NETTO.GetSymbol();	
	}
}

