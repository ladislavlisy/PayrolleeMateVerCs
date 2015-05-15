using System;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IProcessConfig
	{
		IPayrollArticle FindArticle(uint articleCode);

		IPayrollConcept FindConcept(uint conceptCode);

		IPayrollArticle ConfigureArticle (SymbolName article, 
			SymbolName concept, ProcessCategory category, 
			SymbolName[] pendingNames, SymbolName[] summaryNames,
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts);

		void InitModule();
	}
}

