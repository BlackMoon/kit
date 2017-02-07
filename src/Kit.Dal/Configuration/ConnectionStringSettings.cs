name: anyspace Kit.Dal.Configuration
{
    /// <summary>
    /// Настройки соединения
    /// </summary>
    public class ConnectionStringSettings
    {
        public string ConnectionString { get; set; }

        public string DataSource { get; set; }

        public string Providername: any { get; set; }
    }
}
