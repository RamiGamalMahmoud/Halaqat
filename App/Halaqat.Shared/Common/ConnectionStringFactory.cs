using System.Text;

namespace Halaqat.Shared.Common
{
    public class ConnectionStringFactory(ISettingsVewModel settings)
    {
        public ConnectionStringFactory WithDatabase(bool withDatabase = true)
        {
            _withDatabase = withDatabase;
            return this;
        }

        public string GetConnectionString()
        {
            StringBuilder connectionStringBuilder = new StringBuilder();
            if (settings.IsLocalDatabase)
            {
                connectionStringBuilder.Append($"Server=.\\{settings.Server};");
                connectionStringBuilder.Append("Integrated Security=SSPI;");
            }
            else
            {
                connectionStringBuilder.Append($"Server={settings.IP}{GetPort()};");
                connectionStringBuilder.Append($"User Id={settings.UserId};");
                connectionStringBuilder.Append($"Password={settings.Password};");
            }

            if (_withDatabase)
            {
                connectionStringBuilder.Append("Initial Catalog=halaqat;");
            }

            connectionStringBuilder.Append("TrustServerCertificate=True;");
            return connectionStringBuilder.ToString();
        }

        private string GetPort()
        {
            return string.IsNullOrEmpty(settings.Port.ToString()) ? "" : $",{settings.Port}";
        }

        private bool _withDatabase;
    }
}
