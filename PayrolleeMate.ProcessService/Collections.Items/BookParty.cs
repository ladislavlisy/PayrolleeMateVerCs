using System;
using PayrolleeMate.ProcessService.Interfaces;

namespace PayrolleeMate.ProcessService.Collection.Items
{
	public class BookParty : IBookParty, IComparable
	{
		public static readonly uint UNKNOWN_CONTRACT = 0;

		public static readonly uint UNKNOWN_POSITION = 0;

		private uint __contractOrder = UNKNOWN_CONTRACT;
		private uint __positionOrder = UNKNOWN_POSITION;

		public static IBookParty GetEmpty()
		{
			return new BookParty(UNKNOWN_CONTRACT, UNKNOWN_POSITION);
		}

		public BookParty(uint contractOrder, uint positionOrder)
		{
			this.__contractOrder = contractOrder;
			this.__positionOrder = positionOrder;
		}

		public IBookParty GetContractParty()
		{
			return new BookParty(ContractOrder(), UNKNOWN_POSITION);
		}

		public IBookParty GetNewContractParty(uint order)
		{
			return new BookParty(order, UNKNOWN_POSITION);
		}

		public IBookParty GetPositionParty()
		{
			return new BookParty(ContractOrder(), PositionOrder());
		}

		public IBookParty GetNewPositionParty(uint order)
		{
			return new BookParty(ContractOrder(), order);
		}

		public IBookParty GetNonContractParty()
		{
			return new BookParty(UNKNOWN_CONTRACT, UNKNOWN_POSITION);
		}

		public IBookParty GetNonPositionParty()
		{
			return new BookParty(ContractOrder(), UNKNOWN_POSITION);
		}

		public uint ContractOrder () 
		{
			return __contractOrder;
		}

		public uint PositionOrder () 
		{
			return __positionOrder;
		}

		virtual public int CompareTo(object other)
		{
			BookParty otherParty = other as BookParty;

			if (this.ContractOrder() != otherParty.ContractOrder())
			{
				return this.ContractOrder().CompareTo(otherParty.ContractOrder());
			}
			return this.PositionOrder().CompareTo(otherParty.PositionOrder());
		}

		public bool isEqualToParty(IBookParty other)
		{
			return (this.ContractOrder() == other.ContractOrder() && 
				this.PositionOrder() == other.PositionOrder());
		}

		public override bool Equals(object other)
		{
			if (other == this)
				return true;
			if (other == null || this.GetType() != other.GetType())
				return false;

			BookParty otherParty = other as BookParty;

			return this.isEqualToParty(otherParty);
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;

			result += prime * result + (int)this.ContractOrder();

			result += prime * result + (int)this.PositionOrder();

			return result;
		}
	}
}

