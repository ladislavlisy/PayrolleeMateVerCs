using System;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookIndex : IBookParty, IComparable<IBookIndex>
	{
		ICodeIndex GetIndex ();

		IBookParty GetParty ();

		uint Code();

		uint CodeOrder();
	}
}

