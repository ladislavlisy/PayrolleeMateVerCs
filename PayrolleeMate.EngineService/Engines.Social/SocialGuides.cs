using System;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public class SocialGuides : ISocialGuides
	{
		private readonly decimal __basicAnnualMaximum;
		private readonly Int32 __basisMandatory;
		private readonly decimal __factorEmployer;
		private readonly decimal __factorEmployerExemption;
		private readonly decimal __factorEmployee;
		private readonly decimal __factorEmployeePension;
		private readonly decimal __factorPensionReduce;

		public static SocialGuides Guides2015()
		{
			return new SocialGuides (
				SocialProperties2015.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2015.BASIS_MANDATORY,
				SocialProperties2015.FACTOR_EMPLOYER,
				SocialProperties2015.FACTOR_EMPLOYER_EXEMPTION,
				SocialProperties2015.FACTOR_EMPLOYEE,
				SocialProperties2015.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2015.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2014()
		{
			return new SocialGuides (
				SocialProperties2015.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2015.BASIS_MANDATORY,
				SocialProperties2015.FACTOR_EMPLOYER,
				SocialProperties2015.FACTOR_EMPLOYER_EXEMPTION,
				SocialProperties2015.FACTOR_EMPLOYEE,
				SocialProperties2015.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2015.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2013()
		{
			return new SocialGuides (
				SocialProperties2015.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2015.BASIS_MANDATORY,
				SocialProperties2015.FACTOR_EMPLOYER,
				SocialProperties2015.FACTOR_EMPLOYER_EXEMPTION,
				SocialProperties2015.FACTOR_EMPLOYEE,
				SocialProperties2015.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2015.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2012()
		{
			return new SocialGuides (
				SocialProperties2015.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2015.BASIS_MANDATORY,
				SocialProperties2015.FACTOR_EMPLOYER,
				SocialProperties2015.FACTOR_EMPLOYER_EXEMPTION,
				SocialProperties2015.FACTOR_EMPLOYEE,
				SocialProperties2015.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2015.FACTOR_REDUCE_PENSION);
		}

		public static SocialGuides Guides2011()
		{
			return new SocialGuides (
				SocialProperties2015.BASIS_ANNUAL_MAXIMUM,
				SocialProperties2015.BASIS_MANDATORY,
				SocialProperties2015.FACTOR_EMPLOYER,
				SocialProperties2015.FACTOR_EMPLOYER_EXEMPTION,
				SocialProperties2015.FACTOR_EMPLOYEE,
				SocialProperties2015.FACTOR_EMPLOYEE_PENSION,
				SocialProperties2015.FACTOR_REDUCE_PENSION);
		}

		private SocialGuides(
			decimal basicAnnual,
			Int32 basisMandatory,
			decimal factorEmployer,
			decimal factorExemption,
			decimal factorEmployee,
			decimal factorPension,
			decimal factorReduce)
		{
			__basicAnnualMaximum = basicAnnual;
			__basisMandatory = basisMandatory;
			__factorEmployer = factorEmployer;
			__factorEmployerExemption = factorExemption;
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

		public decimal EmployerExemptionFactor () 
		{
			return __factorEmployerExemption;
		}

		public virtual object Clone()
		{
			SocialGuides other = (SocialGuides)this.MemberwiseClone();
			return other;
		}
	}
}

