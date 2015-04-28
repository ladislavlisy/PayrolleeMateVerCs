using System;

namespace Payrollee.Common
{
	public class GeneralFactory<T>
	{
		public static T InstanceFor(string namespacePrefix, string className)
		{
			string statuteClass = ClassNameFor(namespacePrefix, className);

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

		public static string ClassNameFor(string namespacePrefix, string className)
		{
			string fullClassName = namespacePrefix + className;

			return fullClassName;
		}
	}
}

