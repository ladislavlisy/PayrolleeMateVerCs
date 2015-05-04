using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public class HealthEnginePrototype : IHealthEngine
	{
		public HealthEnginePrototype  (HealthGuides currentGuides)
		{
			__guides = currentGuides.Clone() as HealthGuides;
		}

		private IHealthGuides __guides;

		#region IHealthEngine implementation

		public decimal SubjectHealthSelector (MonthPeriod period, bool insSubject, bool insArticle, decimal valResult)
		{
			if (insSubject && insArticle) 
			{
				return valResult;
			}
			return 0m;
		}

		public decimal ParticipHealthSelector (MonthPeriod period, bool insParticip, decimal valResult)
		{
			if (insParticip) 
			{
				return valResult;
			}
			return 0m;
		}

		public decimal BasisGeneralAdapted (MonthPeriod period, bool negSuppress, decimal valResult)
		{
			decimal adaptedResult = HealthOperations.DecSuppressNegative (negSuppress, valResult);

			return adaptedResult;
		}

		public decimal BasisMandatoryBalance (MonthPeriod period, bool dutyMandatory, decimal valResult)
		{
			decimal minHealthLimit = PeriodMandatoryBasis (period, dutyMandatory);

			decimal calculatedBase = Math.Max (0m, valResult);

			decimal balancedResult = HealthOperations.MinValueAlign(calculatedBase, minHealthLimit);

			decimal mandatoryBasis = Math.Max(0, decimal.Subtract(balancedResult, calculatedBase));

			return mandatoryBasis;
		}

		public decimal BasisLegalCapBalance (MonthPeriod period, decimal accumulBasis, decimal actualBasis)
		{
			decimal maxHealthLimit = PeriodMaximumAnnualBasis (period);

			decimal calculatedBase = Math.Max (0m, actualBasis);

			decimal balancedResult = HealthOperations.MaxValueAlign(calculatedBase, accumulBasis, maxHealthLimit);

			decimal legalCapsBasis = Math.Max(0, decimal.Subtract(calculatedBase, balancedResult));

			return legalCapsBasis;
		}

		public decimal EmployeeGeneralContribution (MonthPeriod period, bool negSuppress, decimal generalBasis)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			decimal calculatedBase = HealthOperations.DecSuppressNegative (negSuppress, generalBasis);

			decimal mandatoryNones = 0m;

			Int32 resultGeneralValue = EmployeeContributionWithFactor(calculatedBase, mandatoryNones, compoundFactor);

			return resultGeneralValue;
		}

		public decimal EmployeeMandatoryContribution (MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryBasis)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			decimal calculatedBase = HealthOperations.DecSuppressNegative (negSuppress, generalBasis);

			decimal mandatoryNones = 0m;

			Int32 resultGeneralValue = EmployeeContributionWithFactor(calculatedBase, mandatoryNones, compoundFactor);

			Int32 resultCompletValue = EmployeeContributionWithFactor(calculatedBase, mandatoryBasis, compoundFactor);

			return (resultCompletValue - resultGeneralValue);
		}

		// EmployeeContribution

		// EmployerContribution
		public Int32 EmployerContribution(MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			Int32 resultPaymentValue = EmployerContributionWithFactor(generalBasis, employeeBasis, employerBasis, compoundFactor);

			return resultPaymentValue;
		}

		// CompoundContribution
		public Int32 CompoundContribution(MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			decimal compoundBasis = CompoundBasis(generalBasis, employeeBasis, employerBasis);

			Int32 resultPaymentValue = CompoundContributionWithFactor(compoundBasis, compoundFactor);

			return resultPaymentValue;
		}

		// CalculatedBasis
		public decimal CalculatedBasis(MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase)
		{
			decimal minHealthLimit = PeriodMandatoryBasis (period, isMinBaseRequired);

			decimal maxHealthLimit = PeriodMaximumAnnualBasis (period);

			decimal calculatedBase = Math.Max (0m, employeeIncome);

			if (isNegativeIncluded && employeeIncome < 0m) 
			{
				calculatedBase = employeeIncome;
			}

			decimal roundedBase = HealthOperations.DecRoundUp(calculatedBase);

			decimal assesmentBase = HealthOperations.MinMaxValue(roundedBase, accumulatedBase, minHealthLimit, maxHealthLimit);

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

		#region IPeriodHealthGuides implementation

		public virtual Int32 PeriodMandatoryBasis (MonthPeriod period, bool isMinBaseRequired)
		{
			if (isMinBaseRequired) 
			{
				return PeriodMandatoryBasis (period);
			}
			return 0;
		}

		public virtual Int32 PeriodMandatoryBasis (MonthPeriod period)
		{
			return __guides.MandatoryBasis();
		}

		public virtual decimal PeriodMaximumAnnualBasis (MonthPeriod period)
		{
			return __guides.MaximumAnnualBasis();
		}

		public virtual decimal PeriodCompoundFactor (MonthPeriod period)
		{
			return __guides.CompoundFactor();
		}

		#endregion

		private Int32 EmployeeContributionWithFactor (decimal generalBasis, decimal oneselfBasis, decimal compoundFactor)
		{
			decimal decimalResult1 = HealthOperations.DecFactorResult (oneselfBasis, compoundFactor);

			decimal decimalResult2 = HealthOperations.DecFactorResult (generalBasis, compoundFactor);

			decimal decimalResult3 = DecOperations.Divide(decimalResult2, 3);

			Int32 resultPaymentValue = HealthOperations.IntRoundUp (decimal.Add (decimalResult1, decimalResult3));

			return resultPaymentValue;
		}

		private Int32 EmployerContributionWithFactor (decimal generalBasis, decimal oneselfEmpee, decimal oneselfEmper, decimal compoundFactor)
		{
			decimal compoundBasis = CompoundBasis(generalBasis, oneselfEmpee, oneselfEmper);

			Int32 compoundPaymentValue = CompoundContributionWithFactor(compoundBasis, compoundFactor);

			Int32 employeePaymentValue = EmployeeContributionWithFactor(generalBasis, oneselfEmpee, compoundFactor);

			Int32 resultPaymentValue = (compoundPaymentValue - employeePaymentValue);

			return resultPaymentValue;
		}

		private Int32 CompoundContributionWithFactor (decimal compoundBasis, decimal compoundFactor)
		{
			decimal compoundResult = HealthOperations.DecFactorResult (compoundBasis, compoundFactor);

			Int32 resultPaymentValue = HealthOperations.IntRoundUp (compoundResult);

			return resultPaymentValue;
		}

		public decimal CompoundBasis(decimal generalBasis, decimal employeeBasis, decimal employerBasis)
		{
			decimal separateBasis = decimal.Add (employeeBasis, employerBasis);

			decimal compoundBasis = decimal.Add (generalBasis, separateBasis);

			return compoundBasis;
		}

	}
}

