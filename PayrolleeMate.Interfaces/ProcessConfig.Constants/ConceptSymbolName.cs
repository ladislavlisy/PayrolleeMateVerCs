using System;
using PayrolleeMate.Common.Core;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public class ConceptSymbolName
	{
		public static readonly SymbolName REF_UNKNOWN = ConceptSymbolCode.CONCEPT_UNKNOWN.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_EMPL_TERM = ConceptSymbolCode.CONCEPT_CONTRACT_EMPL_TERM.GetSymbol();
		public static readonly SymbolName REF_POSITION_EMPL_TERM = ConceptSymbolCode.CONCEPT_POSITION_EMPL_TERM.GetSymbol();
		public static readonly SymbolName REF_INCOME_GROSS = ConceptSymbolCode.CONCEPT_INCOME_GROSS.GetSymbol();
		public static readonly SymbolName REF_INCOME_NETTO = ConceptSymbolCode.CONCEPT_INCOME_NETTO.GetSymbol();	
	}
}

