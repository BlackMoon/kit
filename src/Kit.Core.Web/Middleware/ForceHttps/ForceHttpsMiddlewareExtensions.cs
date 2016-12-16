using System;
using Microsoft.AspNetCore.Builder;

namespace Kit.Core.Web.Middleware.ForceHttps
{
    public static class ForceHttpsMiddlewareExtensions
    {
        public static IApplicationBuilder UseForceHttps(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Middleware.ForceHttps.ForceHttpsMiddleware>();
        }

        public static IApplicationBuilder UseForceHttps(this IApplicationBuilder app, int securePort)
        {
            return app.UseMiddleware<Middleware.ForceHttps.ForceHttpsMiddleware>(securePort);
        }

        public static IApplicationBuilder UseForceHttps(this IApplicationBuilder app, ForceHttpsOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<Middleware.ForceHttps.ForceHttpsMiddleware>(options);
        }
    }
}
