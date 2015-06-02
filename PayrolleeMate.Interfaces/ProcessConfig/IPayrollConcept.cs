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

		IBookParty[] GetTargetParties(IBookParty[] contracts, IBookParty[] positions);

		IResultStream CallEvaluate (IProcessConfig config, IEngineProfile engine, IBookIndex element, IResultStream results);
	}
}

