using System;
using PayrolleeMate.Common;
using System.Linq;

namespace PayrolleeMate.ProcessConfig.Exceptions
{
	public class EngineProcessCircleException : Exception
	{
		public EngineProcessCircleException(string message, SymbolName[] callingPath, SymbolName article) : base(message)
		{
			this.ArticleName = article.Name;

			this.ArticlePath = string.Join (",", callingPath.Select (x => x.Name));
		}

		public string ArticleName { get; private set; }

		public string ArticlePath { get; private set; }
	}
}

