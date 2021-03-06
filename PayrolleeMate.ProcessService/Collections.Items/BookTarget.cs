using System;
using PayrolleeMate.ProcessService.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.ProcessService.Collection.Items
{
	public class BookTarget : IBookTarget
	{
		public BookTarget(IBookIndex bookElement, IPayrollArticle bookArticle, IPayrollConcept bookConcept, ITargetValues bookValues)
		{
			__element = bookElement;

			__article = bookArticle;

			__concept = bookConcept;

			__values = bookValues;
		}

		private IBookIndex __element = null;

		private IPayrollConcept __concept = null;

		private IPayrollArticle __article = null;

		private ITargetValues __values = null; 

		#region IBookTarget implementation

		public IBookIndex Element()
		{
			return __element;
		}

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
		public IBookResult[] Evaluate (IProcessConfig config, IEngineProfile engine, IResultStream results)
		{
			return __concept.CallEvaluate(config, engine, __article, __element, __values, results);
		}
		public IBookParty GetContractParty ()
		{
			return __concept.GetContractParty (__element);
		}
		public IBookParty GetPositionParty ()
		{
			return __concept.GetPositionParty (__element);
		}
		#endregion
	}

}

