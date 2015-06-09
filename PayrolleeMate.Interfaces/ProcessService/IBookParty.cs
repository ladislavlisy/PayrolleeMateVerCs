using System;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookParty
	{
		IBookParty GetContractParty ();

		IBookParty GetNewContractParty (uint indexCode, uint codeOrder);

		IBookParty GetPositionParty ();

		IBookParty GetNewPositionParty (uint indexCode, uint codeOrder);

		IBookParty GetNonContractParty ();

		IBookParty GetNonPositionParty ();

		ICodeIndex ContractIndex ();

		ICodeIndex PositionIndex ();

		bool isEqualToParty (IBookParty other);
	}
}

