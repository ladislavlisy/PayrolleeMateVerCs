using System;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.Common;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.EngineService.Interfaces;

namespace PayrolleeMate.ProcessConfig.General
{
	public class GeneralPayrollConcept : SymbolName, IPayrollConcept
	{
		public delegate IResultStream EvaluateDelegate (IProcessConfig config, IEngineProfile engine, IBookIndex element, IResultStream results);

		public static readonly char[] VALUES_SEPARATOR = { ',' };

		public static IPayrollConcept CreateConcept (SymbolName concept, 
			bool nodeContract, bool nodePosition, bool qualContract, bool qualPosition,
			string targetValues, string resultValues, EvaluateDelegate evaluate)
		{
			IPayrollConcept conceptInstance = new GeneralPayrollConcept (concept, 
				nodeContract, nodePosition,	qualContract, qualPosition, targetValues, resultValues, evaluate);

			return conceptInstance;
		}

		public GeneralPayrollConcept (SymbolName concept, 
			bool nodeContract, bool nodePosition, bool qualContract, bool qualPosition,
			string targetValues, string resultValues, EvaluateDelegate evaluate) : base(concept.Code, concept.Name)
		{
			__contractNode = nodeContract;

			__positionNode = nodePosition;

			__contractQual = qualContract;

			__positionQual = qualPosition;

			__targetValues = targetValues.Split(VALUES_SEPARATOR);

			__resultValues = resultValues.Split(VALUES_SEPARATOR);

			__evaluate = evaluate;

		}

		private string[] __targetValues;

		private string[] __resultValues;

		private EvaluateDelegate __evaluate = null;

		private bool __contractNode = false;

		private bool __positionNode = false;

		private bool __contractQual = false;

		private bool __positionQual = false;

		#region IPayrollConcept implementation

		public SymbolName ConceptSymbol()
		{
			return (SymbolName) this;
		}

		public uint ConceptCode ()
		{
			return this.Code;
		}

		public string ConceptName ()
		{
			return this.Name;
		}

		public string[] TargetValues ()
		{
			return __targetValues;
		}

		public string[] ResultValues ()
		{
			return __resultValues;
		}

		public IBookParty GetContractParty (IBookIndex element)
		{
			if (__positionNode == false && __contractNode == true) 
			{
				return element.GetNewContractParty (element.CodeOrder ());
			}
			return null;
		}

		public IBookParty GetPositionParty (IBookIndex element)
		{
			if (__positionNode == true) 
			{
				return element.GetNewPositionParty (element.CodeOrder ());
			}
			return null;
		}

		public IBookParty[] GetTargetParties (IBookParty emptyNode, IBookParty[] contracts, IBookParty[] positions)
		{
			if (__positionQual == true) 
			{
				return positions;
			}
			if (__contractQual == true) 
			{
				return contracts;
			}
			return new IBookParty[] { emptyNode };
		}

		public virtual IResultStream CallEvaluate(IProcessConfig config, IEngineProfile engine, IBookIndex element, IResultStream results)
		{
			if (__evaluate != null)
			{
				return __evaluate (config, engine, element, results);
			}
			return results;
		}
		#endregion
	}
}

