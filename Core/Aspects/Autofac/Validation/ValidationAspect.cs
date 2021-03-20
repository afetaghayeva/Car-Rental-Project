using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using Activator = System.Activator;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            base.Priority = 1;
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("This is not validator");
            }

            _validatorType = validatorType;
        }
        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GenericTypeArguments[0];
            var entities = invocation.Arguments.Where(arg => arg.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.FluentValidate(validator,entity);
            }
            
        }
    }
}
