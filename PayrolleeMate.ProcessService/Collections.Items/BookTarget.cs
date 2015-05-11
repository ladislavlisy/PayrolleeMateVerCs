using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;

namespace PayrolleeMate.ProcessService.Collection.Items
{
	public class BookTarget : IBookTarget
	{
		public BookTarget(IBookIndex bookIndex, IPayrollArticle bookArticle, IPayrollConcept bookConcept, ITargetValues values)
		{
			targetKey = bookIndex;

			__article = bookArticle;

			__concept = bookConcept;
		}

		private IBookIndex targetKey = null;

		private IPayrollConcept __concept = null;

		private IPayrollArticle __article = null;


		#region IBookTarget implementation

		public IPayrollConcept Concept ()
		{
			return __concept;
		}
		public IPayrollArticle Article ()
		{
			return __article;
		}
		public uint ArticleCode ()
		{
			if (__article == null) 
			{
				return (uint)ArticleSymbolCode.ARTICLE_UNKNOWN;
			}
			return __article.ArticleCode();
		}
		public void InitValues (ITargetValues values)
		{
			throw new NotImplementedException ();
		}
		public IResultStream Evaluate (IProcessConfig config, PayrolleeMate.EngineService.Interfaces.IEngineProfile engine, IBookIndex token, IResultStream results)
		{
			throw new NotImplementedException ();
		}
		public IBookParty GetContractParty (IBookIndex bookToken)
		{
			throw new NotImplementedException ();
		}
		public IBookParty GetPositionParty (IBookIndex bookToken)
		{
			throw new NotImplementedException ();
		}
		public IBookParty[] GetTargetParties (IBookParty[] contracts, IBookParty[] positions)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}

}

