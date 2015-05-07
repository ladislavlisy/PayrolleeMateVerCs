using System;

namespace PayrolleeMate.ProcessConfig.Constants
{
	public enum ProcessCategory : uint
	{
		CATEGORY_TERMS  = 0,
		CATEGORY_START  = 1,
		CATEGORY_TIMES  = 2,
		CATEGORY_AMOUNT = 3,
		CATEGORY_GROSS  = 4,
		CATEGORY_NETTO  = 5,
		CATEGORY_FINAL  = 9
	};
}

