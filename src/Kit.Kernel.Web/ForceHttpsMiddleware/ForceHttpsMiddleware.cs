﻿using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace Kit.Kernel.Web.ForceHttpsMiddleware
{
    public class ForceHttpsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ForceHttpsOptions _options;

        public ForceHttpsMiddleware(RequestDelegate next) : this(next, new ForceHttpsOptions())
        {
        }

        public ForceHttpsMiddleware(RequestDelegate next, int securePort) : this(next, new ForceHttpsOptions() { SecurePort = securePort })
        {
        }

        public ForceHttpsMiddleware(RequestDelegate next, ForceHttpsOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpRequest request = context.Request;
            bool callRedirect = !request.IsHttps && (_options.Paths.Count == 0 || _options.Paths.Contains(request.Path)); 

            if (callRedirect)
            {
                string host = request.Host.ToString();
                int pos = host.IndexOf(':');
                if (pos == -1)
                    pos = host.Length - 1;

                var httpsUrl = $"https://{host.Substring(0, pos)}:{_options.SecurePort}{request.Path}{request.QueryString}";
                context.Response.Redirect(httpsUrl);
            }

            await _next.Invoke(context);
        }
    }
}
