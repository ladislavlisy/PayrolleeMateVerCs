using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public enum ConceptCode : uint
	{
		CONCEPT_UNKNOWN = 10000,

		CONCEPT_CONTRACT_EMPL_TERM = 10101,

		CONCEPT_POSITION_TERM = 10110,

		CONCEPT_INCOME_GROSS = 10501,
		CONCEPT_INCOME_NETTO = 10502
	};
			
	public static class ConceptCodeExtensions
	{
		public static SymbolName GetSymbol(this ConceptCode concept)
		{
			return new SymbolName((uint)concept, concept.ToString());
		}
	}

}

