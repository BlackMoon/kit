// ReSharper disable InconsistentNaming

namespace Kit.Dal.Configurations
{
    /// <summary>
    /// Oracle. Настройки среды
    /// </summary>
    public class OracleEnvironmentSettings
    {
        public string Oracle_Home { get; set; }

        public string Nls_Lang { get; set; }

        public string Path { get; set; }
     
        public string Tns_Admin { get; set; }
    }
}
