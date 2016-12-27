using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DryIoc;
using Kit.Core.CQRS.Command;
using Kit.Core.CQRS.Job;
using Kit.Core.CQRS.Query;
using Kit.Core.Interception;
using Kit.Core.Interception.Attribute;
using Microsoft.Extensions.DependencyInjection;
using DryIoc.AspNetCore.DependencyInjection;

namespace Kit.Core
{
    public class DryIocStartup
    {
        /// <summary>
        /// Регистрация сборок в DryIoc-контейнере 
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="assemblies">Список сборок</param>
        /// <returns>IContainer</returns>
        protected IContainer ConfigureDependencies(IServiceCollection services, params string[] assemblies)
        {
            // Register assemblies
            IEnumerable<AssemblyName> assemblyNames = Assembly.GetEntryAssembly()
                .GetReferencedAssemblies()
                .Where(a => assemblies.Length == 0 || assemblies.Contains(a.Name))
                .ToList();

            IList<Assembly> implTypeAssemblies = new List<Assembly>(assemblyNames.Count());
            foreach (AssemblyName an in assemblyNames)
            {
                implTypeAssemblies.Add(Assembly.Load(an));
            }

            IContainer container = new Container().WithDependencyInjectionAdapter(services);
            container.RegisterMany(implTypeAssemblies, (registrator, types, type) =>
            {
                IgnoreRegistrationAttribute ignoreAttr = (IgnoreRegistrationAttribute)type.GetCustomAttribute(typeof(IgnoreRegistrationAttribute));
                if (ignoreAttr == null)
                {
                    // all dispatchers --> Reuse.InCurrentScope
                    IReuse reuse = type.IsAssignableTo(typeof (ICommandDispatcher)) ||
                                   type.IsAssignableTo(typeof (IJobDispatcher)) ||
                                   type.IsAssignableTo(typeof (IQueryDispatcher))
                        ? Reuse.InCurrentScope
                        : Reuse.Transient;

                    registrator.RegisterMany(types, type, reuse);

                    // interceptors
                    if (type.IsClass)
                    {
                        InterceptedObjectAttribute attr = (InterceptedObjectAttribute)type.GetCustomAttribute(typeof(InterceptedObjectAttribute));
                        if (attr != null)
                        {
                            Type serviceType = attr.ServiceInterfaceType ?? type.GetImplementedInterfaces().FirstOrDefault();
                            registrator.RegisterInterfaceInterceptor(serviceType, attr.InterceptorType);
                        }
                    }
                }
            });

            return container;
        }
    }
}
