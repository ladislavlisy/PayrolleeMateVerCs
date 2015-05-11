using System;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfig.Interfaces;

namespace PayrolleeMate.ProcessConfigSetCz
{
	public class ProcessConfigSetCzModule : ProcessConfigModule
	{
		public static IProcessConfig CreateModule()
		{
			IProcessConfig config = new ProcessConfigSetCzModule ();

			return config;
		}

		private ProcessConfigSetCzModule () : base()
		{
		}

		#region implemented abstract members of ProcessConfigModule

		public override void InitArticles ()
		{
			throw new NotImplementedException ();
		}

		public override void InitConcepts ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

