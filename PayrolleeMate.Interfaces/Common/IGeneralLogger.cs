using System;

namespace PayrolleeMate.Common.Interfaces
{
	public interface IGeneralLogger
	{
		void OpenLogStream (string testName);

		void CloseLogStream ();

		void LogAppendMessageInfo (string message, string testName);
	}
}

