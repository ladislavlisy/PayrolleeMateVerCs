using System;
using PayrolleeMate.Common;
using System.Linq;

namespace PayrolleeMate.ProcessConfig.Exceptions
{
	public class EngineProcessCircleException : Exception
	{
		public EngineProcessCircleException(string message, uint[] callingPath, uint articleCode) : base(message)
		{
			this.ArticleName = articleCode.ToString();

			this.ArticlePath = string.Join (",", callingPath.Select (x => x.ToString()));
		}

		public string ArticleName { get; private set; }

		public string ArticlePath { get; private set; }
	}
}

