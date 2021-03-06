﻿using System;

namespace PayrolleeMate.EngineService.Constants
{
	class TaxingProperties2011
	{
		public const uint YEAR_2011 = 2011;

		public const Int32 ALLOWANCE_PAYER_BASIC = 1970;
		public const Int32 ALLOWANCE_PAYER_DIS_1ST = 210; 
		public const Int32 ALLOWANCE_PAYER_DIS_2ND = 420;
		public const Int32 ALLOWANCE_PAYER_DIS_3RD = 1345; 
		public const Int32 ALLOWANCE_PAYER_STUDYING = 335; 
		public const Int32 ALLOWANCE_CHILD_RANK_1ST = 1117;
		public const Int32 ALLOWANCE_CHILD_RANK_2ND = 1117;
		public const Int32 ALLOWANCE_CHILD_RANK_3RD = 1117;
		public const decimal FACTOR_ADVANCES = 15.0m; 
		public const decimal FACTOR_WITHHOLD = 15.0m;
		public const decimal FACTOR_SOLIDARY = 0.0m;
		public const Int32 MIN_VALID_AMOUNT_OF_TAXBONUS = 50;
		public const Int32 MAX_VALID_AMOUNT_OF_TAXBONUS = 5025;
		public const Int32 MIN_INCOME_REQUIRED_FOR_TAXBONUS = 8000;
		public const Int32 MAX_INCOME_APPLY_SINGELS_ROUNDING = 100;
		public const Int32 MAX_INCOME_APPLY_WITHHOLD_TAX = 5000;
		public const Int32 MIN_INCOME_APPLY_SOLIDARY_INCREASE = 0;
	}

	class TaxingProperties2012
	{
		public const uint YEAR_2012 = 2012;

		public const Int32 ALLOWANCE_PAYER_BASIC = 2070;
		public const Int32 ALLOWANCE_PAYER_DIS_1ST = TaxingProperties2011.ALLOWANCE_PAYER_DIS_1ST; 
		public const Int32 ALLOWANCE_PAYER_DIS_2ND = TaxingProperties2011.ALLOWANCE_PAYER_DIS_2ND;
		public const Int32 ALLOWANCE_PAYER_DIS_3RD = TaxingProperties2011.ALLOWANCE_PAYER_DIS_3RD; 
		public const Int32 ALLOWANCE_PAYER_STUDYING = TaxingProperties2011.ALLOWANCE_PAYER_STUDYING;
		public const Int32 ALLOWANCE_CHILD_RANK_1ST = TaxingProperties2011.ALLOWANCE_CHILD_RANK_1ST;
		public const Int32 ALLOWANCE_CHILD_RANK_2ND = TaxingProperties2011.ALLOWANCE_CHILD_RANK_2ND;
		public const Int32 ALLOWANCE_CHILD_RANK_3RD = TaxingProperties2011.ALLOWANCE_CHILD_RANK_3RD;
		public const decimal FACTOR_ADVANCES = TaxingProperties2011.FACTOR_ADVANCES;
		public const decimal FACTOR_WITHHOLD = TaxingProperties2011.FACTOR_WITHHOLD;
		public const decimal FACTOR_SOLIDARY = TaxingProperties2011.FACTOR_SOLIDARY;
		public const Int32 MIN_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2011.MIN_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MAX_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2011.MAX_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MIN_INCOME_REQUIRED_FOR_TAXBONUS = TaxingProperties2011.MIN_INCOME_REQUIRED_FOR_TAXBONUS;
		public const Int32 MAX_INCOME_APPLY_SINGELS_ROUNDING = TaxingProperties2011.MAX_INCOME_APPLY_SINGELS_ROUNDING;
		public const Int32 MAX_INCOME_APPLY_WITHHOLD_TAX = TaxingProperties2011.MAX_INCOME_APPLY_WITHHOLD_TAX;
		public const Int32 MIN_INCOME_APPLY_SOLIDARY_INCREASE = TaxingProperties2011.MIN_INCOME_APPLY_SOLIDARY_INCREASE;
	}

	class TaxingProperties2013
	{
		public const uint YEAR_2013 = 2013;

		public const Int32 ALLOWANCE_PAYER_BASIC = TaxingProperties2012.ALLOWANCE_PAYER_BASIC;
		public const Int32 ALLOWANCE_PAYER_DIS_1ST = TaxingProperties2012.ALLOWANCE_PAYER_DIS_1ST; 
		public const Int32 ALLOWANCE_PAYER_DIS_2ND = TaxingProperties2012.ALLOWANCE_PAYER_DIS_2ND;
		public const Int32 ALLOWANCE_PAYER_DIS_3RD = TaxingProperties2012.ALLOWANCE_PAYER_DIS_3RD; 
		public const Int32 ALLOWANCE_PAYER_STUDYING = TaxingProperties2012.ALLOWANCE_PAYER_STUDYING;
		public const Int32 ALLOWANCE_CHILD_RANK_1ST = TaxingProperties2012.ALLOWANCE_CHILD_RANK_1ST;
		public const Int32 ALLOWANCE_CHILD_RANK_2ND = TaxingProperties2012.ALLOWANCE_CHILD_RANK_2ND;
		public const Int32 ALLOWANCE_CHILD_RANK_3RD = TaxingProperties2012.ALLOWANCE_CHILD_RANK_3RD;
		public const decimal FACTOR_ADVANCES = TaxingProperties2012.FACTOR_ADVANCES;
		public const decimal FACTOR_WITHHOLD = TaxingProperties2012.FACTOR_WITHHOLD;
		public const decimal FACTOR_SOLIDARY = 7.0m;
		public const Int32 MIN_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2012.MIN_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MAX_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2012.MAX_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MIN_INCOME_REQUIRED_FOR_TAXBONUS = TaxingProperties2012.MIN_INCOME_REQUIRED_FOR_TAXBONUS;
		public const Int32 MAX_INCOME_APPLY_SINGELS_ROUNDING = TaxingProperties2012.MAX_INCOME_APPLY_SINGELS_ROUNDING;
		public const Int32 MAX_INCOME_APPLY_WITHHOLD_TAX = TaxingProperties2012.MAX_INCOME_APPLY_WITHHOLD_TAX;
		public const Int32 MIN_INCOME_APPLY_SOLIDARY_INCREASE = 103536;
	}

