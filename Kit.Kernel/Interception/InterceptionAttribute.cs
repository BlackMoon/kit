using System;

namespace Kit.Kernel.Interception
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class InterceptionAttribute : Attribute
    {
        public abstract void Intercept(Action action);
    }
}