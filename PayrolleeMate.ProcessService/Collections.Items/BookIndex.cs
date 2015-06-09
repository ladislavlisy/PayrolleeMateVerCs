using System;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Collection.Items
{
	public class BookIndex : BookParty, IBookIndex
	{
		private ICodeIndex __index = CodeIndex.GetEmpty();

		public static new BookIndex GetEmpty()
		{
			return new BookIndex(BookParty.GetEmpty(), CodeIndex.UNKNOWN_CODE, CodeIndex.UNKNOWN_ORDER);
		}

		public IBookParty GetParty()
		{
			return new BookParty(ContractIndex(), PositionIndex());
		}

		public BookIndex(IBookParty party, uint code, uint codeOrder)
			: base(party.ContractIndex(), party.PositionIndex())
		{
			this.__index = new CodeIndex(code, codeOrder);
		}

		public BookIndex(ICodeIndex contractIndex, ICodeIndex positionIndex, uint code, uint codeOrder)
			: base(contractIndex, positionIndex)
		{
			this.__index = new CodeIndex(code, codeOrder);
		}

		public ICodeIndex GetIndex() 
		{
			return __index;
		}

		public uint Code() 
		{
			return __index.Code();
		}

		public uint CodeOrder() 
		{
			return __index.CodeOrder(); 
		}

		override public int CompareTo(object other)
		{
			IBookIndex otherIndex = other as IBookIndex;

			return CompareTo (otherIndex);
		}

		public int CompareTo(IBookIndex otherIndex)
		{
			bool equalsPartyIndex = base.isEqualToParty (otherIndex);

			if (equalsPartyIndex)
			{
				return (this.GetIndex().CompareTo(otherIndex.GetIndex()));
			}
			return base.CompareTo(otherIndex);
		}

		public bool isEqualToOrder(IBookIndex other)
		{
			return (base.isEqualToParty(other) && this.GetIndex().Equals(other.GetIndex()));
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

			result += prime * result + (int)this.GetIndex().GetHashCode();

			return result;
		}

		public override string ToString()
		{
			return "<<" +
				":CON:" + this.ContractIndex().ToString() + 
				":POS:" + this.PositionIndex().ToString() + 
				">> - " + this.GetIndex().ToString();
		}
	}
}

