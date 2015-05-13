using System;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ConfigSetCz.Constants;
using System.Reflection;
using PayrolleeMate.ProcessConfig.Collections;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Payroll.Articles;

namespace PayrolleeMate.ProcessConfigSetCz.Collections
{
	class ConfigSetCzArticleCollection : PayrollArticleCollection<ConfigSetCzArticleCode>
	{
		public ConfigSetCzArticleCollection()
		{
			this.Models[(uint)ConfigSetCzArticleCode.ARTICLE_UNKNOWN] = new UnknownArticle();

			this.DefaultCode = (uint)ConfigSetCzArticleCode.ARTICLE_UNKNOWN;
		}

		#region implemented abstract members of GeneralCollection

		protected override uint GetCode (ConfigSetCzArticleCode configIndex)
		{
			return (uint)configIndex;
		}

		protected override SymbolName GetSymbol (uint configCode)
		{
			ConfigSetCzArticleCode configIndex = (ConfigSetCzArticleCode)Enum.ToObject(typeof(ConfigSetCzArticleCode), configCode);

			return new SymbolName (configCode, configIndex.ToString());
		}

		#endregion
	}

}

