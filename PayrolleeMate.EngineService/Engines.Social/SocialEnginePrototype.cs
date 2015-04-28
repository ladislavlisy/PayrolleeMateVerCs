using System;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common.Rounding;
using PayrolleeMate.Common.Operation;

namespace PayrolleeMate.EngineService.Engines.Social
{
	public class SocialEnginePrototype : ISocialEngine, ISocialGuides
	{
		public SocialEnginePrototype  (SocialGuides currentGuides)
		{
			__guides = currentGuides.Clone() as SocialGuides;
		}

		private ISocialGuides __guides;

		#region ISocialEngine implementation

		public ISocialGuides Guides ()
		{
			return __guides;
		}

		#endregion

		#region ISocialGuides implementation
		public int MandatoryBasis ()
		{
			return __guides.MandatoryBasis();
		}
		public decimal MaximumAnnualBasis ()
		{
			return __guides.MaximumAnnualBasis();
		}
		public decimal EmployeeFactor ()
		{
			return __guides.EmployeeFactor();
		}
		public decimal EmployeePensionsFactor ()
		{
			return __guides.EmployeePensionsFactor();
		}
		public decimal PensionsReduceFactor ()
		{
			return __guides.PensionsReduceFactor();
		}
		public decimal EmployerFactor ()
		{
			return __guides.EmployerFactor();
		}
		public decimal EmployerExemptionFactor ()
		{
			return __guides.EmployerExemptionFactor();
		}
		#endregion
	}
}

