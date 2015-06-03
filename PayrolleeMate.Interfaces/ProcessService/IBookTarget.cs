using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookTarget
	{
		IPayrollConcept Concept ();

		IPayrollArticle Article ();

		uint ArticleCode ();

		void InitValues(ITargetValues values);

		IResultStream Evaluate(IProcessConfig config, IEngineProfile engine, IBookIndex token, IResultStream results);

		IBookParty GetContractParty();

		IBookParty GetPositionParty();

		IBookParty[] GetTargetParties(IBookParty[] contracts, IBookParty[] positions);
	}
}

