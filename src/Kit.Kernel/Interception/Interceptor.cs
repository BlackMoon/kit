using Castle.DynamicProxy;

namespace Kit.Kernel.Interception
{
    public abstract class Interceptor : IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
