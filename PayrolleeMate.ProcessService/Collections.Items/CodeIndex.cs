using System;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Collection.Items
{
	public class CodeIndex : ICodeIndex, IComparable
	{
		public static readonly uint UNKNOWN_CODE = 0;

		public static readonly uint UNKNOWN_ORDER = 0;

		private uint __code = UNKNOWN_CODE;

		private uint __codeOrder = UNKNOWN_ORDER;

		public static CodeIndex GetEmpty()
		{
			return new CodeIndex(UNKNOWN_CODE, UNKNOWN_ORDER);
		}

		public CodeIndex (uint code, uint codeOrder)
		{
			this.__code = code;
			this.__codeOrder = codeOrder;
		}

		public uint Code() 
		{
			return __code;
		}

		public uint CodeOrder() 
		{
			return __codeOrder; 
		}

		public int CompareTo(object other)
		{
			ICodeIndex otherIndex = other as ICodeIndex;

			return CompareTo (otherIndex);
		}

		public int CompareTo(ICodeIndex otherIndex)
		{
			if (this.Code() != otherIndex.Code())
			{
				return this.Code().CompareTo(otherIndex.Code());
			}
			return (this.CodeOrder().CompareTo(otherIndex.CodeOrder()));
		}

		public bool isEqualToIndex(ICodeIndex other)
		{
			return (this.Code() == other.Code()	&& this.CodeOrder() == other.CodeOrder());
		}

		public override bool Equals(object other)
		{
			if (other == this)
				return true;
			if (other == null || this.GetType() != other.GetType())
				return false;

			ICodeIndex otherIndex = other as ICodeIndex;

			return this.isEqualToIndex(otherIndex);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.Code();

			result += prime * result + (int)this.CodeOrder();

			return result;
		}

		public override string ToString()
		{
			return "<<" +
				":COD:" + this.Code().ToString() + 
				":ORD:" + this.CodeOrder().ToString() + 
				">>";
		}
	}
}

