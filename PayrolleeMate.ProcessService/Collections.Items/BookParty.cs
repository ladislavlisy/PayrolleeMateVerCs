using System;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Collection.Items
{
	public class BookParty : IBookParty, IComparable
	{
		public static readonly ICodeIndex UNKNOWN_CONTRACT = CodeIndex.GetEmpty();

		public static readonly ICodeIndex UNKNOWN_POSITION = CodeIndex.GetEmpty();

		private ICodeIndex __contractIndex = UNKNOWN_CONTRACT;
		private ICodeIndex __positionIndex = UNKNOWN_POSITION;

		public static IBookParty GetEmpty()
		{
			return new BookParty(UNKNOWN_CONTRACT, UNKNOWN_POSITION);
		}

		public BookParty(ICodeIndex contractIndex, ICodeIndex positionIndex)
		{
			this.__contractIndex = contractIndex;
			this.__positionIndex = positionIndex;
		}

		public IBookParty GetContractParty()
		{
			return new BookParty(ContractIndex(), UNKNOWN_POSITION);
		}

		public IBookParty GetNewContractParty(uint indexCode, uint codeOrder)
		{
			ICodeIndex contractPartyIndex = new CodeIndex (indexCode, codeOrder);

			return new BookParty(contractPartyIndex, UNKNOWN_POSITION);
		}

		public IBookParty GetPositionParty()
		{
			return new BookParty(ContractIndex(), PositionIndex());
		}

		public IBookParty GetNewPositionParty(uint indexCode, uint codeOrder)
		{
			ICodeIndex positionPartyIndex = new CodeIndex (indexCode, codeOrder);

			return new BookParty(ContractIndex(), positionPartyIndex);
		}

		public IBookParty GetNonContractParty()
		{
			return new BookParty(UNKNOWN_CONTRACT, UNKNOWN_POSITION);
		}

		public IBookParty GetNonPositionParty()
		{
			return new BookParty(ContractIndex(), UNKNOWN_POSITION);
		}

		public ICodeIndex ContractIndex () 
		{
			return __contractIndex;
		}

		public ICodeIndex PositionIndex () 
		{
			return __positionIndex;
		}

		virtual public int CompareTo(object other)
		{
			IBookParty otherParty = other as IBookParty;

			bool equalsContractIndex = this.ContractIndex ().Equals (otherParty.ContractIndex ());

			if (equalsContractIndex)
			{
				return this.PositionIndex().CompareTo(otherParty.PositionIndex());
			}
			return this.ContractIndex().CompareTo(otherParty.ContractIndex());
		}

		public bool isEqualToParty(IBookParty other)
		{
			bool equalsContractIndex = this.ContractIndex ().Equals (other.ContractIndex ());

			bool equalsPositionIndex = this.PositionIndex ().Equals (other.PositionIndex ());

			return (equalsContractIndex && equalsPositionIndex);
		}

		public override bool Equals(object other)
		{
			if (other == this)
				return true;
			if (other == null || this.GetType() != other.GetType())
				return false;

			IBookParty otherParty = other as IBookParty;

			return this.isEqualToParty(otherParty);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.ContractIndex().GetHashCode();

			result += prime * result + (int)this.PositionIndex().GetHashCode();

			return result;
		}
	}
}

