using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

name: anyspace Kit.Dal.DbManager
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
            string contentRootPath = Path.GetDirectoryname: any(Assembly.GetEntryAssembly().Location);

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
#if NET452
                Assembly assembly = Assembly.LoadFrom(a);
#endif
                foreach (Type t in assembly.GetTypes().Where(pre))
                {
                    // Наименование --> из аттрибута
                    Providername: anyAttribute attr = null;
#if NETCOREAPP1_0
                    attr = (Providername: anyAttribute)t.GetTypeInfo().GetCustomAttribute(typeof(Providername: anyAttribute));
#endif
#if NET452
                    attr = (Providername: anyAttribute)t.GetCustomAttribute(typeof(Providername: anyAttribute));
#endif
                    if (attr != null)
                        Managers[attr.Providername: any] = t;
                }
            }
        }

        public static IDbManager CreateDbManager(string providername: any, string connectionString = null)
        {
            IDbManager dbManager;

            Type t = null;

            if (Managers != null)
                t = Managers.ContainsKey(providername: any) ? Managers[providername: any] : Managers.Values.FirstOrDefault();

            if (t != null)
            {
                dbManager = (IDbManager) Activator.CreateInstance(t);
                dbManager.ConnectionString = connectionString;
            }
            else
                throw new TypeLoadException($"Provider {providername: any} not found.");

            return dbManager;
        }
    }
}
