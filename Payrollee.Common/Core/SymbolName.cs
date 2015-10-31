using System;

namespace PayrolleeMate.Common.Core
{
	public class SymbolName : IComparable
	{
		public SymbolName (uint code, string name)
		{
			this.Code = code;
			this.Name = name;
		}

		public uint Code { get; private set; }
		public string Name { get; private set; }

		public int CompareTo(object obj)
		{
			SymbolName other = obj as SymbolName;

			return (this.Code.CompareTo(other.Code));
		}

		public override bool Equals(object obj)
		{
			if (obj == this)
				return true;
			if (obj==null || this.GetType() != obj.GetType())
				return false;

			SymbolName other = obj as SymbolName;

			return this.Code == other.Code;
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.Code;
			return result;
		}
	}
}

