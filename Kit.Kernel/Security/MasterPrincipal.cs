using System.Security.Claims;
using System.Security.Principal;

namespace Kit.Kernel.Security
{
    /// <summary>
    /// ClaimsPrincipal со свойством [ConnectionString]
    /// </summary>
    public class MasterPrincipal : ClaimsPrincipal
    {
        public MasterPrincipal(IIdentity identity) : base(identity)
        {
            
        }

        public string ConnectionString
        {
            get
            {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity) Identity;

                // Access claims
                string user = null, passwd = null, server = null;
                foreach (Claim claim in claimsIdentity.Claims)
                {
                    switch (claim.Type)
                    {
                        case ClaimTypes.Name:
                            user = claim.Value;
                            break;

                        case "Password":
                            passwd = claim.Value;
                            break;

                        case "Server":
                            server = claim.Value;
                            break;
                    }
                }

                return "Data Source=" + server + ";User Id=" + user + ";Password=" + passwd;
            }
        }
    }
}