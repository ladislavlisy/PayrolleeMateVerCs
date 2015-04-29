using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operation;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public class HealthEnginePrototype : IHealthEngine, IHealthGuides
	{
		public HealthEnginePrototype  (HealthGuides currentGuides)
		{
			__guides = currentGuides.Clone() as HealthGuides;
		}

		private IHealthGuides __guides;

		#region IHealthEngine implementation

		// EmployeeContribution
		public long EmployeeContribution(MonthPeriod period, decimal generalBasis, decimal employeeBasis)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period);

			decimal employerFactor = PeriodEmployerFactor (period);

			long resultPaymentValue = EmployeeContributionWithFactor(generalBasis, employeeBasis, employeeFactor, employerFactor);

			return resultPaymentValue;
		}

		// EmployerContribution
		public long EmployerContribution(MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period);

			decimal employerFactor = PeriodEmployerFactor (period);

			long resultPaymentValue = EmployerContributionWithFactor(generalBasis, employeeBasis, employerBasis, employeeFactor, employerFactor);

			return resultPaymentValue;
		}

		// CompoundContribution
		public long CompoundContribution(MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period);

			decimal employerFactor = PeriodEmployerFactor (period);

			decimal compoundBasis = CompoundBasis(generalBasis, employeeBasis, employerBasis);

			long resultPaymentValue = CompoundContributionWithFactor(compoundBasis, employeeFactor, employerFactor);

			return resultPaymentValue;
		}

		// CalculatedBasis
		public decimal CalculatedBasis(MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase)
		{
			decimal minSocialLimit = PeriodMandatoryBasis (period, isMinBaseRequired);

			decimal maxSocialLimit = PeriodMaximumAnnualBasis (period);

			decimal calculatedBase = Math.Max (0m, employeeIncome);

			if (isNegativeIncluded && employeeIncome < 0m) 
			{
				calculatedBase = employeeIncome;
			}

			decimal roundedBase = HealthOperations.DecRoundUp(calculatedBase);

			decimal assesmentBase = HealthOperations.MinMaxValue(roundedBase, accumulatedBase, minSocialLimit, maxSocialLimit);

			return assesmentBase;
		}

		// EmployeeMandatoryBasis
		public decimal EmployeeMandatoryBasis(MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase)
		{
			decimal minSocialLimit = PeriodMandatoryBasis (period, isMinBaseRequired);

			decimal maxSocialLimit = PeriodMaximumAnnualBasis (period);

			decimal calculatedBase = Math.Max (0m, employeeIncome);

			if (isNegativeIncluded && employeeIncome < 0m) 
			{
				calculatedBase = employeeIncome;
			}

			decimal roundedBase = HealthOperations.DecRoundUp(calculatedBase);

			decimal resultsBase = HealthOperations.MinMaxValue(roundedBase, accumulatedBase, minSocialLimit, maxSocialLimit);

			return Math.Max(0, decimal.Subtract(resultsBase, roundedBase));
		}

		public IHealthGuides Guides ()
		{
			return __guides;
		}

		#endregion

		#region IHealthGuides implementation

		public int MandatoryBasis ()
		{
			return __guides.MandatoryBasis();
		}
		public decimal MaximumAnnualBasis ()
		{
			return __guides.MaximumAnnualBasis();
		}
		public decimal EmployerFactor ()
		{
			return __guides.EmployerFactor();
		}
		public decimal EmployeeFactor ()
		{
			return __guides.EmployeeFactor();
		}
		public decimal CompoundFactor ()
		{
			return __guides.CompoundFactor();
		}

		#endregion

		private long EmployeeContributionWithFactor (decimal generalBasis, decimal employeeBasis, decimal employeeFactor, decimal employerFactor)
		{
			decimal compoundFactor = decimal.Add (employeeFactor, employerFactor);

			decimal decimalResult1 = DecOperation.Multiply (employeeBasis, compoundFactor);

			decimal decimalResult2 = DecOperation.MultiplyAndDivide(generalBasis, compoundFactor, 3);

			long resultPaymentValue = HealthOperations.IntRoundUp (decimal.Add (decimalResult1, decimalResult2));

			return resultPaymentValue;
		}

		private long EmployerContributionWithFactor (decimal generalBasis, decimal employeeBasis, decimal employerBasis, decimal employeeFactor, decimal employerFactor)
		{
			decimal compoundBasis = CompoundBasis(generalBasis, employeeBasis, employerBasis);

			long compoundPaymentValue = CompoundContributionWithFactor(compoundBasis, employeeFactor, employerFactor);

			long employeePaymentValue = EmployeeContributionWithFactor(generalBasis, employeeBasis, employeeFactor, employerFactor);

			long resultPaymentValue = (compoundPaymentValue - employeePaymentValue);

			return resultPaymentValue;
		}

		private long CompoundContributionWithFactor (decimal compoundBasis, decimal employeeFactor, decimal employerFactor)
		{
			decimal compoundFactor = decimal.Add (employeeFactor, employerFactor);

			decimal compoundResult = DecOperation.Multiply (compoundBasis, compoundFactor);

			long resultPaymentValue = HealthOperations.IntRoundUp (compoundResult);

			return resultPaymentValue;
		}

		public decimal CompoundBasis(decimal generalBasis, decimal employeeBasis, decimal employerBasis)
		{
			decimal separateBasis = decimal.Add (employeeBasis, employerBasis);

			decimal compoundBasis = decimal.Add (generalBasis, separateBasis);

			return compoundBasis;
		}

		public int PeriodMandatoryBasis (MonthPeriod period, bool isMinBaseRequired)
		{
			if (isMinBaseRequired) 
			{
				return __guides.MandatoryBasis ();
			}
			return 0;
		}

		public decimal PeriodMaximumAnnualBasis (MonthPeriod period)
		{
			return __guides.MaximumAnnualBasis();
		}

		public decimal PeriodEmployerFactor (MonthPeriod period)
		{
			return __guides.EmployerFactor();
		}

		public decimal PeriodEmployeeFactor (MonthPeriod period)
		{
			return __guides.EmployeeFactor();
		}

		public decimal PeriodCompoundFactor (MonthPeriod period)
		{
			return __guides.CompoundFactor();
		}
	}
}

