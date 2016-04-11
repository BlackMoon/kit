using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Kit.Kernel.Web.Identity
{
    public class MasterSignInManager : SignInManager<User, DateTime>
    {
        public MasterSignInManager(UserManager<User, DateTime> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }
    }
}
