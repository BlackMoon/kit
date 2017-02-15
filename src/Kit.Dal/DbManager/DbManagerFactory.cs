using System;
using System.Collections.Generic;
using System.IO;
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
            // Register assemblies
            string contentRootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string[] assemblies = (contentRootPath != null) ? 
                Directory.GetFiles(contentRootPath, "Kit.Dal.*.dll", SearchOption.TopDirectoryOnly) : 
                new string[]{};

            Func<Type, bool> pre = t => t.GetInterfaces().Contains(typeof(IDbManager));
            Managers = new Dictionary<string, Type>();

            foreach (string a in assemblies)
            {

#if NETCOREAPP1_0
                Assembly assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(a);
#endif
#if NET46
                Assembly assembly = Assembly.LoadFrom(a);
#endif
                foreach (Type t in assembly.GetTypes().Where(pre))
                {
                    // Наименование --> из аттрибута
                    ProviderNameAttribute attr = null;
#if NETCOREAPP1_0
                    attr = (ProviderNameAttribute)t.GetTypeInfo().GetCustomAttribute(typeof(ProviderNameAttribute));
#endif
#if NET46
                    attr = (ProviderNameAttribute)t.GetCustomAttribute(typeof(ProviderNameAttribute));
#endif
                    if (attr != null)
                        Managers[attr.ProviderName] = t;
                }
            }
        }

        public static IDbManager CreateDbManager(string providerName, string connectionString = null)
        {
            IDbManager dbManager;

            Type t = null;
            Managers?.TryGetValue(providerName, out t);

            if (t != null)
            {
                dbManager = (IDbManager) Activator.CreateInstance(t);
                dbManager.ConnectionString = connectionString;
            }
            else
                throw new TypeLoadException($"Provider {providerName} not found.");

            return dbManager;
        }
    }
}
