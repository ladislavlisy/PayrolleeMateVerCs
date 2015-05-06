using System;

namespace PayrolleeMate.EngineService.Constants
{
	class HealthProperties2011
	{
		public const uint YEAR_2011 = 2011;

		public const Int32 BASIS_MANDATORY = 8000;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1781280m;

		public const decimal FACTOR_COMPOUND = 13.5m;

		public const decimal INCOME_EMPLOY_MARGINAL = 2000m;

		public const decimal INCOME_AGREEM_MARGINAL = 0m;
	}

	class HealthProperties2012
	{
		public const uint YEAR_2012 = 2012;

		public const Int32 BASIS_MANDATORY = HealthProperties2011.BASIS_MANDATORY;

		public const decimal BASIS_ANNUAL_MAXIMUM = 1809864m;

		public const decimal FACTOR_COMPOUND = HealthProperties2011.FACTOR_COMPOUND;

		public const decimal INCOME_EMPLOY_MARGINAL = 2500m;

		public const decimal INCOME_AGREEM_MARGINAL = 10000m;
	}

	class HealthProperties2013
	{
		public const uint YEAR_2013 = 2013;

		public const Int32 BASIS_MANDATORY_FROM_01_TO_07 = 8000;

		public const Int32 BASIS_MANDATORY = 8500;

		public const decimal BASIS_ANNUAL_MAXIMUM = 0m;

		public const decimal FACTOR_COMPOUND = HealthProperties2012.FACTOR_COMPOUND;

		public const decimal INCOME_EMPLOY_MARGINAL = HealthProperties2012.INCOME_EMPLOY_MARGINAL;

		public const decimal INCOME_AGREEM_MARGINAL = HealthProperties2012.INCOME_AGREEM_MARGINAL;
	}

	class HealthProperties2014
	{
		public const uint YEAR_2014 = 2014;

		public const Int32 BASIS_MANDATORY = 8500;

		public const decimal BASIS_ANNUAL_MAXIMUM = HealthProperties2013.BASIS_ANNUAL_MAXIMUM;

		public const decimal FACTOR_COMPOUND = HealthProperties2013.FACTOR_COMPOUND;

		public const decimal INCOME_EMPLOY_MARGINAL = HealthProperties2013.INCOME_EMPLOY_MARGINAL;

		public const decimal INCOME_AGREEM_MARGINAL = HealthProperties2013.INCOME_AGREEM_MARGINAL;
	}

	class HealthProperties2015
	{
		public const uint YEAR_2015 = 2015;

		public const Int32 BASIS_MANDATORY = 9200;

		public const decimal BASIS_ANNUAL_MAXIMUM = HealthProperties2014.BASIS_ANNUAL_MAXIMUM;

		public const decimal FACTOR_COMPOUND = HealthProperties2014.FACTOR_COMPOUND;

		public const decimal INCOME_EMPLOY_MARGINAL = HealthProperties2014.INCOME_EMPLOY_MARGINAL;

		public const decimal INCOME_AGREEM_MARGINAL = HealthProperties2014.INCOME_AGREEM_MARGINAL;
	}
}

