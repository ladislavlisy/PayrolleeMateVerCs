using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operations;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.Constants;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public abstract class SocialEnginePrototype : ISocialEngine
	{
		public const bool PENSION_SCHEME_YES = true;

		public const bool PENSION_SCHEME_NON = false;

		public SocialEnginePrototype  (SocialGuides currentGuides)
		{
			__guides = currentGuides.Clone() as SocialGuides;
		}

		private ISocialGuides __guides;

		#region ISocialEngine implementation

		public decimal SubjectSocialSelector (MonthPeriod period, bool insSubject, bool insArticle, decimal valResult)
		{
			if (insSubject && insArticle) 
			{
				return valResult;
			}
			return 0m;
		}

		public decimal ParticipSocialSelector (MonthPeriod period, bool insParticip, decimal valResult)
		{
			if (insParticip) 
			{
				return valResult;
			}
			return 0m;
		}

		public decimal BasisGeneralAdapted (MonthPeriod period, bool negSuppress, decimal valResult)
		{
			decimal adaptedResult = SocialOperations.DecSuppressNegative (negSuppress, valResult);

			decimal roundedResult = SocialOperations.DecRoundUp (adaptedResult);

			return roundedResult;
		}

		public decimal BasisLegalCapBalance (MonthPeriod period, decimal accumulBasis, decimal actualBasis)
		{
			bool negativeSuppress = true;

			decimal calculatedBase = SocialOperations.DecSuppressNegative (negativeSuppress, actualBasis);

			decimal maxHealthLimit = PeriodMaximumAnnualBasis (period);

			decimal balancedResult = HealthOperations.MaxValueAlign(calculatedBase, accumulBasis, maxHealthLimit);

			decimal legalCapsBasis = Math.Max(0, decimal.Subtract(calculatedBase, balancedResult));

			return legalCapsBasis;
		}

		// EmployeeRegularContribution
		public decimal EmployeeRegularContribution(MonthPeriod period, bool negSuppress, decimal employeeBase)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period, PENSION_SCHEME_NON);

			decimal calculatedBase = SocialOperations.DecSuppressNegative (negSuppress, employeeBase);

			Int32 resultPaymentValue = EmployeeContributionWithFactor (calculatedBase, employeeFactor);

			return resultPaymentValue;
		}

		// EmployeePensionContribution
		public decimal EmployeePensionContribution(MonthPeriod period, bool negSuppress, decimal employeeBase)
		{
			decimal employeeFactor = PeriodEmployeeFactor (period, PENSION_SCHEME_YES);

			decimal calculatedBase = SocialOperations.DecSuppressNegative (negSuppress, employeeBase);

			Int32 resultPaymentValue = EmployeeContributionWithFactor (calculatedBase, employeeFactor);

			return resultPaymentValue;
		}

		public decimal EmployeeGarantContribution(MonthPeriod period, bool negSuppress, decimal employeeBase)
		{
			decimal employeeFactor = PeriodEmployeeGarantFactor (period, PENSION_SCHEME_YES);

			decimal calculatedBase = SocialOperations.DecSuppressNegative (negSuppress, employeeBase);

			Int32 resultPaymentValue = EmployeeContributionWithFactor (calculatedBase, employeeFactor);

			return resultPaymentValue;
		}

		// EmployerContribution
		public decimal EmployerContribution(MonthPeriod period, bool negSuppress, decimal employerBase)
		{
			decimal employerFactor = PeriodEmployerFactor (period);

			decimal calculatedBase = SocialOperations.DecSuppressNegative (negSuppress, employerBase);

			Int32 resultPaymentValue = EmployerContributionWithFactor (calculatedBase, employerFactor);

			return resultPaymentValue;
		}

		// RegularCalculatedBasis
		public decimal RegularCalculatedBasis(MonthPeriod period, bool isGarantScheme, decimal socialBasis)
		{
			decimal assesmentBase = 0m;

			decimal garantFactor = PeriodEmployeeGarantFactor (period);

			if (garantFactor == 0m || isGarantScheme == PENSION_SCHEME_NON) 
			{
				assesmentBase = socialBasis;
			}

			return assesmentBase;
		}

		// PensionCalculatedBasis
		public decimal PensionCalculatedBasis(MonthPeriod period, bool isGarantScheme, decimal socialBasis)
		{
			decimal assesmentBase = 0m;

			decimal garantFactor = PeriodEmployeeGarantFactor (period);

			if (garantFactor != 0m && isGarantScheme == PENSION_SCHEME_YES) 
			{
				assesmentBase = socialBasis;
			}

			return assesmentBase;
		}

		public abstract bool ParticipateSocialIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkSocialTerms socialTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalInsIncome);

		public ISocialGuides Guides ()
		{
			return __guides;
		}

		#endregion

		#region IPeriodSocialGuides implementation

		public virtual Int32 PeriodMandatoryBasis (MonthPeriod period)
		{
			return __guides.MandatoryBasis();
		}

		public virtual decimal PeriodMaximumAnnualBasis(MonthPeriod period)
		{
			return __guides.MaximumAnnualBasis();
		}

		public virtual decimal PeriodEmployeeFactor(MonthPeriod period, bool isPension2sScheme)
		{
			decimal reduceFactor = decimal.Zero;
			if (isPension2sScheme) 
			{
				reduceFactor = PeriodPensionsReduceFactor (period);
			}
			decimal employeeFactor = PeriodEmployeeFactor (period);

			return decimal.Subtract(employeeFactor, reduceFactor);
		}

		public virtual decimal PeriodEmployeeFactor (MonthPeriod period)
		{
			return __guides.EmployeeFactor();
		}

		public virtual decimal PeriodEmployeeGarantFactor(MonthPeriod period, bool isPension2sScheme)
		{
			decimal pensionFactor = decimal.Zero;
			if (isPension2sScheme) 
			{
				pensionFactor = PeriodEmployeeGarantFactor (period);
			}
			return pensionFactor;
		}

		public virtual decimal PeriodEmployeeGarantFactor (MonthPeriod period)
		{
			return __guides.EmployeeGarantFactor();
		}

		public virtual decimal PeriodPensionsReduceFactor (MonthPeriod period)
		{
			return __guides.GarantReduceFactor();
		}

		public virtual decimal PeriodEmployerFactor (MonthPeriod period)
		{
			return __guides.EmployerFactor();
		}

		public virtual decimal PeriodEmployerElevatedFactor (MonthPeriod period)
		{
			return __guides.EmployerElevatedFactor();
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

		private Int32 EmployeeContributionWithFactor(decimal employeeBase, decimal employeeFactor)
		{
			decimal decimalResult = SocialOperations.DecFactorResult (employeeBase, employeeFactor);

			Int32 roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

		private Int32 EmployerContributionWithFactor(decimal employerBase, decimal employerFactor)
		{
			decimal decimalResult = SocialOperations.DecFactorResult (employerBase, employerFactor);

			Int32 roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

		private Int32 GarantContributionWithFactor(decimal employeeBase, decimal employeeFactor)
		{
			decimal decimalResult = SocialOperations.DecFactorResult (employeeBase, employeeFactor);

			Int32 roundedResult = SocialOperations.IntRoundUp(decimalResult);

			return roundedResult;
		}

	}
}

