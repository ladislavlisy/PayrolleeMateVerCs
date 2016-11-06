# PayrolleeMateVerCs
PayrolleeMate C#

## PayrolleeMate.EngineService

### EngineProfile
- MonthPeriod 
- IPeriodEngine
- ITaxingEngine
- IHealthEngine
- ISocialEngine

### EngineServiceModule
- IEnginesHistory<IPeriodEngine> HistoryOfPeriod
- IEnginesHistory<ITaxingEngine> HistoryOfTaxing
- IEnginesHistory<IHealthEngine> HistoryOfHealth
- IEnginesHistory<ISocialEngine> HistoryOfSocial

### HealthEngine2011 : HealthEnginePrototype

### TaxingGuides : EngineGeneralGuides, ITaxingGuides

### TaxingProperties
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
