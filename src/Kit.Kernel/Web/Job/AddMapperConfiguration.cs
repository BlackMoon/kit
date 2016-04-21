using System;
using Kit.Kernel.CQRS.Job;
using Kit.Kernel.Web.Configuration;
using Mapster;
using Microsoft.Owin.Security.Cookies;

namespace Kit.Kernel.Web.Job
{
    public class AddMapperConfiguration : IStartupJob
    {
        public void Run()
        {
            TypeAdapterConfig<CookieAuthenticationConfiguration, CookieAuthenticationOptions>
                .NewConfig()
                .IgnoreNullValues(true)
                .Map(dest => dest.ExpireTimeSpan, src => TimeSpan.FromMinutes(src.TimeOut));
        }
    }
}
