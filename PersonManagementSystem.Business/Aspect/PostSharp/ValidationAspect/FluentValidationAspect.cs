using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PersonManagementSystem.Business.CrossCuttingConcern.Validation.FluentValidation;
using PostSharp.Aspects;

namespace PersonManagementSystem.Business.Aspect.PostSharp.ValidationAspect
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //validation tools abstack product olan yer
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //validate edilicek yer Product product tipi olanları getir
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
