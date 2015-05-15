using System;
using System.Reflection;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Collections;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;
using PayrolleeMate.ProcessConfigSetCz.Collections;
using PayrolleeMate.ProcessConfigSetCz.Constants;

namespace PayrolleeMate.ProcessConfigSetCz
{
	public class ConfigSetCzConceptCollection : PayrollConceptCollection<ConfigSetCzConceptCode>
	{
		public ConfigSetCzConceptCollection()
		{
			this.Models[(uint)ConfigSetCzConceptCode.CONCEPT_UNKNOWN] = new UnknownConcept();

			this.DefaultCode = (uint)ConfigSetCzConceptCode.CONCEPT_UNKNOWN;
		}

		#region implemented abstract members of GeneralCollection

		protected override uint GetCode (ConfigSetCzConceptCode configIndex)
		{
			return (uint)configIndex;
		}

		protected override SymbolName GetSymbol (uint configCode)
		{
			ConfigSetCzConceptCode configIndex = (ConfigSetCzConceptCode)Enum.ToObject(typeof(ConfigSetCzConceptCode), configCode);

			return new SymbolName (configCode, configIndex.ToString());
		}

		#endregion
	}

}

