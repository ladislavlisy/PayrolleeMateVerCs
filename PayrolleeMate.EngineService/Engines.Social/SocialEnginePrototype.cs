using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operation;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public class SocialEnginePrototype : ISocialEngine, ISocialGuides
	{
		public const bool PENSION_SCHEME_YES = true;

		public const bool PENSION_SCHEME_NON = false;

		public SocialEnginePrototype  (SocialGuides currentGuides)
		{
			__guides = currentGuides.Clone() as SocialGuides;
		}

		private ISocialGuides __guides;

		#region ISocialEngine implementation

		// EmployeeRegularContribution
		public decimal EmployeeRegularContribution(MonthPeriod period, decimal employeeBase)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period, PENSION_SCHEME_NON);

			long resultPaymentValue = EmployeeContributionWithFactor (employeeBase, employeeFactor);

			return resultPaymentValue;
		}

		// EmployeePensionContribution
		public decimal EmployeePensionContribution(MonthPeriod period, decimal employeeBase)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period, PENSION_SCHEME_YES);

			long resultPaymentValue = EmployeeContributionWithFactor (employeeBase, employeeFactor);

			return resultPaymentValue;
		}

		// EmployerContribution
		public decimal EmployerContribution(MonthPeriod period, decimal employerBase)
		{
			decimal employerFactor = PeriodEmployerFactor (period);

			long resultPaymentValue = EmployerContributionWithFactor (employerBase, employerFactor);

			return resultPaymentValue;
		}

		// RegularCalculatedBasis
		public decimal RegularCalculatedBasis(MonthPeriod period, bool isNegativeIncluded, bool isPension2sScheme, decimal employeeIncome, decimal accumulatedBase)
		{
			decimal assesmentBase = 0m;

			if (isPension2sScheme == PENSION_SCHEME_NON) 
			{
				assesmentBase = CalculatedBasis(period, isNegativeIncluded, employeeIncome, accumulatedBase);
			}

			return assesmentBase;
		}

		// PensionCalculatedBasis
		public decimal PensionCalculatedBasis(MonthPeriod period, bool isNegativeIncluded, bool isPension2sScheme, decimal employeeIncome, decimal accumulatedBase)
		{
			decimal assesmentBase = 0m;

			if (isPension2sScheme == PENSION_SCHEME_YES) 
			{
				assesmentBase = CalculatedBasis(period, isNegativeIncluded, employeeIncome, accumulatedBase);
			}

			return assesmentBase;
		}

		// Pension2sSchemeContribution
		public decimal Pension2sSchemeContribution(MonthPeriod period, decimal employeeBase)
		{
			decimal employeeFactor = PeriodEmployeePensionsFactor (period, PENSION_SCHEME_YES);

			long resultPaymentValue = PensionContributionWithFactor (employeeBase, employeeFactor);

			return resultPaymentValue;
		}
			
		public ISocialGuides Guides ()
		{
			return __guides;
		}

		#endregion

		#region ISocialGuides implementation

		public int MandatoryBasis ()
		{
			return __guides.MandatoryBasis();
		}
		public decimal MaximumAnnualBasis ()
		{
			return __guides.MaximumAnnualBasis();
		}
		public decimal EmployeeFactor ()
		{
			return __guides.EmployeeFactor();
		}
		public decimal EmployeePensionsFactor ()
		{
			return __guides.EmployeePensionsFactor();
		}
		public decimal PensionsReduceFactor ()
		{
			return __guides.PensionsReduceFactor();
		}
		public decimal EmployerFactor ()
		{
			return __guides.EmployerFactor();
		}
		public decimal EmployerExemptionFactor ()
		{
			return __guides.EmployerExemptionFactor();
		}

		#endregion

		private long EmployeeContributionWithFactor(decimal employeeBase, decimal employeeFactor)
		{
			decimal decimalResult = DecOperation.Multiply (employeeBase, employeeFactor);

			long roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

		private long EmployerContributionWithFactor(decimal employerBase, decimal employerFactor)
		{
			decimal decimalResult = DecOperation.Multiply (employerBase, employerFactor);

			long roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

		private long PensionContributionWithFactor(decimal employeeBase, decimal employeeFactor)
		{
			decimal decimalResult = DecOperation.Multiply (employeeBase, employeeFactor);

			long roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

		private decimal CalculatedBasis(MonthPeriod period, bool isNegativeIncluded, decimal employeeIncome, decimal accumulatedBase)
		{
			decimal maxSocialLimit = PeriodMaximumAnnualBasis (period);

			decimal calculatedBase = Math.Max (0m, employeeIncome);

			if (isNegativeIncluded && employeeIncome < 0m) 
			{
				calculatedBase = employeeIncome;
			}

			decimal roundedBase = SocialOperations.DecRoundUp(calculatedBase);

			decimal assesmentBase = SocialOperations.MinMaxValue(roundedBase, accumulatedBase, maxSocialLimit);

			return assesmentBase;
		}

		private decimal PeriodEmployeeFactor(MonthPeriod period, bool isPension2sScheme)
		{
			decimal reduceFactor = decimal.Zero;
			if (isPension2sScheme) 
			{
				reduceFactor = __guides.PensionsReduceFactor();
			}
			return decimal.Subtract(__guides.EmployeeFactor(), reduceFactor);
		}

		private decimal PeriodEmployerFactor(MonthPeriod period)
		{
			return __guides.EmployerFactor();
		}

		private decimal PeriodEmployeePensionsFactor(MonthPeriod period, bool isPension2sScheme)
		{
			decimal pensionFactor = decimal.Zero;
			if (isPension2sScheme) 
			{
				pensionFactor = __guides.EmployeePensionsFactor();
			}
			return pensionFactor;
		}

		private decimal PeriodMaximumAnnualBasis(MonthPeriod period)
		{
			return __guides.MaximumAnnualBasis();
		}

	}
}

