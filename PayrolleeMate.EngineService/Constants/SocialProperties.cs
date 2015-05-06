using System;

namespace PayrolleeMate.EngineService.Constants
{
	class SocialProperties2011
	{
		public const uint YEAR_2011 = 2011;

		public const Int32 BASIS_MANDATORY = 0;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1781280m;

		public const decimal FACTOR_EMPLOYER = 25.0m;

		public const decimal FACTOR_EMPLOYER_ELEVATED = 26.0m;

		public const decimal FACTOR_EMPLOYEE = 6.5m;

		public const decimal FACTOR_EMPLOYEE_GARANT = 0.0m;

		public const decimal FACTOR_REDUCE_GARANT = 0.0m;

		public const decimal INCOME_EMPLOY_MARGINAL = 2000m;

		public const decimal INCOME_AGREEM_MARGINAL = 0m;
	}

	class SocialProperties2012
	{
		public const uint YEAR_2012 = 2012;

		public const Int32 BASIS_MANDATORY = SocialProperties2011.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1206576m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2011.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = SocialProperties2011.FACTOR_EMPLOYER_ELEVATED;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2011.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_GARANT = SocialProperties2011.FACTOR_EMPLOYEE_GARANT;

		public const decimal FACTOR_REDUCE_GARANT = SocialProperties2011.FACTOR_REDUCE_GARANT;

		public const decimal INCOME_EMPLOY_MARGINAL = 2500m;

		public const decimal INCOME_AGREEM_MARGINAL = 10000m;
	}

	class SocialProperties2013
	{
		public const uint YEAR_2013 = 2013;

		public const Int32 BASIS_MANDATORY = SocialProperties2012.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1242432m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2012.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = SocialProperties2012.FACTOR_EMPLOYER_ELEVATED;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2012.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_GARANT = 5.0m;

		public const decimal FACTOR_REDUCE_GARANT = 3.0m;

		public const decimal INCOME_EMPLOY_MARGINAL = HealthProperties2012.INCOME_EMPLOY_MARGINAL;

		public const decimal INCOME_AGREEM_MARGINAL = HealthProperties2012.INCOME_AGREEM_MARGINAL;
	}

	class SocialProperties2014
	{
		public const uint YEAR_2014 = 2014;

		public const Int32 BASIS_MANDATORY = SocialProperties2013.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1245216m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2013.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = SocialProperties2013.FACTOR_EMPLOYER_ELEVATED;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2013.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_GARANT = SocialProperties2013.FACTOR_EMPLOYEE_GARANT;

		public const decimal FACTOR_REDUCE_GARANT = SocialProperties2013.FACTOR_REDUCE_GARANT;

		public const decimal INCOME_EMPLOY_MARGINAL = HealthProperties2013.INCOME_EMPLOY_MARGINAL;

		public const decimal INCOME_AGREEM_MARGINAL = HealthProperties2013.INCOME_AGREEM_MARGINAL;
	}

	class SocialProperties2015
	{
		public const uint YEAR_2015 = 2015;

		public const Int32 BASIS_MANDATORY = SocialProperties2014.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1277328m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2014.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = 25.0m;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2014.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_GARANT = SocialProperties2014.FACTOR_EMPLOYEE_GARANT;

		public const decimal FACTOR_REDUCE_GARANT = SocialProperties2014.FACTOR_REDUCE_GARANT;

		public const decimal INCOME_EMPLOY_MARGINAL = HealthProperties2014.INCOME_EMPLOY_MARGINAL;

		public const decimal INCOME_AGREEM_MARGINAL = HealthProperties2014.INCOME_AGREEM_MARGINAL;
	}

}

