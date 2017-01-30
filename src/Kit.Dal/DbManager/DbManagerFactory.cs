using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kit.Dal.DbManager
{
    /// <summary>
    /// Фабрика типов DbManager
    /// </summary>
    public static class DbManagerFactory
    {
        /// <summary>
        /// Словарь соответвий [наименование провайдера - тип DbManager'a] 
        /// </summary>
        private static readonly IDictionary<string, Type> Managers;

        static DbManagerFactory()
        {
            Func<Type, bool> pre = t => t.GetInterfaces().Contains(typeof(IDbManager));

            IEnumerable<AssemblyName> assemblyNames = Assembly.GetEntryAssembly()
                .GetReferencedAssemblies()
                .Where(a => a.Name.StartsWith("Kit.Dal.", StringComparison.OrdinalIgnoreCase));

            Managers = new Dictionary<string, Type>();

            foreach (AssemblyName a in assemblyNames)
            {
                Assembly assembly = Assembly.Load(a);
                foreach (Type t in assembly.GetTypes().Where(pre))
                {
                    // Наименование --> из аттрибута
                    ProviderNameAttribute attr = null;
#if NETCOREAPP1_0
                    attr = (ProviderNameAttribute)t.GetTypeInfo().GetCustomAttribute(typeof(ProviderNameAttribute));
#endif
#if NET452
                    attr = (ProviderNameAttribute)t.GetCustomAttribute(typeof(ProviderNameAttribute));
#endif
                    if (attr != null)
                        Managers[attr.ProviderName] = t;
                }

            }
        }

        public static IDbManager CreateDbManager(string providerName, string connectionString = null)
        {
            IDbManager dbManager = null;

            Type t = null;

            if (Managers != null)
                t = Managers.ContainsKey(providerName) ? Managers[providerName] : Managers.Values.FirstOrDefault();

            if (t != null)
            {
                dbManager = (IDbManager) Activator.CreateInstance(t);
                dbManager.ConnectionString = connectionString;
            }

            return dbManager;
        }
    }
}
