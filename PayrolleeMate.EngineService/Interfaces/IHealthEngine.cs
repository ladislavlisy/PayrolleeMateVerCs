using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IHealthEngine
	{
		IHealthGuides Guides ();

		long EmployeeContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis);

		long EmployerContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis);

		long CompoundContribution (MonthPeriod period, decimal generalBasis, decimal employeeBasis, decimal employerBasis);

		decimal CalculatedBasis (MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase);

		decimal EmployeeMandatoryBasis (MonthPeriod period, bool isNegativeIncluded, bool isMinBaseRequired, decimal employeeIncome, decimal accumulatedBase);
	}
}

