using System;

namespace Payrollee.Common
{
	public class GeneralFactory<T>
	{
		public GeneralFactory (string prefixName, string symbolName)
		{
			__classNamePrefix = prefixName;

			__classSymbolName = symbolName;
		}

		private string __classNamePrefix;

		private string __classSymbolName;

		public T InstanceFor(string symbolDescription)
		{
			string statuteClass = ClassNameFor(__classNamePrefix, symbolDescription);

			Type statuteType = Type.GetType(statuteClass);

			if (statuteType == null)
			{
				throw new InvalidOperationException("Class does't exist: " + statuteClass);
			}
			T statuteInstance = (T)Activator.CreateInstance(statuteType);
			if (statuteInstance == null)
			{
				throw new InvalidOperationException("Instance wasn't created: " + statuteClass);
			}
			return statuteInstance;
		}

		public static string ClassNameFor(string prefixName, string symbolDescription)
		{
			string className = prefixName + symbolDescription;

			return className;
		}
	}
}

