using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest()
        {
            //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "KPI"),
                    new Claim("Password", "KPI"),
                    new Claim("Server", "aql.kpi")
                };

                System.Web.HttpContext.Current.User = new ClaimsPrincipal(new ClaimsIdentity(claims));
            }
        }
    }
}
