using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.EngineService.Engines.Health
{
	public class HealthEnginePrototype : IHealthEngine, IHealthGuides
	{
		public HealthEnginePrototype  (HealthGuides currentGuides)
		{
			__guides = currentGuides.Clone() as HealthGuides;
		}

		private IHealthGuides __guides;

		#region IHealthEngine implementation

		public IHealthGuides Guides ()
		{
			return __guides;
		}

		#endregion

		#region IHealthGuides implementation
		public int MandatoryBasis ()
		{
			return __guides.MandatoryBasis();
		}
		public decimal MaximumAnnualBasis ()
		{
			return __guides.MaximumAnnualBasis();
		}
		public decimal EmployerFactor ()
		{
			return __guides.EmployerFactor();
		}
		public decimal EmployeeFactor ()
		{
			return __guides.EmployeeFactor();
		}
		public decimal CompoundFactor ()
		{
			return __guides.CompoundFactor();
		}
		#endregion
	}
}

