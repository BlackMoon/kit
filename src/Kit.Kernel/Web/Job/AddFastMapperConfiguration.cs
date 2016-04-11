using System;
using Kit.Kernel.CQRS.Job;
using Kit.Kernel.Web.Configuration;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace Kit.Kernel.Web.Job
{
    public class AddFastMapperConfiguration : IStartupJob
    {
        public void Run()
        {
            FastMapper.TypeAdapterConfig<CookieAuthenticationSettings, CookieAuthenticationOptions>
                .NewConfig()
                //.MapFrom(dest => dest.LoginPath, src => new PathString())
                //.MapFrom(dest => dest.LogoutPath, src => new PathString(src.LogoutPath))
                .MapFrom(dest => dest.ExpireTimeSpan, src => TimeSpan.FromMinutes(src.TimeOut));
        }
    }
}
