using System;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public enum ArticleCode : uint
	{
		ARTICLE_UNKNOWN = 0,

		ARTICLE_CONTRACT_EMPL_TERM = 101,

		ARTICLE_POSITION_TERM = 110,

		ARTICLE_INCOME_GROSS = 501,
		ARTICLE_INCOME_NETTO = 502

	};

	public static class ArticleCodeExtensions
	{
		public static SymbolName GetSymbol(this ArticleCode article)
		{
			return new SymbolName((uint)article, article.ToString());
		}
	}
}

