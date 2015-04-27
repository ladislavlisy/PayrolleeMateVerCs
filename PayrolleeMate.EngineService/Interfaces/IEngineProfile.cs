using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Interfaces
{
	interface IEngineProfile
	{
		ITaxingEngine Taxing ();
		IHealthEngine Health ();
		ISocialEngine Social ();
	}
}

