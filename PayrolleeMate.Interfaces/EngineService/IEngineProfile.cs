using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IEngineProfile
	{
		MonthPeriod PayrunPeriod ();
		IPeriodEngine Period ();
		ITaxingEngine Taxing ();
		IHealthEngine Health ();
		ISocialEngine Social ();
	}
}

