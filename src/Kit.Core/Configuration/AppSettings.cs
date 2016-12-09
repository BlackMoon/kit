using System.Collections.Generic;

namespace Kit.Core.Configuration
{
    public class AppSettings
    {
        /// <summary>
        /// autocomplete="on|off" для input type="password"
        /// </summary>
        public bool AutoComplete { get; set; }

        /// <summary>
        /// Тема приложения
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Заголовок приложения
        /// </summary>
        public string Title { get; set; }

        // ReSharper disable once CollectionNeverUpdated.Global
        public Dictionary<string, string> ErrorMessages { get; set; }
    }
}
