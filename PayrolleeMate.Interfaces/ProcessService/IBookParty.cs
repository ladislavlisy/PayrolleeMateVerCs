using System;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookParty
	{
		IBookParty GetContractParty ();

		IBookParty GetNewContractParty (uint order);

		IBookParty GetPositionParty ();

		IBookParty GetNewPositionParty (uint order);

		IBookParty GetNonContractParty ();

		IBookParty GetNonPositionParty ();

		uint ContractOrder ();

		uint PositionOrder ();

		bool isEqualToParty (IBookParty other);
	}
}

