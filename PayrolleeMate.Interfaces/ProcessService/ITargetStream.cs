using System;
using System.Collections.Generic;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.Common;

namespace PayrolleeMate.ProcessService.Interfaces
{
	public interface ITargetStream
	{
		IDictionary<IBookIndex, IBookTarget> Targets ();

		ITargetStream AddNewContractsTarget (SymbolName article, ITargetValues values, IProcessConfig config);
		ITargetStream AddNewPositionsTarget (SymbolName article, ITargetValues values, IProcessConfig config);
		ITargetStream AddTargetIntoContract (SymbolName article, ITargetValues values, IProcessConfig config);
		ITargetStream AddTargetIntoPosition (SymbolName article, ITargetValues values, IProcessConfig config);
		ITargetStream AddTargetIntoSumLevel (SymbolName article, ITargetValues values, IProcessConfig config);

		ITargetStream CreateEvaluationStream (IProcessConfig configModule);
	}
}

