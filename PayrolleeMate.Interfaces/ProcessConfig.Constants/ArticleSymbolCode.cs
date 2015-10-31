using System;
using PayrolleeMate.Common.Core;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public enum ArticleSymbolCode : uint
	{
		ARTICLE_UNKNOWN = 0,

		ARTICLE_CONTRACT_EMPL_TERM = 101,

		ARTICLE_POSITION_EMPL_TERM = 110,

		ARTICLE_INCOME_GROSS = 501,
		ARTICLE_INCOME_NETTO = 502

	};

	public static class ArticleCodeExtensions
	{
		public static SymbolName GetSymbol(this ArticleSymbolCode article)
		{
			return new SymbolName((uint)article, article.ToString());
		}
	}
}

