using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public class ArticleSymbolName
	{
		public static readonly SymbolName REF_UNKNOWN = ArticleCode.ARTICLE_UNKNOWN.GetSymbol();
		public static readonly SymbolName REF_CONTRACT_EMPL_TERM = ArticleCode.ARTICLE_CONTRACT_EMPL_TERM.GetSymbol();
		public static readonly SymbolName REF_POSITION_TERM = ArticleCode.ARTICLE_POSITION_TERM.GetSymbol();
		public static readonly SymbolName REF_INCOME_GROSS = ArticleCode.ARTICLE_INCOME_GROSS.GetSymbol();
		public static readonly SymbolName REF_INCOME_NETTO = ArticleCode.ARTICLE_INCOME_NETTO.GetSymbol();	
	}
}

