using System;
using Microsoft.AspNet.Http;

namespace Kit.Kernel.Web.Configuration
{
    /// <summary>
    /// Параметры проверки подлинности [authrntication mode=forms/cookie]
    /// </summary>
    public class CookieAuthenticationConfiguration
    {
        public string AccessDeniedPath { get; set; }

        public string CookieDomain { get; set; }

        public bool CookieHttpOnly { get; set; }

        public string CookieName { get; set; }

        public string CookiePath { get; set; }

        public int TimeOut { get; set; } = 20;

        public string LoginPath { get; set; }

        public string LogoutPath { get; set; }

        public bool SlidingExpiration { get; set; } = true;
    }
}
