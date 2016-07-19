using System;
using Castle.DynamicProxy;
using DryIoc;

namespace Kit.Kernel.Interception
{
    public static class DryIocInterceptionExtentions
    {
        public static void RegisterInterfaceInterceptor(this IRegistrator registrator, Type serviceType, Type interceptorType)
        {
            if (!serviceType.IsInterface)
                throw new ArgumentException($"Intercepted service type {serviceType} is not an interface");

            // Create proxy type for intercepted interface
            var proxyType = ProxyBuilder.Value.CreateInterfaceProxyTypeWithTargetInterface(
                serviceType, new Type[0], ProxyGenerationOptions.Default);

            // Register proxy as decorator
            registrator.Register(serviceType, proxyType,
                made: Parameters.Of.Type<IInterceptor[]>(interceptorType.MakeArrayType()),
                setup: Setup.Decorator);
        }

        public static void RegisterInterfaceInterceptor<TService, TInterceptor>(this IRegistrator registrator)
            where TInterceptor : class, IInterceptor
        {
            registrator.RegisterInterfaceInterceptor(typeof (TService), typeof (TInterceptor[]));

            var serviceType = typeof(TService);
            if (!serviceType.IsInterface)
                throw new ArgumentException($"Intercepted service type {serviceType} is not an interface");

            // Create proxy type for intercepted interface
            var proxyType = ProxyBuilder.Value.CreateInterfaceProxyTypeWithTargetInterface(
                serviceType, new Type[0], ProxyGenerationOptions.Default);

            // Register proxy as decorator
            registrator.Register(serviceType, proxyType,
                made: Parameters.Of.Type<IInterceptor[]>(typeof(TInterceptor[])),
                setup: Setup.Decorator);
        }

        private static readonly Lazy<DefaultProxyBuilder> ProxyBuilder = new Lazy<DefaultProxyBuilder>(() => new DefaultProxyBuilder());
    }
}