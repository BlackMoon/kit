using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Kit.Kernel.Identity
{
    /// <summary>
    /// Расширение ClaimsPrincipal
    /// </summary>
    public static class ClaimsPrincipalExtentions
    {
        /// <summary>
        /// Получить строку соедиинения с БД
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <returns></returns>
        public static string GetConnectionString(this ClaimsPrincipal claimsPrincipal)
        {
            string connectionString = null;
            ClaimsIdentity ci = claimsPrincipal.Identity as ClaimsIdentity;

            if (ci != null && ci.IsAuthenticated)
            {
                string passwd = ci.FindFirstValue("Password"),
                       server = ci.FindFirstValue("Server"),
                       user = ci.FindFirstValue(ClaimTypes.Name);

                connectionString = $"Data Source={server};User Id={user};Password={passwd}";
            }

            return connectionString;
        }

        /// <summary>
        /// Получить hashCode идентификатора (connectionString + lastlogindate)
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <returns>int</returns>
        public static string GetSid(this ClaimsPrincipal claimsPrincipal)
        {
            string sid = null;

            ClaimsIdentity ci = claimsPrincipal.Identity as ClaimsIdentity;
            if (ci != null)
                sid = ci.FindFirstValue(ClaimTypes.Sid);

            return sid;
        }
    }
}
