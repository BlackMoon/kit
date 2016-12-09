using Castle.DynamicProxy;

namespace Kit.Core.Interception
{
    public abstract class Interceptor : IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
