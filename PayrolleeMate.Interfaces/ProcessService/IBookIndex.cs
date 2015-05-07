using System;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookIndex : IBookParty
	{
		IBookParty GetParty ();

		uint Code();

		uint CodeOrder();
	}
}

