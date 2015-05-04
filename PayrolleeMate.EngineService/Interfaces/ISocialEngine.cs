using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Social;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface ISocialEngine : IPeriodSocialGuides
	{
		ISocialGuides Guides ();

		decimal SubjectSocialSelector (MonthPeriod period, bool insSubject, bool insArticle, decimal valResult);

		decimal ParticipSocialSelector (MonthPeriod period, bool insParticip, decimal valResult);

		decimal BasisGeneralAdapted (MonthPeriod period, bool negSuppress, decimal valResult);

		decimal BasisLegalCapBalance (MonthPeriod period, decimal accumulBasis, decimal actualBasis);

		decimal EmployeeRegularContribution (MonthPeriod period, decimal employeeBase);

		decimal EmployeePensionContribution (MonthPeriod period, decimal employeeBase);

		decimal EmployerContribution (MonthPeriod period, decimal employerBase);

		decimal RegularCalculatedBasis (MonthPeriod period, bool isNegativeIncluded, bool isPension2sScheme, decimal employeeIncome, decimal accumulatedBase);

		decimal PensionCalculatedBasis (MonthPeriod period, bool isNegativeIncluded, bool isPension2sScheme, decimal employeeIncome, decimal accumulatedBase);

		decimal Pension2sSchemeContribution (MonthPeriod period, decimal employeeBase);
	}
}

