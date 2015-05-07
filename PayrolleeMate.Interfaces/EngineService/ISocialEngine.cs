using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Social;
using PayrolleeMate.EngineService.Constants;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface ISocialEngine : IPeriodSocialGuides
	{
		ISocialGuides Guides ();

		decimal SubjectSocialSelector (MonthPeriod period, bool insSubject, bool insArticle, decimal valResult);

		decimal ParticipSocialSelector (MonthPeriod period, bool insParticip, decimal valResult);

		decimal BasisGeneralAdapted (MonthPeriod period, bool negSuppress, decimal valResult);

		decimal BasisLegalCapBalance (MonthPeriod period, decimal accumulBasis, decimal actualBasis);

		decimal RegularCalculatedBasis (MonthPeriod period, bool isGarantScheme, decimal socialBasis);

		decimal PensionCalculatedBasis (MonthPeriod period, bool isGarantScheme, decimal socialBasis);

		decimal EmployeeRegularContribution (MonthPeriod period, bool negSuppress, decimal employeeBase);

		decimal EmployeePensionContribution (MonthPeriod period, bool negSuppress, decimal employeeBase);

		decimal EmployerContribution (MonthPeriod period, bool negSuppress, decimal employerBase);

		decimal EmployeeGarantContribution (MonthPeriod period, bool negSuppress, decimal employeeBase);

		bool ParticipateSocialIncome (MonthPeriod period, WorkRelationTerms workTerm, WorkSocialTerms socialTerm, 
			decimal contractIncome, decimal workTermIncome, decimal totalInsIncome);
	}
}

