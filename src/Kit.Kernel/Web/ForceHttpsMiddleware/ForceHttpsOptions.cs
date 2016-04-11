using System.Collections.Generic;

namespace Kit.Kernel.Web.ForceHttpsMiddleware
{
    /// <summary>
    /// Настройки HTTPS REDIRECT
    /// </summary>
    public class ForceHttpsOptions
    {
        /// <summary>
        /// HTTPS port
        /// </summary>
        public int SecurePort { get; set; } = 443;

        /// <summary>
        /// Обязятельные url для проверки 
        /// </summary>
        public IList<string> Paths { get; set; } = new List<string>();
    }
}
