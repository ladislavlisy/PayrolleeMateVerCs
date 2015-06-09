using System;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface ICodeIndex : IComparable<ICodeIndex>
	{
		uint Code();

		uint CodeOrder();

		bool isEqualToIndex (ICodeIndex other);
	}
}

