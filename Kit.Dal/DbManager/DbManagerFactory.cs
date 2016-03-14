using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Kit.Dal.DbManager;

[assembly: PreApplicationStartMethod(typeof(DbManagerFactory), "Start")]
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
        private static readonly IDictionary<string, Type> Managers = new Dictionary<string, Type>();

        public static Type GetDbManagerType(string providerName)
        {   
            return Managers.ContainsKey(providerName) ? Managers[providerName] : Managers.Values.FirstOrDefault();
        }

        public static void Start()
        {
            Func<Type, bool> pre = t => t.GetInterfaces().Contains(typeof(IDbManager));

            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Type t in assembly.GetTypes().Where(pre))
            {
                // Наименование --> из аттрибута
                ProviderNameAttribute attr = (ProviderNameAttribute) t.GetCustomAttribute(typeof (ProviderNameAttribute));
                if (attr != null)
                    Managers[attr.ProviderName] = t;
            }
        }
    }
}
