namespace Kit.Kernel.Identity
{
    /// <summary>
    /// Типы заявок (claims) для строки соединения (ConnectionString)
    /// </summary>
    public static class ConnectionStringClaimTypes
    {
        public const string Sid = "sid";

        public const string DataSource = "datasource";

        public const string Password = "password";

        public const string UserId = "name";            // same as JwtClaimTypes.Name
    }
}
