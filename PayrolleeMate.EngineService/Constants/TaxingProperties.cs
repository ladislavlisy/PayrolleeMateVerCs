using System;

namespace PayrolleeMate.EngineService.Constants
{
	class TaxingProperties2015
	{
		public static readonly Int32 ALLOWANCE_PAYER_BASIC = 2070;
		public static readonly Int32 ALLOWANCE_PAYER_DIS_1ST = 210; 
		public static readonly Int32 ALLOWANCE_PAYER_DIS_2ND = 420;
		public static readonly Int32 ALLOWANCE_PAYER_DIS_3RD = 1345; 
		public static readonly Int32 ALLOWANCE_PAYER_STUDYING = 335; 
		public static readonly Int32 ALLOWANCE_CHILD_RANK_1ST = 1117;
		public static readonly Int32 ALLOWANCE_CHILD_RANK_2ND = 1317;
		public static readonly Int32 ALLOWANCE_CHILD_RANK_3RD = 1417;
		public static readonly decimal FACTOR_ADVANCES = 15.0m; 
		public static readonly decimal FACTOR_WITHHOLD = 15.0m;
		public static readonly decimal FACTOR_SOLIDARY = 7.0m;
		public static readonly Int32 MIN_VALID_AMOUNT_OF_TAXBONUS = 50;
		public static readonly Int32 MAX_VALID_AMOUNT_OF_TAXBONUS = 5025;
		public static readonly Int32 MIN_INCOME_REQUIRED_FOR_TAXBONUS = 9200;
		public static readonly Int32 MAX_INCOME_APPLY_SINGELS_ROUNDING = 100;
		public static readonly Int32 MAX_INCOME_APPLY_WITHHOLD_TAX = 10000;
		public static readonly Int32 MIN_INCOME_APPLY_SOLIDARY_INCREASE = 106444;
	}
}

