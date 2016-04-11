using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace Kit.Kernel.Web.Configuration
{
    /// <summary>
    /// Параметры проверки подлинности cookie
    /// </summary>
    public class CookieAuthenticationSettings
    {
       // public string AccessDeniedPath { get; set; }

        public string CookieDomain { get; set; }

        public bool CookieHttpOnly { get; set; }

        public string CookieName { get; set; }

        public string CookiePath { get; set; }

        public int TimeOut { get; set; } = 30;

        //public string LoginPath { get; set; } = "a";

        //public string LogoutPath { get; set; }

        public bool SlidingExpiration { get; set; } = true;
    }
}
