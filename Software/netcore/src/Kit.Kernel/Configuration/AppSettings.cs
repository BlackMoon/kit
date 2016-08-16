using System.Collections.Generic;

namespace Kit.Kernel.Configuration
{
    public class AppSettings
    {
        /// <summary>
        /// autocomplete="on|off" для input type="password"
        /// </summary>
        public bool AutoComplete { get; set; }

        public string Theme { get; set; }

        public string Title { get; set; }

        public Dictionary<string, string> ErrorMessages { get; set; }
    }
}
