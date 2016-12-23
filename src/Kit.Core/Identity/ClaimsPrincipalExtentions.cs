using System.Security.Claims;

namespace Kit.Core.Identity
{
    /// <summary>
    /// Расширение ClaimsPrincipal
    /// </summary>
    public static class ClaimsPrincipalExtentions
    {
        /// <summary>
        /// Получить строку соедиинения с БД
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string GetConnectionString(this ClaimsPrincipal principal)
        {
            string connectionString = null;
            ClaimsIdentity ci = principal.Identity as ClaimsIdentity;

            if (ci != null && ci.IsAuthenticated)
            {
                string passwd = principal.FindFirst(ConnectionStringClaimTypes.Password)?.Value,
                       datasource = principal.FindFirst(ConnectionStringClaimTypes.DataSource)?.Value,
                       user = principal.FindFirst(ConnectionStringClaimTypes.UserId)?.Value;

                connectionString = $"Data Source={datasource};User Id={user};Password={passwd}";
            }

            return connectionString;
        }
    }
}
