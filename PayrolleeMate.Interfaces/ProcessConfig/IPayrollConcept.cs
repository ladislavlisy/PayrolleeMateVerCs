using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.EngineService.Interfaces;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessConfig.Interfaces
{
	public interface IPayrollConcept
	{
		SymbolName ConceptSymbol();

		uint ConceptCode();

		string ConceptName();

		string[] TargetValues();

		string[] ResultValues();

		IBookParty GetContractParty (IBookIndex element);

		IBookParty GetPositionParty (IBookIndex element);

		IBookParty[] GetTargetParties(IBookParty emptyNode, IBookParty[] contracts, IBookParty[] positions);

		IBookParty GetTargetParty (IBookParty lastParty);

		IBookParty GetNextTargetParty (IBookIndex lastIndex);

		IBookResult[] CallEvaluate (IProcessConfig config, IEngineProfile engine, 
			IPayrollArticle article, IBookIndex element, ITargetValues values, IResultStream results);
	}
}

