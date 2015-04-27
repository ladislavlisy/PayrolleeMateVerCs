using System;
using PayrolleeMate.Common.Periods;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IEngineProfile
	{
		ITaxingEngine Taxing ();
		IHealthEngine Health ();
		ISocialEngine Social ();
	}
}

