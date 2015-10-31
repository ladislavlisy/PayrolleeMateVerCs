using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using PayrolleeMate.Common.Core;
using PayrolleeMate.Common.Collection;
using PayrolleeMate.ProcessConfig.Constants;
using PayrolleeMate.ProcessConfig.Interfaces;
using PayrolleeMate.ProcessConfig.Factories;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessConfig.General;
using PayrolleeMate.ProcessConfig.Builders;
using PayrolleeMate.Common.Interfaces;

namespace PayrolleeMate.ProcessConfig.Collections
{
	public abstract class PayrollConceptCollection<CIDX> : GeneralCollection<IPayrollConcept, CIDX>
	{
		public PayrollConceptCollection() : base()
		{
		}

		#region Concept Dictionary

		public IPayrollConcept ArticleConceptFromModels(Assembly configAssembly, IPayrollArticle article)
		{
			IPayrollConcept baseConcept = ConceptFromModels(configAssembly, article.ConceptCode());

			return baseConcept;
		}

		public IPayrollConcept ConceptFromModels(Assembly configAssembly, uint conceptCode)
		{
			IPayrollConcept baseConcept = InstanceFromModels(configAssembly, conceptCode);

			return baseConcept;
		}

		public IPayrollConcept FindConcept(uint conceptCode)
		{
			IPayrollConcept baseConcept = FindInstanceForCode(conceptCode);

			return baseConcept;
		}

		public IPayrollConcept ConfigureConcept (SymbolName concept, 
			bool nodeContract, bool nodePosition, bool qualContract, bool qualPosition,
			string targetValues, string resultValues, 
			GeneralModule.EvaluateDelegate evaluate)
		{
			IPayrollConcept conceptInstance = GeneralPayrollConcept.CreateConcept (
				concept, nodeContract, nodePosition, qualContract, qualPosition,
				targetValues, resultValues, evaluate);

			return ConfigureModel (conceptInstance, concept.Code);
		}

		#endregion


		#region implemented abstract members of GeneralCollection

		protected override IPayrollConcept InstanceFor (Assembly configAssembly, SymbolName configSymbol)
		{
			IPayrollConcept emptyConcept = PayrollConceptFactory.ConceptFor(configAssembly, configSymbol.Name);

			return emptyConcept;
		}

		#endregion

	}
}

