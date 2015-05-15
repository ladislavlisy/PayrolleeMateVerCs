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
			string targetValues, string resultValues, EvaluateDelegate evaluate)
		{
			IPayrollConcept conceptInstance = new GeneralPayrollConcept (concept, 
				targetValues, resultValues, evaluate);

			return conceptInstance;
		}

		public GeneralPayrollConcept (SymbolName concept, 
			string targetValues, string resultValues, EvaluateDelegate evaluate) : base(concept.Code, concept.Name)
		{
			__targetValues = targetValues.Split(VALUES_SEPARATOR);

			__resultValues = resultValues.Split(VALUES_SEPARATOR);

			__evaluate = evaluate;

		}

		private string[] __targetValues;

		private string[] __resultValues;

		private EvaluateDelegate __evaluate = null;

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

