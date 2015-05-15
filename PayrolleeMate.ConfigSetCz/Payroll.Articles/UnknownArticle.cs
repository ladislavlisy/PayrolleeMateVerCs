using System;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfig.Payroll.Articles
{
	public class UnknownArticle : GeneralPayrollArticle
	{
		public UnknownArticle () : 
			base(ArticleSymbolName.REF_UNKNOWN, ConceptSymbolName.REF_UNKNOWN, ProcessCategory.CATEGORY_START, 
				EMPTY_ARTICLE_NAMES, EMPTY_ARTICLE_NAMES, 
				false, false, false, false, false, false)
		{
		}
	}
}

