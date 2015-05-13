using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public class ArticleSymbolName
	{
		public static readonly SymbolName REF_UNKNOWN = ArticleSymbolCode.ARTICLE_UNKNOWN.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_EMPL_TERM = ArticleSymbolCode.ARTICLE_CONTRACT_EMPL_TERM.GetSymbol();
		public static readonly SymbolName REF_POSITION_EMPL_TERM = ArticleSymbolCode.ARTICLE_POSITION_EMPL_TERM.GetSymbol();
		public static readonly SymbolName REF_INCOME_GROSS = ArticleSymbolCode.ARTICLE_INCOME_GROSS.GetSymbol();
		public static readonly SymbolName REF_INCOME_NETTO = ArticleSymbolCode.ARTICLE_INCOME_NETTO.GetSymbol();	
	}
}

