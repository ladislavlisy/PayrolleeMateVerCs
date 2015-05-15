﻿using System;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfigSetCz.Constants
{
	public enum ConfigSetCzConceptCode : uint
	{
		CONCEPT_UNKNOWN = ConceptSymbolCode.CONCEPT_UNKNOWN,
		CONCEPT_CONTRACT_EMPL_TERM = ConceptSymbolCode.CONCEPT_CONTRACT_EMPL_TERM,
		CONCEPT_POSITION_EMPL_TERM = ConceptSymbolCode.CONCEPT_POSITION_EMPL_TERM,
		CONCEPT_INCOME_GROSS = ConceptSymbolCode.CONCEPT_INCOME_GROSS,
		CONCEPT_INCOME_NETTO = ConceptSymbolCode.CONCEPT_INCOME_NETTO,

		CONCEPT_CONTRACT_STAT_TERM = 10102,
		CONCEPT_CONTRACT_WORK_TERM = 10103,
		CONCEPT_CONTRACT_TASK_TERM = 10104,

		CONCEPT_SCHEDULE_WORK = 10201,
		CONCEPT_SALARY_BASE = 10202,

		CONCEPT_TIMESHEET_SCHEDULE = 10251,
		CONCEPT_TIMESHEET_WORKING = 10252,
		CONCEPT_TIMESHEET_ABSENCE = 10253,
		CONCEPT_TIMEHOURS_WORKING = 10254,
		CONCEPT_TIMEHOURS_ABSENCE = 10255,

		CONCEPT_HEALTH_INCOME_SUBJECT = 10301,
		CONCEPT_SOCIAL_INCOME_SUBJECT = 10302,
		CONCEPT_GARANT_INCOME_SUBJECT = 10303,

		CONCEPT_HEALTH_INCOME_PARTICIP = 10305,
		CONCEPT_SOCIAL_INCOME_PARTICIP = 10306,
		CONCEPT_GARANT_INCOME_PARTICIP = 10307,

		CONCEPT_HEALTH_BASIS_GENERAL = 10311,
		CONCEPT_HEALTH_BASIS_MANDATORY = 10312,
		CONCEPT_HEALTH_BASIS_LEGALCAP = 10313,
		CONCEPT_SOCIAL_BASIS_GENERAL = 10321,
		CONCEPT_SOCIAL_BASIS_PENSION = 10322,
		CONCEPT_SOCIAL_BASIS_LEGALCAP = 10323,
		CONCEPT_GARANT_BASIS_PENSION = 10331,
		CONCEPT_GARANT_BASIS_LEGALCAP = 10332,

		CONCEPT_HEALTH_EMPLOYEE_GENERAL = 10341,
		CONCEPT_HEALTH_EMPLOYEE_MANDATORY = 10342,
		CONCEPT_SOCIAL_EMPLOYEE_GENERAL = 10351,
		CONCEPT_SOCIAL_EMPLOYEE_PENSION = 10352,
		CONCEPT_GARANT_EMPLOYEE_PENSION = 10361,

		CONCEPT_HEALTH_EMPLOYER_GEENRAL = 10371,
		CONCEPT_HEALTH_EMPLOYER_MANDATORY = 10372,
		CONCEPT_SOCIAL_EMPLOYER_GENERAL = 10373,

		CONCEPT_TAXING_INCOME_SUBJECT = 10401,
		CONCEPT_TAXING_INCOME_HEALTH = 10402,
		CONCEPT_TAXING_INCOME_SOCIAL = 10403,
		CONCEPT_TAXING_ADVANCES_INCOME = 10411,
		CONCEPT_TAXING_ADVANCES_HEALTH = 10412,
		CONCEPT_TAXING_ADVANCES_SOCIAL = 10413,
		CONCEPT_TAXING_ADVANCES_BASIS_GENERAL = 10414,
		CONCEPT_TAXING_ADVANCES_BASIS_SOLIDARY = 10415,
		CONCEPT_TAXING_ADVANCES_GENERAL = 10416,
		CONCEPT_TAXING_ADVANCES_SOLIDARY = 10417,
		CONCEPT_TAXING_ADVANCES_TOTAL = 10418,

		CONCEPT_TAXING_ALLOWANCE_PAYER = 10421,
		CONCEPT_TAXING_ALLOWANCE_CHILD = 10422,
		CONCEPT_TAXING_ALLOWANCE_DISABILITY = 10423,
		CONCEPT_TAXING_ALLOWANCE_STUDYING = 10424,
		CONCEPT_TAXING_REBATE_PAYER = 10431,
		CONCEPT_TAXING_REBATE_CHILD = 10432,
		CONCEPT_TAXING_BONUS_CHILD = 10433,

		CONCEPT_TAXING_WITHHOLD_INCOME = 10451,
		CONCEPT_TAXING_WITHHOLD_HEALTH = 10452,
		CONCEPT_TAXING_WITHHOLD_SOCIAL = 10453,
		CONCEPT_TAXING_WITHHOLD_BASIS_GENERAL = 10454,
		CONCEPT_TAXING_WITHHOLD_GENERAL = 10456

	}

	public static class ConfigSetCzConceptCodeExtensions
	{
		public static SymbolName GetSymbol(this ConfigSetCzConceptCode concept)
		{
			return new SymbolName((uint)concept, concept.ToString());
		}

		public static uint Code(this ConfigSetCzConceptCode concept)
		{
			return (uint)concept;
		}
	}
}

