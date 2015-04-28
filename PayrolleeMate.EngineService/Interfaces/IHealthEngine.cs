using System;
using PayrolleeMate.Common.Periods;
using PayrolleeMate.EngineService.Engines.Health;

namespace PayrolleeMate.EngineService.Interfaces
{
	public interface IHealthEngine
	{
		IHealthGuides Guides ();
	}

}

