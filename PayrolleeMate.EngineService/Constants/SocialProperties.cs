using System;

namespace PayrolleeMate.EngineService.Constants
{
	class SocialProperties2011
	{
		public const Int32 BASIS_MANDATORY = 0;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1781280m;

		public const decimal FACTOR_EMPLOYER = 25.0m;

		public const decimal FACTOR_EMPLOYER_ELEVATED = 26.0m;

		public const decimal FACTOR_EMPLOYEE = 6.5m;

		public const decimal FACTOR_EMPLOYEE_PENSION = 0.0m;

		public const decimal FACTOR_REDUCE_PENSION = 0.0m;
	}

	class SocialProperties2012
	{
		public const Int32 BASIS_MANDATORY = SocialProperties2011.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1206576m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2011.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = SocialProperties2011.FACTOR_EMPLOYER_ELEVATED;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2011.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_PENSION = SocialProperties2011.FACTOR_EMPLOYEE_PENSION;

		public const decimal FACTOR_REDUCE_PENSION = SocialProperties2011.FACTOR_REDUCE_PENSION;
	}

	class SocialProperties2013
	{
		public const Int32 BASIS_MANDATORY = SocialProperties2012.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1242432m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2012.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = SocialProperties2012.FACTOR_EMPLOYER_ELEVATED;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2012.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_PENSION = 5.0m;

		public const decimal FACTOR_REDUCE_PENSION = 3.0m;
	}

	class SocialProperties2014
	{
		public const Int32 BASIS_MANDATORY = SocialProperties2013.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1245216m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2013.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = SocialProperties2013.FACTOR_EMPLOYER_ELEVATED;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2013.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_PENSION = SocialProperties2013.FACTOR_EMPLOYEE_PENSION;

		public const decimal FACTOR_REDUCE_PENSION = SocialProperties2013.FACTOR_REDUCE_PENSION;
	}

	class SocialProperties2015
	{
		public const Int32 BASIS_MANDATORY = SocialProperties2014.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1277328m;

		public const decimal FACTOR_EMPLOYER = SocialProperties2014.FACTOR_EMPLOYER;

		public const decimal FACTOR_EMPLOYER_ELEVATED = 25.0m;

		public const decimal FACTOR_EMPLOYEE = SocialProperties2014.FACTOR_EMPLOYEE;

		public const decimal FACTOR_EMPLOYEE_PENSION = SocialProperties2014.FACTOR_EMPLOYEE_PENSION;

		public const decimal FACTOR_REDUCE_PENSION = SocialProperties2014.FACTOR_REDUCE_PENSION;
	}

}

