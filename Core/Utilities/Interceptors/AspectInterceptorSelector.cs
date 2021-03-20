using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector:IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttribute = type.GetCustomAttributes<MethodInterception>(true).ToList();
            var methodAttribute=type.GetMethod(method.Name).GetCustomAttributes<MethodInterception>(true).ToList();
            classAttribute.AddRange(methodAttribute);
            return classAttribute.OrderBy(a=>a.Priority).ToArray();
        }
    }
}
