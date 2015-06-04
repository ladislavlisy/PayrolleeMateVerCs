using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface IBookTarget
	{
		IPayrollConcept Concept ();

		IPayrollArticle Article ();

		IBookIndex Element ();

		uint ArticleCode ();

		void InitValues(ITargetValues values);

		IResultStream Evaluate(IProcessConfig config, IEngineProfile engine, IResultStream results);

		IBookParty GetContractParty();

		IBookParty GetPositionParty();
	}
}

