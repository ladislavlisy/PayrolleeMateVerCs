using System;
using PayrolleeMate.Common.Core;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public enum ConceptSymbolCode : uint
	{
		CONCEPT_UNKNOWN = 10000,

		CONCEPT_CONTRACT_EMPL_TERM = 10101,

		CONCEPT_POSITION_EMPL_TERM = 10110,

		CONCEPT_INCOME_GROSS = 10501,
		CONCEPT_INCOME_NETTO = 10502
	};
			
	public static class ConceptCodeExtensions
	{
		public static SymbolName GetSymbol(this ConceptSymbolCode concept)
		{
			return new SymbolName((uint)concept, concept.ToString());
		}
	}

}

