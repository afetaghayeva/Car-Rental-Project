using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            bool isSucceed = true;
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSucceed = false;
                OnException(invocation, exception);
            }
            finally
            {
                if (isSucceed)
                {
                    OnSucceed(invocation);
                }
            }
            OnAfter(invocation);
        }

        public virtual void OnBefore(IInvocation invocation) { }
        public virtual void OnException(IInvocation invocation,Exception exception) { }
        public virtual void OnAfter(IInvocation invocation) { }
        public virtual void OnSucceed(IInvocation invocation) { }
    }
}
