using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public class SocialEnginePrototype : ISocialEngine
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

			Int32 resultPaymentValue = EmployeeContributionWithFactor (employeeBase, employeeFactor);

			return resultPaymentValue;
		}

		// EmployeePensionContribution
		public decimal EmployeePensionContribution(MonthPeriod period, decimal employeeBase)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period, PENSION_SCHEME_YES);

			Int32 resultPaymentValue = EmployeeContributionWithFactor (employeeBase, employeeFactor);

			return resultPaymentValue;
		}

		// EmployerContribution
		public decimal EmployerContribution(MonthPeriod period, decimal employerBase)
		{
			decimal employerFactor = PeriodEmployerFactor (period);

			Int32 resultPaymentValue = EmployerContributionWithFactor (employerBase, employerFactor);

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

			Int32 resultPaymentValue = PensionContributionWithFactor (employeeBase, employeeFactor);

			return resultPaymentValue;
		}
			
		public ISocialGuides Guides ()
		{
			return __guides;
		}

		#endregion

		#region IPeriodSocialGuides implementation

		public Int32 PeriodMandatoryBasis (MonthPeriod period)
		{
			return __guides.MandatoryBasis();
		}

		public decimal PeriodMaximumAnnualBasis(MonthPeriod period)
		{
			return __guides.MaximumAnnualBasis();
		}

		public decimal PeriodEmployeeFactor(MonthPeriod period, bool isPension2sScheme)
		{
			decimal reduceFactor = decimal.Zero;
			if (isPension2sScheme) 
			{
				reduceFactor = PeriodPensionsReduceFactor (period);
			}
			decimal employeeFactor = PeriodEmployeeFactor (period);

			return decimal.Subtract(employeeFactor, reduceFactor);
		}

		public decimal PeriodEmployeeFactor (MonthPeriod period)
		{
			return __guides.EmployeeFactor();
		}

		public decimal PeriodEmployeePensionsFactor(MonthPeriod period, bool isPension2sScheme)
		{
			decimal pensionFactor = decimal.Zero;
			if (isPension2sScheme) 
			{
				pensionFactor = PeriodEmployeePensionsFactor (period);
			}
			return pensionFactor;
		}

		public decimal PeriodEmployeePensionsFactor (MonthPeriod period)
		{
			return __guides.EmployeePensionsFactor();
		}

		public decimal PeriodPensionsReduceFactor (MonthPeriod period)
		{
			return __guides.PensionsReduceFactor();
		}

		public decimal PeriodEmployerFactor (MonthPeriod period)
		{
			return __guides.EmployerFactor();
		}

		public decimal PeriodEmployerElevatedFactor (MonthPeriod period)
		{
			return __guides.EmployerElevatedFactor();
		}

		#endregion

		private Int32 EmployeeContributionWithFactor(decimal employeeBase, decimal employeeFactor)
		{
			decimal decimalResult = DecOperations.Multiply (employeeBase, employeeFactor);

			Int32 roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

		private Int32 EmployerContributionWithFactor(decimal employerBase, decimal employerFactor)
		{
			decimal decimalResult = DecOperations.Multiply (employerBase, employerFactor);

			Int32 roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

		private Int32 PensionContributionWithFactor(decimal employeeBase, decimal employeeFactor)
		{
			decimal decimalResult = DecOperations.Multiply (employeeBase, employeeFactor);

			Int32 roundedResult = SocialOperations.IntRoundUp(decimalResult);

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

	}
}

