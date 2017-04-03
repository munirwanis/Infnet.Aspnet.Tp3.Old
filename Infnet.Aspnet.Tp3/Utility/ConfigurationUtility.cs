using System;

namespace Infnet.Aspnet.Tp3.Utility
{
    public class ConfigurationUtility : IConfigurationUtility
    {
        public ConfigurationUtility()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={baseDirectory}App_Data\BookStore.mdf;Integrated Security=True";
        }

        public string ConnectionString { get; }
    }
}