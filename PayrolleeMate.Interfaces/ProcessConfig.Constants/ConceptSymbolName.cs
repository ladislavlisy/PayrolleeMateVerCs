using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public class ConceptSymbolName
	{
		public static readonly SymbolName REF_UNKNOWN = ConceptCode.CONCEPT_UNKNOWN.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_EMPL_TERM = ConceptCode.CONCEPT_CONTRACT_EMPL_TERM.GetSymbol();
		public static readonly SymbolName REF_POSITION_TERM = ConceptCode.CONCEPT_POSITION_TERM.GetSymbol();
		public static readonly SymbolName REF_INCOME_GROSS = ConceptCode.CONCEPT_INCOME_GROSS.GetSymbol();
		public static readonly SymbolName REF_INCOME_NETTO = ConceptCode.CONCEPT_INCOME_NETTO.GetSymbol();	
	}
}

