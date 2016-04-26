using Microsoft.Owin.Security.Cookies;

namespace Kit.Kernel.Web.Configuration
{
    /// <summary>
    /// Параметры проверки подлинности [authentication mode=forms/cookie]
    /// </summary>
    public class CookieAuthenticationConfiguration
    {
        public string AccessDeniedPath { get; set; }

        public string CookieDomain { get; set; }

        public bool CookieHttpOnly { get; set; }

        public string CookieName { get; set; } = CookieAuthenticationDefaults.CookiePrefix + CookieAuthenticationDefaults.AuthenticationType;

        public string CookiePath { get; set; }

        public int TimeOut { get; set; } = 20;

        public string LoginPath { get; set; }

        public string LogoutPath { get; set; }

        public bool SlidingExpiration { get; set; } = true;
    }
}
