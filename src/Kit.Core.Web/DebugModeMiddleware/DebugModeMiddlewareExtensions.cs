using Microsoft.AspNetCore.Builder;

namespace Kit.Core.Web.DebugModeMiddleware
{
    public static class DebugModetMiddlewareExtentions
    {
        public static IApplicationBuilder CheckDebugMode(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DebugModeMiddleware>();
        }
    }
}
