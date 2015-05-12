using System;
using PayrolleeMate.ProcessConfig;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ConfigSetCz.Constants;
using System.Reflection;
using PayrolleeMate.ProcessConfigSetCz.Collections;
using PayrolleeMate.ProcessConfig.Collections;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Payroll.Concepts;

namespace PayrolleeMate.ProcessConfigSetCz
{
	class ConfigSetCzConceptCollection : PayrollConceptCollection<ConfigSetCzConceptCode>
	{
		public ConfigSetCzConceptCollection()
		{
			this.Models[(uint)ConfigSetCzConceptCode.CONCEPT_UNKNOWN] = new UnknownConcept();
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