	class TaxingProperties2014
	{
		public const uint YEAR_2014 = 2014;

		public const Int32 ALLOWANCE_PAYER_BASIC = TaxingProperties2013.ALLOWANCE_PAYER_BASIC;
		public const Int32 ALLOWANCE_PAYER_DIS_1ST = TaxingProperties2013.ALLOWANCE_PAYER_DIS_1ST; 
		public const Int32 ALLOWANCE_PAYER_DIS_2ND = TaxingProperties2013.ALLOWANCE_PAYER_DIS_2ND;
		public const Int32 ALLOWANCE_PAYER_DIS_3RD = TaxingProperties2013.ALLOWANCE_PAYER_DIS_3RD; 
		public const Int32 ALLOWANCE_PAYER_STUDYING = TaxingProperties2013.ALLOWANCE_PAYER_STUDYING;
		public const Int32 ALLOWANCE_CHILD_RANK_1ST = TaxingProperties2013.ALLOWANCE_CHILD_RANK_1ST;
		public const Int32 ALLOWANCE_CHILD_RANK_2ND = TaxingProperties2013.ALLOWANCE_CHILD_RANK_2ND;
		public const Int32 ALLOWANCE_CHILD_RANK_3RD = TaxingProperties2013.ALLOWANCE_CHILD_RANK_3RD;
		public const decimal FACTOR_ADVANCES = TaxingProperties2013.FACTOR_ADVANCES;
		public const decimal FACTOR_WITHHOLD = TaxingProperties2013.FACTOR_WITHHOLD;
		public const decimal FACTOR_SOLIDARY = TaxingProperties2013.FACTOR_SOLIDARY;
		public const Int32 MIN_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2013.MIN_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MAX_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2013.MAX_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MIN_INCOME_REQUIRED_FOR_TAXBONUS = 8500;
		public const Int32 MAX_INCOME_APPLY_SINGELS_ROUNDING = TaxingProperties2013.MAX_INCOME_APPLY_SINGELS_ROUNDING;
		public const Int32 MAX_INCOME_APPLY_WITHHOLD_TAX = 10000;
		public const Int32 MIN_INCOME_APPLY_SOLIDARY_INCREASE = 103768;
	}

	class TaxingProperties2015
	{
		public const uint YEAR_2015 = 2015;

		public const Int32 ALLOWANCE_PAYER_BASIC = TaxingProperties2014.ALLOWANCE_PAYER_BASIC;
		public const Int32 ALLOWANCE_PAYER_DIS_1ST = TaxingProperties2014.ALLOWANCE_PAYER_DIS_1ST; 
		public const Int32 ALLOWANCE_PAYER_DIS_2ND = TaxingProperties2014.ALLOWANCE_PAYER_DIS_2ND;
		public const Int32 ALLOWANCE_PAYER_DIS_3RD = TaxingProperties2014.ALLOWANCE_PAYER_DIS_3RD; 
		public const Int32 ALLOWANCE_PAYER_STUDYING = TaxingProperties2014.ALLOWANCE_PAYER_STUDYING; 
		public const Int32 ALLOWANCE_CHILD_RANK_1ST = TaxingProperties2014.ALLOWANCE_CHILD_RANK_1ST;
		public const Int32 ALLOWANCE_CHILD_RANK_2ND = 1317;
		public const Int32 ALLOWANCE_CHILD_RANK_3RD = 1417;
		public const decimal FACTOR_ADVANCES = TaxingProperties2014.FACTOR_ADVANCES; 
		public const decimal FACTOR_WITHHOLD = TaxingProperties2014.FACTOR_WITHHOLD;
		public const decimal FACTOR_SOLIDARY = TaxingProperties2014.FACTOR_SOLIDARY;
		public const Int32 MIN_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2014.MIN_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MAX_VALID_AMOUNT_OF_TAXBONUS = TaxingProperties2014.MAX_VALID_AMOUNT_OF_TAXBONUS;
		public const Int32 MIN_INCOME_REQUIRED_FOR_TAXBONUS = 9200;
		public const Int32 MAX_INCOME_APPLY_SINGELS_ROUNDING = TaxingProperties2014.MAX_INCOME_APPLY_SINGELS_ROUNDING;
		public const Int32 MAX_INCOME_APPLY_WITHHOLD_TAX = TaxingProperties2014.MAX_INCOME_APPLY_WITHHOLD_TAX;
		public const Int32 MIN_INCOME_APPLY_SOLIDARY_INCREASE = 106444;
	}
}

