using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IHealthEngine
	{
		IHealthGuides Guides ();

		Int32 EmployeeContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis);

		Int32 EmployerContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis);

		Int32 CompoundContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis);

		decimal CalculatedBasis (MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase);

		decimal EmployeeMandatoryBasis (MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase);
	}
}

