using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public abstract class HealthEnginePrototype : IHealthEngine
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
		public decimal EmployeeContribution (MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryBasis)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			decimal calculatedBase = HealthOperations.DecSuppressNegative (negSuppress, generalBasis);

			Int32 resultGeneralValue = EmployeeContributionWithFactor(calculatedBase, mandatoryBasis, compoundFactor);

			return resultGeneralValue;
		}
			
		public decimal EmployerGeneralContribution(MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryEmpee)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			decimal mandatoryNones = 0m;

			Int32 resultGeneralValue = EmployerContributionWithFactor(generalBasis, mandatoryEmpee, mandatoryNones, compoundFactor);

			return (resultGeneralValue);
		}

		public decimal EmployerMandatoryContribution(MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryEmpee, decimal mandatoryEmper)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			decimal mandatoryNones = 0m;

			Int32 resultCompletValue = EmployerContributionWithFactor(generalBasis, mandatoryEmpee, mandatoryEmper, compoundFactor);

			Int32 resultGeneralValue = EmployerContributionWithFactor(generalBasis, mandatoryEmpee, mandatoryNones, compoundFactor);

			return (resultCompletValue - resultGeneralValue);
		}

		// EmployerContribution
		public decimal EmployerContribution(MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryEmpee, decimal mandatoryEmper)
		{
			decimal compoundFactor = PeriodCompoundFactor (period);

			Int32 resultPaymentValue = EmployerContributionWithFactor(generalBasis, mandatoryEmpee, mandatoryEmper, compoundFactor);

			return resultPaymentValue;
		}

		public abstract bool ParticipateHealthIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkHealthTerms healthTerm, 
		                                              decimal contractIncome, decimal workTermIncome, decimal totalInsIncome);
		
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

		public virtual decimal PeriodMarginalIncomeEmployment (MonthPeriod period)
		{
			return __guides.MarginalIncomeEmployment();
		}

		public virtual decimal PeriodMarginalIncomeAgreeTasks (MonthPeriod period)
		{
			return __guides.MarginalIncomeAgreeTasks();
		}

		#endregion

		private Int32 EmployeeContributionWithFactor (decimal generalBasis, decimal mandatoryEmpee, decimal compoundFactor)
		{
			decimal decimalResult1 = HealthOperations.DecFactorResult (mandatoryEmpee, compoundFactor);

			decimal decimalResult2 = HealthOperations.DecFactorResult (generalBasis, compoundFactor);

			decimal decimalResult3 = DecOperations.Divide(decimalResult2, 3);

			Int32 resultPaymentValue = HealthOperations.IntRoundUp (decimal.Add (decimalResult1, decimalResult3));

			return resultPaymentValue;
		}

		private Int32 EmployerContributionWithFactor (decimal generalBasis, decimal mandatoryEmpee, decimal mandatoryEmper, decimal compoundFactor)
		{
			decimal compoundBasis = CompoundBasis(generalBasis, mandatoryEmpee, mandatoryEmper);

			Int32 compoundPaymentValue = CompoundContributionWithFactor(compoundBasis, compoundFactor);

			Int32 employeePaymentValue = EmployeeContributionWithFactor(generalBasis, mandatoryEmpee, compoundFactor);

			Int32 resultPaymentValue = (compoundPaymentValue - employeePaymentValue);

			return resultPaymentValue;
		}

		private Int32 CompoundContributionWithFactor (decimal compoundBasis, decimal compoundFactor)
		{
			decimal compoundResult = HealthOperations.DecFactorResult (compoundBasis, compoundFactor);

			Int32 resultPaymentValue = HealthOperations.IntRoundUp (compoundResult);

			return resultPaymentValue;
		}

		public decimal CompoundBasis(decimal generalBasis, decimal mandatoryEmpee, decimal mandatoryEmper)
		{
			decimal mandatoryBasis = decimal.Add (mandatoryEmpee, mandatoryEmper);

			decimal compoundBasis = decimal.Add (generalBasis, mandatoryBasis);

			return compoundBasis;
		}

	}
}

