﻿using System;
using PayrolleeMate.Common.Core;
using PayrolleeMate.ProcessConfig.Constants;
using System.Collections.Generic;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IProcessConfig
	{
		IPayrollArticle FindArticle(uint articleCode);

		IPayrollConcept FindConcept(uint conceptCode);

		IPayrollArticle[] ArticleList();

		IDictionary<uint, IPayrollArticle> ArticleModels ();

		IPayrollConcept[] ConceptList();

		IDictionary<uint, IPayrollConcept> ConceptModels ();

		IPayrollArticle ConfigureArticle (SymbolName article, 
			SymbolName concept, ProcessCategory category, 
			SymbolName[] pendingNames, SymbolName[] summaryNames,
			bool taxingIncome, bool healthIncome, bool socialIncome, 
			bool grossSummary, bool nettoSummary, bool nettoDeducts);

		void InitModule();
	}
}

