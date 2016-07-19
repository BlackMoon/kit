﻿using System;
using Microsoft.AspNetCore.Builder;

namespace Kit.Kernel.Web.ForceHttpsMiddleware
{
    public static class ForceHttpsMiddlewareExtentions
    {
        public static IApplicationBuilder UseForceHttps(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ForceHttpsMiddleware>();
        }

        public static IApplicationBuilder UseForceHttps(this IApplicationBuilder app, int securePort)
        {
            return app.UseMiddleware<ForceHttpsMiddleware>(securePort);
        }

        public static IApplicationBuilder UseForceHttps(this IApplicationBuilder app, ForceHttpsOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<ForceHttpsMiddleware>(options);
        }
    }
}
