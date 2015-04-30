using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public class HealthGuides : EngineGeneralGuides, IHealthGuides
	{
		private readonly decimal __basicAnnualMaximum;
		private readonly Int32 __basisMandatory;
		private readonly decimal __factorCompound;
		private readonly decimal __factorEmployee;
		private readonly decimal __factorEmployer;

		public static HealthGuides Guides2015()
		{
			return new HealthGuides (HealthProperties2015.YEAR_2015,
				HealthProperties2015.BASIS_ANNUAL_MAXIMUM,
				HealthProperties2015.BASIS_MANDATORY,
				HealthProperties2015.FACTOR_COMPOUND,
				HealthProperties2015.FACTOR_EMPLOYEE,
				HealthProperties2015.FACTOR_EMPLOYER);
		}

		public static HealthGuides Guides2014()
		{
			return new HealthGuides (HealthProperties2014.YEAR_2014,
				HealthProperties2014.BASIS_ANNUAL_MAXIMUM,
				HealthProperties2014.BASIS_MANDATORY,
				HealthProperties2014.FACTOR_COMPOUND,
				HealthProperties2014.FACTOR_EMPLOYEE,
				HealthProperties2014.FACTOR_EMPLOYER);
		}

		public static HealthGuides Guides2013()
		{
			return new HealthGuides (HealthProperties2013.YEAR_2013,
				HealthProperties2013.BASIS_ANNUAL_MAXIMUM,
				HealthProperties2013.BASIS_MANDATORY,
				HealthProperties2013.FACTOR_COMPOUND,
				HealthProperties2013.FACTOR_EMPLOYEE,
				HealthProperties2013.FACTOR_EMPLOYER);
		}

		public static HealthGuides Guides2012()
		{
			return new HealthGuides (HealthProperties2012.YEAR_2012,
				HealthProperties2012.BASIS_ANNUAL_MAXIMUM,
				HealthProperties2012.BASIS_MANDATORY,
				HealthProperties2012.FACTOR_COMPOUND,
				HealthProperties2012.FACTOR_EMPLOYEE,
				HealthProperties2012.FACTOR_EMPLOYER);
		}

		public static HealthGuides Guides2011()
		{
			return new HealthGuides (HealthProperties2011.YEAR_2011,
				HealthProperties2011.BASIS_ANNUAL_MAXIMUM,
				HealthProperties2011.BASIS_MANDATORY,
				HealthProperties2011.FACTOR_COMPOUND,
				HealthProperties2011.FACTOR_EMPLOYEE,
				HealthProperties2011.FACTOR_EMPLOYER);
		}

		private HealthGuides(
			uint validYear,
			decimal basicAnnual,
			Int32   basisMandatory,
			decimal factorCompound,
			decimal factorEmployee, 
			decimal factorEmployer) : base(validYear)
		{
			__basicAnnualMaximum = basicAnnual;
			__basisMandatory = basisMandatory;
			__factorCompound = factorCompound;
			__factorEmployee = factorEmployee;
			__factorEmployer = factorEmployer;
		}

		public Int32 MandatoryBasis () 
		{
			return __basisMandatory;
		}

		public decimal MaximumAnnualBasis () 
		{
			return __basicAnnualMaximum;
		}

		public decimal EmployerFactor () 
		{
			return __factorEmployer;
		}

		public decimal EmployeeFactor () 
		{
			return __factorEmployee;
		}

		public decimal CompoundFactor () 
		{
			return __factorCompound;
		}

		public virtual object Clone()
		{
			HealthGuides other = (HealthGuides)this.MemberwiseClone();
			return other;
		}
	}
}

