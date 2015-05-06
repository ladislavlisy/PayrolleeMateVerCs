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

		decimal BasisLegalCapBalance (MonthPeriod period, decimal accumulBasis, decimal actualBasis);

		decimal EmployeeGeneralContribution (MonthPeriod period, bool negSuppress, decimal generalBasis);

		decimal EmployeeMandatoryContribution (MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryBasis);

		decimal EmployeeContribution (MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryBasis);

		decimal EmployerGeneralContribution(MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryEmpee);

		decimal EmployerMandatoryContribution(MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryEmpee, decimal mandatoryEmper);

		decimal EmployerContribution(MonthPeriod period, bool negSuppress, decimal generalBasis, decimal mandatoryEmpee, decimal mandatoryEmper);

	}
}

