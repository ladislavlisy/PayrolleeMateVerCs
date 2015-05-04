using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IHealthEngine : IPeriodHealthGuides
	{
		IHealthGuides Guides ();

		decimal SubjectHealthSelector (MonthPeriod period, bool insSubject, bool insArticle, decimal valResult);

		decimal ParticipHealthSelector (MonthPeriod period, bool insParticip, decimal valResult);

		decimal BasisGeneralAdapted (MonthPeriod period, bool negSuppress, decimal valResult);

		decimal BasisMandatoryBalance (MonthPeriod period, bool dutyMandatory, decimal valResult);

		Int32 EmployeeContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis);

		Int32 EmployerContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis);

		Int32 CompoundContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis);

		decimal CalculatedBasis (MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase);

		decimal EmployeeMandatoryBasis (MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase);
	}
}

