namespace Halaqat.Shared.Common
{
    public class ConnectionStringFactory(ISettingsVewModel settings)
    {
        public string GetConnectionStringWithNotDatabase()
        {
            string connectionString;
            if (settings.IsLocalDatabase)
            {
                connectionString = @$"
                    Server=.\{settings.Server};
                    Integrated Security=SSPI;
                    TrustServerCertificate=True;
                    Trusted_Connection=True;";
            }

            else
            {
                connectionString = @$"
                    Data Source={settings.IP},{settings.Port};
                    User Id={settings.UserId};
                    Password={settings.Password};
                    TrustServerCertificate=True;";
            }

            return connectionString;
        }

        public string GetConnectionString()
        {
            string connectionString;
            if (settings.IsLocalDatabase)
            {
                connectionString = @$"
                    Server=.\{settings.Server};
                    Integrated Security=SSPI;
                    Initial Catalog=halaqat;
                    TrustServerCertificate=True;
                    Trusted_Connection=True;";
            }

            else
            {
                connectionString = @$"
                    Data Source={settings.IP},{settings.Port};
                    User Id={settings.UserId};
                    Password={settings.Password};
                    Initial Catalog=halaqat;
                    TrustServerCertificate=True;";
            }

            return connectionString;
        }
    }
}
