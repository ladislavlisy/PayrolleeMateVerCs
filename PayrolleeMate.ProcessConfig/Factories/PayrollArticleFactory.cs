using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;
using System.Reflection;
using System.Text.RegularExpressions;
using PayrolleeMate.Common.Libs;

namespace PayrolleeMate.ProcessConfig.Factories
{
	public static class PayrollArticleFactory
	{
		private const string NAME_SPACE_PREFIX = "PayrolleeMate.ProcessConfig.Payroll.Articles";

		#region Dynamic Creation

		public static IPayrollArticle ArticleFor(Assembly configAssembly, string articleName)
		{
			string articleClass = ClassNameFor(articleName);

			return GeneralFactory<IPayrollArticle>.InstanceFor (configAssembly, NAME_SPACE_PREFIX, articleClass);
		}

		public static string ClassNameFor(string articleName)
		{
			Regex regexObj = new Regex("ARTICLE_(.*)", RegexOptions.Singleline);
			Match matchResult = regexObj.Match(articleName);
			string matchResultName = "";
			if (matchResult.Success)
			{
				GroupCollection regexCol = matchResult.Groups;
				if (regexCol.Count == 2)
				{
					matchResultName = regexCol[1].Value;
				}
			}
			string className = matchResultName.Underscore().Camelize() + "Article";

			return className;
		}

		#endregion

	}
}

