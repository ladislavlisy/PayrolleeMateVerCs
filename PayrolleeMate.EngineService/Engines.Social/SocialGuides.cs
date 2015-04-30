using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public class SocialGuides : EngineGeneralGuides, ISocialGuides
	{
		private readonly decimal __basicAnnualMaximum;
		private readonly Int32 __basisMandatory;
		private readonly decimal __factorEmployer;
		private readonly decimal __factorEmployerElevated;
		private readonly decimal __factorEmployee;
		private readonly decimal __factorEmployeePension;
		private readonly decimal __factorPensionReduce;

		public static SocialGuides Guides2015()
		{
			return new SocialGuides (SocialProperties2015.YEAR_2015,
				SocialProperties2015.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2015.BASIS_MANDATORY,
				SocialProperties2015.FACTOR_EMPLOYER,
				SocialProperties2015.FACTOR_EMPLOYER_ELEVATED,
				SocialProperties2015.FACTOR_EMPLOYEE,
				SocialProperties2015.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2015.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2014()
		{
			return new SocialGuides (SocialProperties2014.YEAR_2014,
				SocialProperties2014.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2014.BASIS_MANDATORY,
				SocialProperties2014.FACTOR_EMPLOYER,
				SocialProperties2014.FACTOR_EMPLOYER_ELEVATED,
				SocialProperties2014.FACTOR_EMPLOYEE,
				SocialProperties2014.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2014.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2013()
		{
			return new SocialGuides (SocialProperties2013.YEAR_2013,
				SocialProperties2013.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2013.BASIS_MANDATORY,
				SocialProperties2013.FACTOR_EMPLOYER,
				SocialProperties2013.FACTOR_EMPLOYER_ELEVATED,
				SocialProperties2013.FACTOR_EMPLOYEE,
				SocialProperties2013.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2013.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2012()
		{
			return new SocialGuides (SocialProperties2012.YEAR_2012,
				SocialProperties2012.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2012.BASIS_MANDATORY,
				SocialProperties2012.FACTOR_EMPLOYER,
				SocialProperties2012.FACTOR_EMPLOYER_ELEVATED,
				SocialProperties2012.FACTOR_EMPLOYEE,
				SocialProperties2012.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2012.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2011()
		{
			return new SocialGuides (SocialProperties2011.YEAR_2011,
				SocialProperties2011.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2011.BASIS_MANDATORY,
				SocialProperties2011.FACTOR_EMPLOYER,
				SocialProperties2011.FACTOR_EMPLOYER_ELEVATED,
				SocialProperties2011.FACTOR_EMPLOYEE,
				SocialProperties2011.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2011.FACTOR_REDUCE_PENSION);
		}

		private SocialGuides(
			uint validYear,
			decimal basicAnnual,
			Int32 basisMandatory,
			decimal factorEmployer,
			decimal factorElevated,
			decimal factorEmployee,
			decimal factorPension,
			decimal factorReduce) : base(validYear)
		{
			__basicAnnualMaximum = basicAnnual;
			__basisMandatory = basisMandatory;
			__factorEmployer = factorEmployer;
			__factorEmployerElevated = factorElevated;
			__factorEmployee = factorEmployee;
			__factorEmployeePension = factorPension;
			__factorPensionReduce = factorReduce;
		}

		public Int32 MandatoryBasis () 
		{
			return __basisMandatory;
		}

		public decimal MaximumAnnualBasis () 
		{
			return __basicAnnualMaximum;
		}

		public decimal EmployeeFactor () 
		{
			return __factorEmployee;
		}

		public decimal EmployeePensionsFactor () 
		{
			return __factorEmployeePension;
		}

		public decimal PensionsReduceFactor () 
		{
			return __factorPensionReduce;
		}

		public decimal EmployerFactor () 
		{
			return __factorEmployer;
		}

		public decimal EmployerElevatedFactor () 
		{
			return __factorEmployerElevated;
		}

		public virtual object Clone()
		{
			SocialGuides other = (SocialGuides)this.MemberwiseClone();
			return other;
		}
	}
}

