using System;
using System.Collections.Generic;
using System.Reflection;
using PayrolleeMate.Common.Core;

namespace PayrolleeMate.Common.Collection
{
	public abstract class GeneralCollection<T, IDX>
	{
		public GeneralCollection()
		{
			this.Models = new Dictionary<uint, T>();
		}

		public IDictionary<uint, T> Models { get; protected set; }

		public uint DefaultCode { get; protected set; }

		public T InstanceFromModels(Assembly configAssembly, uint configCode)
		{
			T modelInstance = default(T);

			if (!Models.ContainsKey(configCode))
			{
				T baseInstance = EmptyInstanceForCode(configAssembly, configCode);

				modelInstance = ConfigureModel(baseInstance, configCode);
			}
			else
			{
				modelInstance = FindInstanceForCode(configCode);
			}
			return modelInstance;
		}

		public T ConfigureModel(T baseInstance, uint configCode)
		{
			T modelInstance = baseInstance;

			if (modelInstance != null)
			{
				Models [configCode] = modelInstance;
			}
			else if (Models.ContainsKey (configCode)) 
			{
				modelInstance = Models [configCode];
			}
			return modelInstance;
		}

		public T FindInstanceForEnum(IDX configIndex)
		{
			uint configCode = GetCode (configIndex);

			T baseInstance = FindInstanceForCode (configCode);

			return baseInstance;
		}

		public T FindInstanceForCode(uint configCode)
		{
			T baseInstance = default(T);

			if (Models.ContainsKey(configCode))
			{
				baseInstance = Models[configCode];
			}
			else
			{
				baseInstance = Models[DefaultCode];
			}
			return baseInstance;
		}

		public T EmptyInstanceForCode(Assembly configAssembly, uint configCode)
		{
			SymbolName configSymbol = GetSymbol (configCode);

			T emptyInstance = InstanceFor(configAssembly, configSymbol);

			return emptyInstance;
		}

		public T EmptyInstanceForEnum(Assembly configAssembly, IDX configIndex)
		{
			uint configCode = GetCode (configIndex);

			return EmptyInstanceForCode(configAssembly, configCode);
		}

		protected abstract uint GetCode (IDX configIndex);

		protected abstract SymbolName GetSymbol (uint configCode);

		protected abstract T InstanceFor (Assembly configAssembly, SymbolName configSymbol);

	}
}

