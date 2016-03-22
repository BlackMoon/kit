using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static IReadOnlyDictionary<string, Type> _managers;

        public static Type GetDbManagerType(string providerName)
        {
            Type t = null;

            if (_managers != null)
                t = _managers.ContainsKey(providerName) ? _managers[providerName] : _managers.Values.FirstOrDefault();

            return t;
        }

        public static void Start()
        {
            Func<Type, bool> pre = t => t.GetInterfaces().Contains(typeof(IDbManager));

            Assembly assembly = Assembly.GetExecutingAssembly();
            IDictionary <string, Type> managers = new Dictionary<string, Type>();
            foreach (Type t in assembly.GetTypes().Where(pre))
            {
                // Наименование --> из аттрибута
                ProviderNameAttribute attr = (ProviderNameAttribute) t.GetCustomAttribute(typeof (ProviderNameAttribute));
                if (attr != null)
                    managers[attr.ProviderName] = t;
            }
            _managers = new ReadOnlyDictionary<string, Type>(managers);
        }
    }
}
