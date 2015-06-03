using System;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Collection.Items
{
	public class BookIndex : BookParty, IBookIndex
	{
		public static readonly uint UNKNOWN_CODE = 0;

		public static readonly uint UNKNOWN_ORDER = 0;

		private uint __code = UNKNOWN_CODE;

		private uint __codeOrder = UNKNOWN_ORDER;

		public static new BookIndex GetEmpty()
		{
			return new BookIndex(BookParty.GetEmpty(), UNKNOWN_CODE, UNKNOWN_ORDER);
		}

		public IBookParty GetParty()
		{
			return new BookParty(ContractOrder(), PositionOrder());
		}

		public BookIndex(IBookParty party, uint code, uint codeOrder)
			: base(party.ContractOrder(), party.PositionOrder())
		{
			this.__code = code;
			this.__codeOrder = codeOrder;
		}

		public BookIndex(uint contractOrder, uint positionOrder, uint code, uint codeOrder)
			: base(contractOrder, positionOrder)
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

		override public int CompareTo(object other)
		{
			BookIndex otherIndex = other as BookIndex;

			if (!base.isEqualToParty(otherIndex))
			{
				return base.CompareTo(otherIndex);
			}
			else
			if (this.Code() != otherIndex.Code())
			{
				return this.Code().CompareTo(otherIndex.Code());
			}
			return (this.CodeOrder().CompareTo(otherIndex.CodeOrder()));
		}

		public bool isEqualToOrder(IBookIndex other)
		{
			return (base.isEqualToParty(other)
				&& this.Code() == other.Code()
				&& this.CodeOrder() == other.CodeOrder());
		}

		public override bool Equals(object other)
		{
			if (other == this)
				return true;
			if (other == null || this.GetType() != other.GetType())
				return false;

			BookIndex otherIndex = other as BookIndex;

			return this.isEqualToOrder(otherIndex);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result = base.GetHashCode();

			result += prime * result + (int)this.Code();

			result += prime * result + (int)this.CodeOrder();

			return result;
		}

		public override string ToString()
		{
			return "<<" +
				":CON:" + this.ContractOrder().ToString() + 
				":POS:" + this.PositionOrder().ToString() + 
				":ORD:" + this.CodeOrder().ToString() + 
				">>";
		}
	}
}

