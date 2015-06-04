using System;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookIndex : IBookParty, IComparable<IBookIndex>
	{
		IBookParty GetParty ();

		uint Code();

		uint CodeOrder();
	}
}

